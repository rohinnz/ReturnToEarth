using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EcosystemController : MonoBehaviour
{
    public UIController uiController;
    public float cullRate = 1f;

    

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        
    }

    public void Populate(SpawnableObject o, float amount)
    {
        o.Population += amount;
    }

    public void  Kill (Creation c)
    {
        c.spawnableObject.Population -= c.spawnableObject.SpawnAmount;
        Destroy(c.gameObject);
    }

    public void Cull(SpawnableObject o, int amount)
    {
        GameCore.CreationLookup[o.name];
    }

    public void PopulationTick()
    {
        foreach (SpawnableObject o in GameCore.SpawnableList)
        {
            o.TotalConsumptionOfMe = 0f;
        }

        foreach (SpawnableObject o in GameCore.SpawnableList)
        {
            foreach(Consumption c in o.Consumption)
            {
                Debug.Log(o.name + " consumed " + (c.Amount*o.Population).ToString("0") + " of " + c.SpawnableObject.name);
                c.SpawnableObject.TotalConsumptionOfMe += c.Amount * o.Population;
            }
        }

        foreach (SpawnableObject o in GameCore.SpawnableList)
        {
            o.TotalConsumptionOfMe = 0f;
        }

        uiController.UpdatePopulationDetails();
    }
}