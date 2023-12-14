using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] //what is this
    GameObject fishPrefab;

    [SerializeField] //what is this
    GameObject floorPrefab;

    [SerializeField] //what is this
    int fishToSpawn;

    [SerializeField] //what is this
    int radius;

    Collider[] colliders;

    float xSpawnRangeLo;
    float xSpawnRangeHi;

    float ySpawnRangeLo;
    float ySpawnRangeHi;

    float zSpawnRangeLo;
    float zSpawnRangeHi;


    float halfX;
    float halfY;
    float halfZ;

    Quaternion fishOrientation = Quaternion.Euler(0, 0, 0);



    // Start is called before the first frame update
    void Start()
    {
        GameObject tempFloor = Instantiate(floorPrefab, Vector3.zero, Quaternion.identity);
        MeshRenderer tempFloorMeshRenderer = tempFloor.GetComponent<MeshRenderer>();

        xSpawnRangeLo = tempFloorMeshRenderer.bounds.min.x;
        xSpawnRangeHi = tempFloorMeshRenderer.bounds.max.x;

        ySpawnRangeLo = tempFloorMeshRenderer.bounds.min.y + 2;
        ySpawnRangeHi = tempFloorMeshRenderer.bounds.max.y + 3;

        zSpawnRangeLo = tempFloorMeshRenderer.bounds.min.z;
        zSpawnRangeHi = tempFloorMeshRenderer.bounds.max.z;

        Destroy(tempFloor);

        GameObject tempFish = SpawnFish(new Vector3(xSpawnRangeHi + 50, 4, 0));
        MeshRenderer tempFishMeshRenderer = tempFish.GetComponent<MeshRenderer>();


        halfX = tempFishMeshRenderer.bounds.extents.x;
        halfY = tempFishMeshRenderer.bounds.extents.y;
        halfZ = tempFishMeshRenderer.bounds.extents.z;

        Destroy(tempFish);

        SpawnConflictFree(fishToSpawn);
    }


    GameObject SpawnFish(Vector3 position)
    {
        return Instantiate(fishPrefab, position, fishOrientation);
    }


    void SpawnConflictFree(int n)
    {
        Vector3 spawnPostition;
        bool spawnCollision = true;
        int maxSpawnAttempts = 80;
        int spawnAttempt = 0;


        for (int i = 0; i < n; i++)
        {
            do
            {
                spawnAttempt++;
                spawnPostition = SpawnInRange();
                spawnCollision = CollisionOccurs(spawnPostition);
            } while (spawnCollision && maxSpawnAttempts <= maxSpawnAttempts);


            if (!spawnCollision)
            {
                SpawnFish(spawnPostition);

            }
            else
            {
                Debug.Log("skipping this spawn...... could not find a collision free spawn point");
            }

            spawnAttempt = 0;
        }
    }



    Vector3 SpawnInRange()
    {
        float x = Random.Range(xSpawnRangeLo, xSpawnRangeHi);
        float y = Random.Range(ySpawnRangeLo, ySpawnRangeHi);
        float z = Random.Range(zSpawnRangeLo, zSpawnRangeHi);

        Vector3 spawnPosition = new Vector3(x, y, z);
        return spawnPosition;
    }

    bool CollisionOccurs(Vector3 spawnPos)
    {
        bool collisionOccurs = false;

        colliders = Physics.OverlapSphere(spawnPos, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 lowerLeft = colliders[i].bounds.min;
            Vector3 upperRight = colliders[i].bounds.max;


            collisionOccurs = (spawnPos.x + halfX >= lowerLeft.x && upperRight.x >= spawnPos.x - halfX)
                && (spawnPos.y + halfY >= lowerLeft.y && upperRight.y >= spawnPos.y - halfY)
                && (spawnPos.z + halfZ >= lowerLeft.z && upperRight.z >= spawnPos.z - halfZ);

            if (collisionOccurs)
            {
                break;
            }
        }

        return collisionOccurs;
    }




    public int ReturnFishToSpawn()
    {
        return fishToSpawn;
    }
}
