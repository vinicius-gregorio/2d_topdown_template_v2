using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
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
                Debug.Log("Detected");
            playerItems.AddWater(waterValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlayer = false;
        }
    }
}
