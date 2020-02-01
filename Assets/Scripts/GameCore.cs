using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public float GameSpeed = 1f;
    public float Energy;
    public float MaxEnergy = 200f;
    public Text EnergyText;
    public Slerper EnergySlerper;

    public Scaleable WaterScaler;

    public static Dictionary<string, SpawnableObject> SpawnableLookup = new Dictionary<string, SpawnableObject>();
    public static List<SpawnableObject> SpawnableList = new List<SpawnableObject>();
    public Transform SpawnableObjectsContainer;
    EcosystemController ecosystem;
    UIController uiController;

    // Start is called before the first frame update
    void Awake()
    {
        ecosystem = FindObjectOfType<EcosystemController>();
        uiController = FindObjectOfType<UIController>();
        Energy = MaxEnergy;
        UpdateEnergy();
        SpawnableList = GetSpawnables();
        uiController.populationPanel.CreatePopulationPanels(SpawnableList);
        InvokeRepeating("GameTick",1f,1f);
    }

    void GameTick()
    {
        ecosystem.PopulationTick();
    }

    List<SpawnableObject> GetSpawnables()
    {
        List<SpawnableObject> spawnables = new List<SpawnableObject>();
        Debug.Log(SpawnableObjectsContainer.childCount);
        for (int i = 0; i < SpawnableObjectsContainer.childCount; i++)
        {
            SpawnableObject o = SpawnableObjectsContainer.GetChild(i).GetComponent<SpawnableObject>();
            spawnables.Add(o);
            SpawnableLookup.Add(o.name, o);
        }
        return spawnables;
    }

    void UpdateEnergy()
    {
        EnergyText.text = "Energy: " + Energy.ToString("0") + "/" + MaxEnergy.ToString("0");
        float energyScale = Energy / MaxEnergy;
        EnergySlerper.SetNonSlerpValue(energyScale);
        //EnergySlerper.SetTargetScale(energyScale);
    }

    public void IncreaseWater(float amount)
    {
        ecosystem.Populate(SpawnableLookup["Water"], amount);
        WaterScaler.IncreaseScale(amount);
    }

    public void UseEnergy(float amount)
    {
        Energy -= amount;
        UpdateEnergy();
    }
}
