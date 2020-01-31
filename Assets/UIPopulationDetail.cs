using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIPopulationDetail : MonoBehaviour
{
    public TMP_Text PopulationText;
    public Slerper Level;
    public SpawnableObject spawnableObject;

    private void Start()
    {
        
        PopulationText.text = spawnableObject.isWater ?
            spawnableObject.name + spawnableObject.Population.ToString(" [0%]") :
            spawnableObject.name + spawnableObject.Population.ToString(" [0]");

        //Level.SetNonSlerpValue(spawnableObject.Population / spawnableObject.MaxPopulation);
    }

}
