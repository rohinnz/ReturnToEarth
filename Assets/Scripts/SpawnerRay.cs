using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRay : MonoBehaviour
{
    public GameObject treePrefab;
    EcosystemController ecosystem;
    public SpawnableObject selectedSpawn;
    public GameCore gameCore;
    UIController uiController;
    

    public void SelectSpawnable(SpawnableObject spawnable)
    {
        selectedSpawn = spawnable;
        uiController.UpdateSpawnerText(spawnable);
    }

    public void UseSelectedSpawnable(RaycastHit hit)
    {
        if (!selectedSpawn.isWater)
        {
            Vector3 spawnPoint = hit.point;
            Quaternion startRotation = Quaternion.LookRotation(hit.normal);
            GameObject newGo = Instantiate(selectedSpawn.Prefab, spawnPoint, startRotation, hit.transform);
        }
        else
        {
            gameCore.IncreaseWater(selectedSpawn.SpawnAmount);
        }
        
        gameCore.UseEnergy(selectedSpawn.EnergyConsumption);
    }

    void Start()
    {
        ecosystem = FindObjectOfType<EcosystemController>();
        gameCore = FindObjectOfType<GameCore>();
        uiController = FindObjectOfType<UIController>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                UseSelectedSpawnable(hit);
            }
        }
    }
}
