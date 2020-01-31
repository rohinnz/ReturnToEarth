using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIPopulationDetail : MonoBehaviour
{
    public TMP_Text PopulationText;
    public Slerper PopulationBar;
    public SpawnableObject spawnableObject;

    private void Start()
    {
        PopulationBar.ImageToFill.color = spawnableObject.BarColour;
        Refresh();
    }

    public void Refresh()
    {
        PopulationText.text = spawnableObject.isWater ?
            spawnableObject.name + spawnableObject.Population.ToString(" [0%]") :
            spawnableObject.name + spawnableObject.Population.ToString(" [0]");

        if (spawnableObject.Population == 0f)
        {
            PopulationBar.SetNonSlerpValue(0f);
        }
        else
        {
            PopulationBar.SetNonSlerpValue(spawnableObject.Population / spawnableObject.MaxPopulation);
        }
    }
}
