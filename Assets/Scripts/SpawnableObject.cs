﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Consumption
{
    public SpawnableObject SpawnableObject;
    public float Amount;
}

public class SpawnableObject : MonoBehaviour
{
    public float SpawnAmount = 1f;
    public bool isWater = false;
    public List<Consumption> Consumption = new List<Consumption>();
    public GameObject[] Prefabs;

    public bool canSwim = false;
    public float EnergyConsumption = 1f;
    public Color BarColour;
    [TextArea]
    public string Tooltip;

    public int TooltipLines = 3;

    //public float Population = 0f;
    public float Population
    {
        get
        {
            if (!isWater)
            {
                // The population is how many creatures are in the lookup list
                return GameCore.CreationLookup[name].Count;
            }
            else
            {
                return GameCore.WaterLevel;
            }
        }
    }
    public float MaxPopulation = 1f;
    public float TotalConsumptionOfMe = 0f;
}
