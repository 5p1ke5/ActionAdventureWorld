using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : Hitbox
{
    private PlatformerPhysics physics;
    private AudioSource audioSource;

    private void Start()
    {
        base.Start();
        physics = GetComponent<PlatformerPhysics>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //If it collides with a hurtbox made by the player takes damage and maybe destroys self.
            case "PlayerHurtbox":
                if (flicker <= 0)
                {
                    hp--;
                    //audioSource.PlayOneShot(audioSource.clip);
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    if (hp > 0)
                    {
                        Vector3 knockback = (other.transform.position - transform.position).normalized * Time.deltaTime * -500;
                        physics.velocity += knockback;
                        flicker = flickerSeconds * Time.deltaTime;
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
                break;
            default:
                break;
        }
    }

    private void StartDie()
    {

    }

    private void Die()
    {

    }
}
