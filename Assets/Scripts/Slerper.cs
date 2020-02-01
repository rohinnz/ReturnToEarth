using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slerper : MonoBehaviour
{
    public float targetVal = 1f;
    public float fromVal = 1f;
    public float progress = 0f;

    public Image ImageToFill;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
    }

    public void SetNonSlerpValue(float amount)
    {
        ImageToFill.fillAmount = amount;
        fromVal = amount;
        targetVal = amount;
        progress = amount;
    }

    public void SetTargetScale(float target)
    {
        fromVal = ImageToFill.fillAmount;
        targetVal = target;
        progress = 0f;
    }
    // Update is called once per frame
    protected void Update()
    {
        if (targetVal != fromVal)
        {
            progress = Mathf.Clamp(progress + Time.deltaTime, 0f, 1f);

            ImageToFill.fillAmount = Mathf.SmoothStep(fromVal, targetVal, progress);

            if (progress == 1f)
            {
                fromVal = targetVal;
            }
        }
    }
}
