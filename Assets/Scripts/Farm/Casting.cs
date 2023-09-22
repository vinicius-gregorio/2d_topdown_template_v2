using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [Header("Components")]
    
    [SerializeField] private int percentageCatchFish;
    [SerializeField] private GameObject fishPrefab;
    private PlayerItems playerItems;
    private bool detectPlayer;
    private PlayerAnimation playerAnimation;

    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        playerAnimation = playerItems.GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (detectPlayer && Input.GetKeyDown(KeyCode.E))
        {
        playerAnimation.OnCastingStart();
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

    public void OnCasting()
    {
        int randomV = Random.Range(0, 100);
        if(randomV <= percentageCatchFish)
        {
            //pescou
            Debug.Log("got");
            Instantiate(fishPrefab, playerItems.transform.position + new Vector3(Random.Range(-2f, -1f), Random.Range(0f, 1f), 0f), Quaternion.identity);
        }
        else
        {
            //num pescou :x
            Debug.Log("nothing");

        }
    }
}
