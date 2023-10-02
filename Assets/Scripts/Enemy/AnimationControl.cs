using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(int animationValue)
    {
        animator.SetInteger("transition", animationValue);
    }


    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
        if (hit != null)
        {
            //detect player collision
            Debug.Log("player hit");
        }
        else
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
