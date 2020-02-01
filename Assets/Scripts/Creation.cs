using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creation : MonoBehaviour
{
    public SpawnableObject spawnableObject;

    private void Start()
    {
        //Removed for now because I can't get the models to all rotate consistently
        //transform.GetChild(0).Rotate(transform.up, Random.Range(0f, 360f));
    }
}
