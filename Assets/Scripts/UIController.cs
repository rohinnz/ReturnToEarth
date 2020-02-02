using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject SpawnButtonPrefab;
    public Transform ButtonPanel;
    public Transform SpawnableObjectsContainer;
    SpawnerRay spawnerRay;
    public TMP_Text selectedSpawnerText;
    public UIPopulationPanel populationPanel;
    
    private void Start()
    {
        spawnerRay = FindObjectOfType<SpawnerRay>();
        List<SpawnableObject> spawnables = GameCore.SpawnableList;
        foreach(SpawnableObject o in spawnables)
        {
            GameObject newGO = Instantiate(SpawnButtonPrefab, ButtonPanel);
            newGO.GetComponent<UISpawnButton>().ObjectToSpawn = o;
            newGO.GetComponent<Button>().onClick.AddListener(() => { spawnerRay.SelectSpawnable(o); });
            if (o.name == "Water")
            {
                newGO.GetComponent<UISpawnButton>().originalColour = newGO.GetComponent<Image>().color;
                newGO.GetComponent<UISpawnButton>().ThisButtonSelected();
                UISpawnButton.SelectedButton = newGO.GetComponent<UISpawnButton>();
            }
        }
    }

    public void UpdatePopulationDetails()
    {
        foreach(UIPopulationDetail detail in populationPanel.uiPopulations)
        {
            detail.Refresh();
        }
    }

    public void UpdateSpawnerText(SpawnableObject o)
    {
        selectedSpawnerText.text = "Spawner: "+o.name;
    }
    

    private void OnDestroy()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.onClick.RemoveAllListeners();
        }
    }
}
