using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator = null;
    [SerializeField] private Animator leverAnimator = null;

    [SerializeField] private bool open = false;
    [SerializeField] private bool close = false;

    private bool isEPressed = false;
    private bool colliding = false;

    void Update()
    {
        if (!isEPressed && colliding == true)
        {
            isEPressed = Input.GetMouseButtonDown(0);
        }
        if (colliding == false)
        {
            isEPressed = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        colliding = true;
        Debug.Log("OnTriggerStay: " + isEPressed);
        if (isEPressed)
        {
            Debug.Log("Clicked");
            if (open)
            {
                Debug.Log("Door Open");
                doorAnimator.Play("doorOpen", 0, 0.0f);
                leverAnimator.Play("LeverUp", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (close)
            {
                doorAnimator.Play("doorClose", 0, 0.0f);
                leverAnimator.Play("LeverDown", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }

}
