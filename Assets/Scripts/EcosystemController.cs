using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Population
{
    public SpawnableObject SpawnableObject;
    public float Amount;
}

public class EcosystemController : MonoBehaviour
{
    public List<Population> Populations = new List<Population>();
}