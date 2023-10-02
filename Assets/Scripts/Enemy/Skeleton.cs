using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animationController;

    [Header("Stats")]
    public float currentHealth;
    public float maxHealth;
    public Image healthBar;
    public bool isDead;

    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!isDead)
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
}
