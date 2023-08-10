using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctomonData : MonoBehaviour
{
    //Uncommon
    [Header("Round")]
    [SerializeField] public RuntimeAnimatorController roundAnimatorCTRL;
    [SerializeField] public Sprite roundSprite;
    [NonSerialized] public string roundName = "Round";
    [NonSerialized] public float roundBaseHappyLevel = 100.00f;
    [NonSerialized] public float roundBaseFun = 100.00f;
    [NonSerialized] public float roundBaseHunger = 100.00f;
    [NonSerialized] public float roundBaseCleanliness = 100.00f;

    [Header("Pointy")]
    [SerializeField] public RuntimeAnimatorController pointyAnimatorCTRL;
    [SerializeField] public Sprite pointySprite;
    [NonSerialized] public string pointyName = "Pointy";
    [NonSerialized] public float pointyBaseHappyLevel = 100.00f;
    [NonSerialized] public float pointyBaseFun = 100.00f;
    [NonSerialized] public float pointyBaseHunger = 100.00f;
    [NonSerialized] public float pointyBaseCleanliness = 100.00f;

    [Header("Button")]
    [SerializeField] public RuntimeAnimatorController buttonAnimatorCTRL;
    [SerializeField] public Sprite buttonSprite;
    [NonSerialized] public string buttonName = "Button";
    [NonSerialized] public float buttonBaseHappyLevel = 100.00f;
    [NonSerialized] public float buttonBaseFun = 100.00f;
    [NonSerialized] public float buttonBaseHunger = 100.00f;
    [NonSerialized] public float buttonBaseCleanliness = 100.00f;

    //Superior
    
    [Header("Cactus")]
    [SerializeField] public RuntimeAnimatorController cactusAnimatorCTRL;
    [SerializeField] public Sprite cactusSprite;
    [NonSerialized] public string cactusName = "Cactus";
    [NonSerialized] public float cactusBaseHappyLevel = 120.00f;
    [NonSerialized] public float cactusBaseFun = 150.00f;
    [NonSerialized] public float cactusBaseHunger = 120.00f;
    [NonSerialized] public float cactusBaseCleanliness = 120.00f;

    [Header("Strawberry")]
    [SerializeField] public RuntimeAnimatorController strawberryAnimatorCTRL;
    [SerializeField] public Sprite strawberrySprite;
    [NonSerialized] public string strawberryName = "Strawberry";
    [NonSerialized] public float strawberryBaseHappyLevel = 120.00f;
    [NonSerialized] public float strawberryBaseFun = 120.00f;
    [NonSerialized] public float strawberryBaseHunger = 150.00f;
    [NonSerialized] public float strawberryBaseCleanliness = 120.00f;

    [Header("Devil")]
    [SerializeField] public RuntimeAnimatorController devilAnimatorCTRL;
    [SerializeField] public Sprite devilSprite;
    [NonSerialized] public string devilName = "Devil";
    [NonSerialized] public float devilBaseHappyLevel = 150.00f;
    [NonSerialized] public float devilBaseFun = 120.00f;
    [NonSerialized] public float devilBaseHunger = 120.00f;
    [NonSerialized] public float devilBaseCleanliness = 120.00f;

    //Legendary
    [Header("Mummy")]
    [SerializeField] public RuntimeAnimatorController mummyAnimatorCTRL;
    [SerializeField] public Sprite mummySprite;
    [NonSerialized] public string mummyName = "Mummy";
    [NonSerialized] public float mummyBaseHappyLevel = 150.00f;
    [NonSerialized] public float mummyBaseFun = 150.00f;
    [NonSerialized] public float mummyBaseHunger = 170.00f;
    [NonSerialized] public float mummyBaseCleanliness = 150.00f;

    [Header("Pumpkin")]
    [SerializeField] public RuntimeAnimatorController pumpkinAnimatorCTRL;
    [SerializeField] public Sprite pumpkinSprite;
    [NonSerialized] public string pumpkinName = "Pumpkin";
    [NonSerialized] public float pumpkinBaseHappyLevel = 150.00f;
    [NonSerialized] public float pumpkinBaseFun = 150.00f;
    [NonSerialized] public float pumpkinBaseHunger = 170.00f;
    [NonSerialized] public float pumpkinBaseCleanliness = 150.00f;

    //Divine
    [Header("Tako")]
    [SerializeField] public RuntimeAnimatorController takoAnimatorCTRL;
    [SerializeField] public Sprite takoSprite;
    [NonSerialized] public string takoName = "Tako";
    [NonSerialized] public float takoBaseHappyLevel = 170.00f;
    [NonSerialized] public float takoBaseFun = 170.00f;
    [NonSerialized] public float takoBaseHunger = 200.00f;
    [NonSerialized] public float takoBaseCleanliness = 170.00f;

    //Waiting for Rarity to be assign



}
