using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopulationPanel : MonoBehaviour
{
    public List<UIPopulationDetail> uiPopulations;
    public GameObject uiPopulationPrefab;
    private void Start()
    {
        
        //uiPopulations = new List<UIPopulationDetail>(GetComponentsInChildren<UIPopulationDetail>());
    }

    public void CreatePopulationPanels(List<SpawnableObject> spawnables)
    {
        foreach(SpawnableObject o in spawnables)
        {
            GameObject newGO = Instantiate(uiPopulationPrefab, transform);
            UIPopulationDetail detail = newGO.GetComponent<UIPopulationDetail>();
            detail.spawnableObject = o;
            uiPopulations.Add(detail);
        }
    }
}
