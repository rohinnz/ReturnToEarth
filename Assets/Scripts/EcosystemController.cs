using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EcosystemController : MonoBehaviour
{
    public UIController uiController;
    public void Populate(SpawnableObject o, float amount)
    {
        o.Population += amount;
        uiController.UpdatePopulationDetails();
    }
}