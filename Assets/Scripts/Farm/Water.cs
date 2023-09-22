using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private bool detectPlayer;
    [SerializeField] private int waterValue;
    private PlayerItems playerItems;


    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    void Update()
    {
        if (detectPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerItems.AddWater(waterValue);
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
