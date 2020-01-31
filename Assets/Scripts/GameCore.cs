using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public float Energy;
    public float MaxEnergy = 200f;
    public Text EnergyText;
    public Slerper EnergySlerper;

    EcosystemController ecosystem;

    // Start is called before the first frame update
    void Start()
    {
        ecosystem = FindObjectOfType<EcosystemController>();
        Energy = MaxEnergy;
        UpdateEnergy();
    }

    void UpdateEnergy()
    {
        EnergyText.text = "Energy: " + Energy.ToString("0") + "/" + MaxEnergy.ToString("0");
        float energyScale = Energy / MaxEnergy;
        EnergySlerper.SetTargetScale(energyScale);
    }

    public void UseEnergy(float amount)
    {
        Energy -= amount;
        UpdateEnergy();
    }
}
