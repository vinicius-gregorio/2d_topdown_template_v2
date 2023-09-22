using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeToBuild;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform pointToMove;

    private float timeCount;
    private bool isStartBuilding;
    private bool detectPlayer;
    private Player player;
    private PlayerAnimation playerAnimation;



    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnimation = player.GetComponent<PlayerAnimation>();

    }

    void Update()
    {
        if (detectPlayer && Input.GetKeyDown(KeyCode.E))
        {
            isStartBuilding = true;
            playerAnimation.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = pointToMove.position;
            player.isStopped = true;
        }
        if (isStartBuilding)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= timeToBuild)
            {
                //build house
                playerAnimation.OnHammeringEnded();
                houseSprite.color = endColor;
                player.isStopped = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlayer = true;
            Debug.Log("Detected enter");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlayer = false;
            Debug.Log("Detected exit");

        }
    }

  
}
