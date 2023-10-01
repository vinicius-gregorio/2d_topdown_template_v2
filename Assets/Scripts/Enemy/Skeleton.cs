using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animationController;

    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 actorPos = transform.position;
        float distanceBetween = playerPos.x - actorPos.x;
        if (distanceBetween > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);

        }

        agent.SetDestination(playerPos);

        if (Vector2.Distance(transform.position, playerPos) <= agent.stoppingDistance)
        {
            //touched player - stop
            animationController.PlayAnimation(2);
        }
        else
        {
            animationController.PlayAnimation(1);
        }
    }
}
