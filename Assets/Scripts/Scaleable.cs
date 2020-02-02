using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaleable : MonoBehaviour
{
    public float targetScale = 0.9f;
    public float fromScale = 0.9f;
    public float scalingProgress = 0f;
    public float increment = 0.05f;
    Vector3 fromVector;
    Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        SetTargetScale(transform.localScale.x);
    }

    public void IncreaseScale(float i)
    {
        transform.localScale += new Vector3(increment,increment,increment);
    }

    public void SetTargetScale(float target)
    {
        fromScale = transform.localScale.x;
        targetScale = target;
        scalingProgress = 0f;
        fromVector = new Vector3(fromScale, fromScale, fromScale);
        targetVector = new Vector3(targetScale, targetScale, targetScale);
    }

    // Update is called once per frame
    void Update()
    {/*
        if (targetScale != fromScale)
        {
            scalingProgress = Mathf.Clamp(scalingProgress + Time.deltaTime, 0f, 1f);
            transform.localScale = Vector3.Slerp(fromVector,targetVector,scalingProgress);
            if (scalingProgress == 1f)
            {
                fromScale = targetScale;
            }
        }
        */
    }
}
