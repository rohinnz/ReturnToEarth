using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerLoader : MonoBehaviour
{
    public static float loadProgress = 1f;
    public float loadSpeed = 10f;
    public Image loaderBar;
    public TMP_Text loaderText;

    public void SwitchLoadout(float speed)
    {
        loadSpeed = speed;
        loadProgress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (loadProgress < 1f)
        {
            loadProgress = Mathf.Lerp(0f, 1f, loadProgress+Time.deltaTime * loadSpeed);
            Color c = Color.Lerp(Color.red, Color.green, loadProgress);
            loaderBar.color = c;
            loaderText.color = c;
            loaderBar.fillAmount = loadProgress;
        }
    }
}
