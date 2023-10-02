using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private Animator animator;
    private PlayerAnimation PLAnimation;
    private Skeleton skeleton;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PLAnimation = FindObjectOfType<PlayerAnimation>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void PlayAnimation(int animationValue)
    {
        animator.SetInteger("transition", animationValue);
    }


    public void Attack()
    {
        if (!skeleton.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
            if (hit != null)
            {
                //detect player collision
                Debug.Log("player hit");
                PLAnimation.OnHit();
            }
        }
       
    }
    public void OnHit()
    {
     

        if (skeleton.currentHealth <=0)
        {
            skeleton.isDead = true;
            animator.SetTrigger("death");
            Destroy(skeleton.gameObject, 2f);
        }
        else
        {
            animator.SetTrigger("hit");
            skeleton.currentHealth--;
            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.maxHealth;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
