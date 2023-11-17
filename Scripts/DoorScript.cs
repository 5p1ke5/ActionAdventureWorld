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

    void Update()
    {
        isEPressed = Input.GetKey(KeyCode.E);
    }
    private void OnTriggerStay(Collider other)
    {
        if (isEPressed)
        {
            if (open)
            {
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

}
