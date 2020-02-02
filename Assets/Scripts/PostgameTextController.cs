using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostgameTextController : MonoBehaviour
{
    public TMP_Text ExplanationText;
    public TMP_Text MemorialText;
    void Start()
    {
        ExplanationText.text = GameCore.EndScreenText;
        foreach(KeyValuePair<string,Dictionary<string,int>> kv in BodyCounter.Memorial)
        {
            foreach(KeyValuePair<string,int> outcome in kv.Value)
            {
                MemorialText.text += outcome.Value + " " + kv.Key + " " + outcome.Key+"\n";
            }
        }
    }
}
