using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animator animation;

    void Start()
    {
        player = GetComponent<Player>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
       OnMove();
       OnRun();
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
    #endregion
}
