using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Combat Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask enemyLayer;

    private Player player;
    private Animator animation;
    private Casting casting;

    private bool isHitting;
    private float timeCount;
    private float recoveryTime = 1f;
    void Start()
    {
        player = GetComponent<Player>();
        animation = GetComponent<Animator>();
        casting = FindObjectOfType<Casting>();
    }

    void Update()
    {
       OnMove();
       OnRun();
       HandleRecoveryTime();
    }


    #region Movement
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.IsRolling)
            {
                animation.SetTrigger("isRoll");

            }
            else
            {
                animation.SetInteger("transition", 1);

            }
        }
        else
        {

            animation.SetInteger("transition", 0);
        }

        if (player.direction.x > 0) 
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        OnCut();
        OnDig();
        OnWattering();
    }

    void OnRun()
    {
        if(player.isRunning)
        {
            animation.SetInteger("transition", 3);
        }
    }
    #endregion


    #region Action

    void OnCut()
    {
        if(player.IsCutting)
        {
            animation.SetInteger("transition", 2);
        }
    }
    void OnDig()
    {
        if(player.IsDigging)
        {
            animation.SetInteger("transition", 4);
        }
    }  void OnWattering()
    {
        if(player.IsWatering)
        {
            animation.SetInteger("transition", 5);
        }
    }


    public void OnCastingStart()
    {
        animation.SetTrigger("isCasting");
        player.isStopped = true;
    }
    public void OnCastingEnded()
    {
        casting.OnCasting();
        player.isStopped = false;

    }

    public void OnHammeringStarted()
    {
        animation.SetBool("isHammering", true);

    }
    public void OnHammeringEnded()
    {
        animation.SetBool("isHammering", false);

    }
    #endregion


    #region Combat
    private void HandleRecoveryTime()
    {
        if (isHitting)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
    }
    public void OnHit()
    {
        if(!isHitting)
        {
            animation.SetTrigger("isHurt");
            isHitting = true;
        }
        
    }

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRadius, enemyLayer);
        if (hit != null)
        {
            Debug.Log("player hiters");
            hit.GetComponentInChildren<AnimationControl>().OnHit();   
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    #endregion
}
