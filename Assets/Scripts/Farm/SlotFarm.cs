using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private int digLife;


    [Header("Settings")]
    [SerializeField] private bool isDetectingPlayer;
    [SerializeField] private float waterAmountToGrow;

    private int initialDigLife;
    private float currentWater;
    private bool isHoleDug;
    PlayerItems plItems;

    private void Start()
    {
        initialDigLife = digLife;
        plItems = FindObjectOfType<PlayerItems>();
    }

    private void Update()
    {

        if(isHoleDug)
        {
            if (isDetectingPlayer)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmountToGrow)
            {   
                spriteRenderer.sprite = carrot;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    spriteRenderer.sprite = hole;
                    plItems.totalCarrots += 1;
                    currentWater = 0f;
                }
            }
        }
      
    }
    public void OnHit()
    {
        digLife--;
        if (digLife <= initialDigLife/2)
        {
            spriteRenderer.sprite = hole;
            isHoleDug = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("P_Dig"))
        {
            OnHit();
        }
        if (collision.CompareTag("P_Water"))
        {
            isDetectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("P_Water"))
        {
            isDetectingPlayer = false;
        }
    }
}
