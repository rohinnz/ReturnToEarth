using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public static GameCore instance;
    public TMP_Text TickText;
    public TMP_Text UpdatesText;
    int TickCount = 1;

    public float GameSpeed = 1f;
    public float Energy;
    public float MaxEnergy = 200f;
    public TMP_Text EnergyText;
    public Slerper EnergySlerper;

    public static float WaterLevel = 50f;

    public SphereCollider waterCollider;
    public Scaleable WaterScaler;
    public Transform WaterTransform;

    public static Dictionary<string, SpawnableObject> SpawnableLookup = new Dictionary<string, SpawnableObject>();
    public static List<SpawnableObject> SpawnableList = new List<SpawnableObject>();
    public static Dictionary<string, List<Creation>> CreationLookup = new Dictionary<string, List<Creation>>();

    public Transform SpawnableObjectsContainer;
    EcosystemController ecosystem;
    UIController uiController;
    SpawnerRay spawnerRay;

    public string[] WinText;
    public string[] LoseText;

    

    public static string EndScreenText = "Test";

    public void LoseGame(string text)
    {
        EndScreenText = text;
        SceneManager.LoadScene("LoseScreen");
    }


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        ecosystem = FindObjectOfType<EcosystemController>();
        uiController = FindObjectOfType<UIController>();
        Energy = MaxEnergy;
        UpdateEnergy();
        SpawnableList = GetSpawnables();
        uiController.populationPanel.CreatePopulationPanels(SpawnableList);
        InvokeRepeating("GameTick",1f,1f);
        spawnerRay = FindObjectOfType<SpawnerRay>();
    }

    void GameTick()
    {
        TickCount++;
        TickText.text = TickCount.ToString("Game Ticks: 0");
        int drownCount = 0;
        int vegetationWashedOut = 0;
        UpdatesText.text = "";
        RaycastHit[] hits;
        Collider[] colliders;
        colliders = Physics.OverlapSphere(waterCollider.transform.position, waterCollider.transform.localScale.x,spawnerRay.planetLayer);
        foreach(Collider h in colliders)
        {
            Creation c = h.transform.GetComponent<Creation>();
            //Debug.Log(h.transform.name);
            if (c != null)
            {
                ecosystem.Kill(h.transform.gameObject.GetComponent<Creation>());
                if (c.spawnableObject.name == "Vegetation")
                {
                    vegetationWashedOut++;
                }
                else
                {
                    BodyCounter.RecordDeath(c.name, "drowned", 1);
                    drownCount += 1;
                }
                
            }
        }
        if (drownCount > 0)
        {
            
            UpdatesText.text += drownCount.ToString("<color=red>0</color> creatures drowned\n");
        }
        if (vegetationWashedOut > 0)
        {
            BodyCounter.RecordDeath("Vegetation", "washed away", vegetationWashedOut);
            UpdatesText.text += vegetationWashedOut.ToString("<color=red>0</color> vegetation washed away\n");
        }
        if (WaterTransform.localScale.x >= 1.4f)
        {
            LoseGame(LoseText[0]);
            // Player has drowned the planet and lost
            Debug.Log("Planet DROWNED!");
        }
        ecosystem.PopulationTick();
        VictoryCheck();
    }

    void VictoryCheck()
    {
        SpawnableObject human = SpawnableLookup["Humanoid"];
        bool victory = false;
        if (human.Population >= 50)
        {
            victory = true;
            foreach(Consumption c in human.Consumption)
            {
                if (c.SpawnableObject.TotalConsumptionOfMe > c.SpawnableObject.Population)
                {
                    victory = false;
                }
            }
        }

        if (victory)
        {
            GameCore.EndScreenText = WinText[0];
            SceneManager.LoadScene("WinScreen");
        }
    }

    List<SpawnableObject> GetSpawnables()
    {
        List<SpawnableObject> spawnables = new List<SpawnableObject>();
        Debug.Log(SpawnableObjectsContainer.childCount);
        for (int i = 0; i < SpawnableObjectsContainer.childCount; i++)
        {
            SpawnableObject o = SpawnableObjectsContainer.GetChild(i).GetComponent<SpawnableObject>();
            spawnables.Add(o);
            GameCore.CreationLookup.Add(o.name, new List<Creation>());
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
        WaterLevel += amount;
        //ecosystem.Populate(SpawnableLookup["Water"], amount);
        WaterScaler.IncreaseScale(amount);
    }

    public void UseEnergy(float amount)
    {
        Energy -= amount;
        UpdateEnergy();
    }
}
