
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

    public void Populate(Creation newCreation)
    {
        GameCore.CreationLookup[newCreation.spawnableObject.name].Add(newCreation);
    }

    public void  Kill (Creation c)
    {
        GameCore.CreationLookup[c.spawnableObject.name].Remove(c);
        Destroy(c.gameObject);
    }

    public void Cull(SpawnableObject o, int amount)
    {
        if (o.isWater)
        {
            return;
        }
        //Debug.Log(amount.ToString("0 ") + o.name + " to cull");
        //Debug.Log(GameCore.CreationLookup[o.name].Count);
        if (GameCore.CreationLookup[o.name].Count > amount)
        {
                for (int i = 0; i < amount; i++)
                {
                    int randomIndex = Random.Range(0, GameCore.CreationLookup[o.name].Count);
                    Creation c = GameCore.CreationLookup[o.name][randomIndex];
                    //Debug.Log(c.name);
                    Destroy(c.gameObject);
                    GameCore.CreationLookup[o.name].RemoveAt(randomIndex);
                }
            }
        else
        {
            for (int i = 0; i < GameCore.CreationLookup[o.name].Count; i++)
            {
                Creation c = GameCore.CreationLookup[o.name][i];
                Destroy(c.gameObject);
            }
            GameCore.CreationLookup[o.name] = new List<Creation>();
        }

        uiController.UpdatePopulationDetails();
    }

    public void Starve(SpawnableObject o, int amount)
    {
        Cull(o, amount);
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
                c.SpawnableObject.TotalConsumptionOfMe += c.Amount * o.Population;
            }
        }

        foreach (SpawnableObject o in GameCore.SpawnableList)
        {
            if (o.TotalConsumptionOfMe > o.Population)
            {
                int unitsToKill = Mathf.FloorToInt(o.TotalConsumptionOfMe - o.Population);
                Cull(o, unitsToKill);
                if (o.name != "Water")
                {
                    if (o.Population > 0)
                    {
                        if (o.Population < o.TotalConsumptionOfMe)
                        {
                            
                            GameCore.instance.UpdatesText.text = o.Population.ToString("<color=red>0</color> " + o.name + "s were eaten\n");
                        }
                        else
                        {
                            GameCore.instance.UpdatesText.text = unitsToKill.ToString("<color=red>0</color> " + o.name + "s were eaten\n");
                        }
                    }
                    
                }
                
            }
        }

        foreach (SpawnableObject o in GameCore.SpawnableList)
        {
            int unitsToKill = 0;
            foreach(Consumption c in o.Consumption)
            {
                // When the population is insufficient for this creature to feed
                if (c.SpawnableObject.TotalConsumptionOfMe > c.SpawnableObject.Population)
                {
                    unitsToKill += Random.Range(0, Mathf.FloorToInt(c.SpawnableObject.TotalConsumptionOfMe - c.SpawnableObject.Population)+1);
                }

            }
            if (unitsToKill > 0 && o.Population > 0)
            {
                if (o.name != "Vegetation")
                {
                    GameCore.instance.UpdatesText.text += unitsToKill.ToString("<color=red>0</color> " + o.name + "s starved to death\n");
                }
                else
                {
                    GameCore.instance.UpdatesText.text += unitsToKill.ToString("<color=red>0</color> " + o.name + " withered and died without water\n");
                }
                Cull(o, unitsToKill);
            }
            
        }

        uiController.UpdatePopulationDetails();
    }
}