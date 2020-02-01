using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creation : MonoBehaviour
{
    public SpawnableObject spawnableObject;

    private void Start()
    {
        transform.GetChild(0).Rotate(Vector3.up, Random.Range(0f, 360f));
    }
}
