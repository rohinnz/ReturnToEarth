using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EcosystemController : MonoBehaviour
{
    public UIController uiController;



    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
    }

    public void Populate(SpawnableObject o, float amount)
    {
        o.Population += amount;
        uiController.UpdatePopulationDetails();
    }

    public void PopulationTick()
    {
        foreach(SpawnableObject o in GameCore.SpawnableList)
        {
            foreach(Consumption c in o.Consumption)
            {
                Debug.Log(o.name + " consumed " + c.Amount.ToString("0") + " of " + c.SpawnableObject.name);
            }
        }
    }
}