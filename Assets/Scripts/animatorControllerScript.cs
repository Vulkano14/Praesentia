using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorControllerScript : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool wPressed = Input.GetKey("w");

        if (wPressed && !isWalking)
            animator.SetBool("isWalking", true);
        if (!wPressed && isWalking)
            animator.SetBool("isWalking", false);
    }
}
