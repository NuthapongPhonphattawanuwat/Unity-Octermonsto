using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class OctomonSlotClass
{
    public GameObject slot;
    public RuntimeAnimatorController octomonAnimatorCTRL;
    public bool octomonActiveStatus;
    public string octomonName;
    public Sprite octomonSprite;
    
    public float octomonMaxHappyLevel;
    public float octomonMaxFun;
    public float octomonMaxHunger;
    public float octomonMaxCleanliness;

    public float octomonCurrentHappyLevel;
    public float octomonCurrentFun;
    public float octomonCurrentHunger;
    public float octomonCurrentCleanliness;

    public Image octomonImage;
    public TextMeshProUGUI octomonNameTMP;
}