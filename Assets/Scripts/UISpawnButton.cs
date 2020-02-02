using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISpawnButton : MonoBehaviour
{
    Color originalColour;
    public SpawnableObject ObjectToSpawn;
    public Image buttonImage;
    public TMP_Text buttonText;
    public Image spawnableSprite;
    public static UISpawnButton SelectedButton;
    public Color HighlightColour;

    private void Start()
    {
        buttonText.text = ObjectToSpawn.name;
        spawnableSprite.sprite = ObjectToSpawn.Sprite;
        originalColour = buttonImage.color;
    }

    public void DeselectButton()
    {
        buttonImage.color = originalColour;
    }

    public void ThisButtonSelected()
    {
        if (SelectedButton != null)
        {
            SelectedButton.DeselectButton();
        }
        buttonImage.color = HighlightColour;
        SelectedButton = this;
    }
}
