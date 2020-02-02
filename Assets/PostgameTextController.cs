using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostgameTextController : MonoBehaviour
{
    public TMP_Text ExplanationText;

    void Start()
    {
        ExplanationText.text = GameCore.EndScreenText;
    }
}
