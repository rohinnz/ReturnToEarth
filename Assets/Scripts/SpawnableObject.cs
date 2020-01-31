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
    public List<Consumption> Consumption = new List<Consumption>();
    public GameObject Prefab;
    public float EnergyConsumption = 1f;
}
