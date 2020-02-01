using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    [SerializeField] Vector3 RotateBy = Vector3.zero;

    void Update()
    {
        transform.Rotate(RotateBy);
    }
}
