using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image woodUIBar;


    [Header("Tools")]
    
    public List<Image>  toolsUI = new List<Image>();
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    private PlayerItems playerItems;
    private Player player;


    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
        
    }
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
    }

   
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.WaterLimit;
        woodUIBar.fillAmount = playerItems.TotalWoodCount / playerItems.WoodLimit;
        carrotUIBar.fillAmount = playerItems.totalCarrots / playerItems.CarrotLimit;

       

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.HandlingObj -1 )
            {
                toolsUI[i].color = activeColor;
            }
            else
            {
                toolsUI[i].color = inactiveColor;
            }
        }
    }
}
