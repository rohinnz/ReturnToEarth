using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public RectTransform tooltipTransform;
    public TMP_Text tooltipText;

    public static Tooltip instance;
    private void Awake()
    {

        instance = this;
    }
    public void ShowTooltip(string text, int lines)
    {
        tooltipTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, lines * 20);
        tooltipText.text = text;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
        Debug.Log(transform.position);
    }
}
