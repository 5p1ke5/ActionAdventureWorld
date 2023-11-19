using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitbox : Hitbox
{
    private PlatformerPhysics physics;
    private AudioSource audioSource;
    public TextMeshProUGUI lifeScore;

    private void Start()
    {
        base.Start();
        physics = GetComponent<PlatformerPhysics>();
        audioSource = GetComponent<AudioSource>();
        lifeScore.text = "Life: " + hp;
    }

    private void OnTriggerStay(Collider other)
    {
        //Different collision types are handled here.
        switch (other.gameObject.tag)
        {
            case "EnemyHurtbox":
                if (flicker <= 0) //Cant take damage if flickering.
                {
                    audioSource.PlayOneShot(audioSource.clip);
                    hp--;
                    lifeScore.text = "Life: " + hp;

                    //Take damage
                    if (hp > 0)
                    {
                        //Gets vector to use to knock the player back and then adds that to velocity to make them knock back during Update.
                        Vector3 knockback = (other.transform.position - transform.position).normalized * Time.deltaTime * -500;
                        physics.velocity += knockback;
                        flicker = flickerSeconds * Time.deltaTime;
                    }
                    else //If HP < 0 kills you and you lose the game.
                    {
                        
                        MenuBehavior.EnableMenu(MenuBehavior.ReturnMenuGameObject("LoseMenu")); 
                    }
                }
                break;
            default:
                break;
        }
    }
}
