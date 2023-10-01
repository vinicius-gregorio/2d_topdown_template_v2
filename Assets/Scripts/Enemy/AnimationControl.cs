using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(int animationValue)
    {
        animator.SetInteger("transition", animationValue);
    }
}
