using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalData", menuName = "Farm/AnimalData")]
public class AnimalData : ScriptableObject
{
    public string animalName;
    public float maxHunger = 100f;
    public float maxEnergy = 100f;
    public float hungerDecayRate = 10f; // How fast hunger decreases over time
    public float energyDecayRate = 5f;  // How fast energy decreases
    public float feedingAmount = 50f;   // How much hunger is restored when fed
    public float sleepingEnergyRestore = 20f;  // Energy restored per second when asleep
}
