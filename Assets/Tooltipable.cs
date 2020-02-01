using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltipable : MonoBehaviour
{
    public Button myButton;
    [TextArea]
    public string tooltipText;
    public int  tooltipLines = 2;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
    }


    public void TriggerTooltip()
    {
        Tooltip.instance.gameObject.SetActive(true);
        Tooltip.instance.ShowTooltip(tooltipText, tooltipLines);
    }

    public void ResetTooltip()
    {
        Tooltip.instance.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {

    }
}
