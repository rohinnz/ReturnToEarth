using System;
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
    public GameObject Prefab;
    public float EnergyConsumption = 1f;
    public Color BarColour;
    public float Population = 0f;
    public float MaxPopulation = 1f;
    public float TotalConsumptionOfMe = 0f;
}
