using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject SpawnButtonPrefab;
    public Transform ButtonPanel;
    public Transform SpawnableObjectsContainer;
    SpawnerRay spawnerRay;

    public Text selectedSpawnerText;
    
    private void Start()
    {
        spawnerRay = FindObjectOfType<SpawnerRay>();
        List<SpawnableObject> spawnables = GetSpawnables();
        foreach(SpawnableObject o in spawnables)
        {
            GameObject newGO = Instantiate(SpawnButtonPrefab, ButtonPanel);
            newGO.GetComponent<UISpawnButton>().ObjectToSpawn = o;
            newGO.GetComponentInChildren<Text>().text = "Spawn "+o.name;
            newGO.GetComponent<Button>().onClick.AddListener(() => { spawnerRay.SelectSpawnable(o); });
        }
    }

    public void UpdateSpawnerText(SpawnableObject o)
    {
        selectedSpawnerText.text = "Spawner: "+o.name;
    }
    List<SpawnableObject> GetSpawnables()
    {
        List<SpawnableObject> spawnables = new List<SpawnableObject>();
        Debug.Log(SpawnableObjectsContainer.childCount);
        for (int i = 0; i < SpawnableObjectsContainer.childCount; i++)
        {
            spawnables.Add(SpawnableObjectsContainer.GetChild(i).GetComponent<SpawnableObject>());
        }
        return spawnables;
    }

    private void OnDestroy()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.onClick.RemoveAllListeners();
        }
    }
}
