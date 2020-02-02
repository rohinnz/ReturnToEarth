using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltipable : MonoBehaviour
{
    public UISpawnButton spawnButton;

    public string tooltipText
    {
        get
        {
            return spawnButton.ObjectToSpawn.Tooltip;
        }
    }

    public int tooltipLines
    {
        get
        {
            return spawnButton.ObjectToSpawn.TooltipLines;
        }
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
