using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWoodCount;
    public int totalCarrots;
    public float currentWater;
    private float waterLimit = 50f;
    private float carrotLimit = 10;
    private float woodLimit = 3;
    public int TotalWoodCount { get => totalWoodCount; set => totalWoodCount = value; }
    public float WaterLimit { get => waterLimit; set => waterLimit = value; }
    public float CarrotLimit { get => carrotLimit; set => carrotLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }

    public void AddWater(float water)
    {
        if(currentWater < WaterLimit)
        {
            Debug.Log("Add Watter");
            currentWater += water;

        }
    }
}
