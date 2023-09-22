using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWoodCount;
    public float currentWater;
    private float waterLimit = 50f;
    public int totalCarrots;
    public int TotalWoodCount { get => totalWoodCount; set => totalWoodCount = value; }
  
    public void AddWater(float water)
    {
        if(currentWater < waterLimit)
        {
            Debug.Log("Add Watter");
            currentWater += water;

        }
    }
}
