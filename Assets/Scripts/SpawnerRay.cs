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
    bool canSpawn = true;
    public void SelectSpawnable(SpawnableObject spawnable)
    {
        selectedSpawn = spawnable;
        uiController.UpdateSpawnerText(spawnable);
    }

    public void UseSelectedSpawnable(RaycastHit hit)
    {
        if (SpawnerLoader.loadProgress == 1f)
        {

            if (!selectedSpawn.isWater)
            {
                Vector3 spawnPoint = hit.point;
                Quaternion startRotation = Quaternion.LookRotation(hit.normal);
                GameObject newGo = Instantiate(selectedSpawn.Prefabs[Random.Range(0,selectedSpawn.Prefabs.Length)], spawnPoint, startRotation, hit.transform);
                Creation newCreation = newGo.AddComponent<Creation>();
                newCreation.spawnableObject = selectedSpawn;
            
                Debug.Log(GameCore.CreationLookup.Count);
                ecosystem.Populate(newCreation);
            }
            // Water is a special case, should change how it is used if there's time.
            else
            {
                gameCore.IncreaseWater(selectedSpawn.SpawnAmount);
            }
        
            gameCore.UseEnergy(selectedSpawn.EnergyConsumption);
            uiController.UpdatePopulationDetails();

        }
    }

    void Start()
    {
        ecosystem = FindObjectOfType<EcosystemController>();
        gameCore = FindObjectOfType<GameCore>();
        uiController = FindObjectOfType<UIController>();
        selectedSpawn = GameCore.SpawnableLookup["Water"];
    }

    void Update()
    {
        Targeter.gameObject.SetActive(false);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, 1000, planetLayer.value);
        canSpawn = true;
        int planetHitIndex = -1;

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                //Debug.Log(hits[i].transform.name);
                RaycastHit h = hits[i];
                if (h.transform.tag == "Planet")
                {
                    Targeter.gameObject.SetActive(true);
                    Targeter.position = h.point;
                    planetHitIndex = i;
                }
                else
                {
                    canSpawn = false;
                }
            }

            if (Input.GetMouseButton(0) && planetHitIndex != -1 && canSpawn)
            {
                UseSelectedSpawnable(hits[planetHitIndex]);
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
