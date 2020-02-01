using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRay : MonoBehaviour
{
    EcosystemController ecosystem;
    public SpawnableObject selectedSpawn;
    public GameCore gameCore;
    UIController uiController;
    Vector3 mouseRotationStart;
    Vector3 mouseRotationTarget;
    public Transform planetTransform;
    public Transform Targeter;
    public LayerMask planetLayer;
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
            newGo.GetComponent<Creation>().spawnableObject = selectedSpawn;
            ecosystem.Populate(selectedSpawn, selectedSpawn.SpawnAmount);
        }
        // Water is a special case, should change how it is used if there's time.
        else
        {
            gameCore.IncreaseWater(selectedSpawn.SpawnAmount);
            ecosystem.Populate(selectedSpawn, selectedSpawn.SpawnAmount);
        }
        
        gameCore.UseEnergy(selectedSpawn.EnergyConsumption);
        uiController.UpdatePopulationDetails();
    }

    void Start()
    {
        ecosystem = FindObjectOfType<EcosystemController>();
        gameCore = FindObjectOfType<GameCore>();
        uiController = FindObjectOfType<UIController>();
        selectedSpawn = GameCore.SpawnableLookup["water"];
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit,1000,planetLayer.value))
        {
            Targeter.position = hit.point;

            if (Input.GetMouseButton(0))
            {
                UseSelectedSpawnable(hit);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            mouseRotationStart = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            mouseRotationTarget = Input.mousePosition;
            //Vector3 rotation = new Vector3((mouseRotationTarget.y - mouseRotationStart.y)*-1, mouseRotationTarget.x - mouseRotationStart.x)*0.01f;
            Camera.main.transform.parent.Rotate(planetTransform.up, (mouseRotationTarget.x - mouseRotationStart.x)*0.01f);
            //planetTransform.Rotate(rotation,Space.World);
        }
    }
}
