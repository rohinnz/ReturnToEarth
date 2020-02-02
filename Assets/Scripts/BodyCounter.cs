using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCounter : MonoBehaviour
{
    public Dictionary<string, Dictionary<string, int>> Memorial = new Dictionary<string, Dictionary<string, int>>();

    private void Start()
    {
        
    }

    public void RecordDeath(string creature, string deathType, int number)
    {
        if (Memorial.ContainsKey(creature))
    }
}
