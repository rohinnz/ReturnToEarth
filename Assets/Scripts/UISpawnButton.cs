using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISpawnButton : MonoBehaviour
{
    public Color originalColour;
    public SpawnableObject ObjectToSpawn;
    public Image buttonImage;
    public TMP_Text buttonText;
    public Image spawnableSprite;
    public static UISpawnButton SelectedButton;
    public Color HighlightColour;
    private void Awake()
    {
        originalColour = buttonImage.color;
    }
    private void Start()
    {
        buttonText.text = ObjectToSpawn.name;
        spawnableSprite.sprite = ObjectToSpawn.Sprite;
        
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
