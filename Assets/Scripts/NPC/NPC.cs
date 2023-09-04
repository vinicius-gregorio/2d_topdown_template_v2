using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public float speed;
    private float initialSpeed;
    private int index;
    public List<Transform> paths = new List<Transform>();
    private Animator animator;

    private void Start()
    {
        initialSpeed = speed;
        animator = GetComponent<Animator>();
    }
    void Update()
    {

        #region Make NPC stop moving while showing dialog
        if (DialogControl.Instance.isShowing)
        {
            speed = 0f;
            animator.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            animator.SetBool("isWalking", true);

        }

        #endregion

        #region Make Npc Follow Path
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f ) 
        {
            if (index < paths.Count - 1)
            {
                //Make NPC go to the next path:
                // index++;


                //Make NPC follow randomized paths
                index = Random.Range(0, paths.Count - 1);
            }
            else
            {
                index = 0;
            }
        }

        #endregion
        //Rotate NPC towards movement direction


        #region Make npc faces move direction
        Vector2 direction = paths[index].position - transform.position;
        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);

        }
        #endregion
    }
}
