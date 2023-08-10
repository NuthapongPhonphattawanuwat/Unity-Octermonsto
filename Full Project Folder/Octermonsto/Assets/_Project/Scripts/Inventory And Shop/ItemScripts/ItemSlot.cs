using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //============================================== UI and Canvas==============================================//
    [Header("Canvas")] 
    [SerializeField] private GameObject _itemInfoCanvas;
    [SerializeField] private GameObject _inventoryCanvas;

    [Header("Scripts")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private OctomonSlot _octomonSlot;
    [SerializeField] private MobileSaveAndLoadManager _mobileSaveAndLoadManager;
    [SerializeField] private ProfileScript _profileScript;

    [Header("Amount TMPs")] 
    [SerializeField] private TextMeshProUGUI _plasticBallAmountTMP;
    [SerializeField] private TextMeshProUGUI _bubbleMachineAmountTMP;
    [SerializeField] private TextMeshProUGUI _clamAmountTMP;
    [SerializeField] private TextMeshProUGUI _cookedFishAmountTMP;
    [SerializeField] private TextMeshProUGUI _soapAmountTMP;
    [SerializeField] private TextMeshProUGUI _shampooAmountTMP;

    //============================================== Item Info Canvas ==============================================//
    [Header("Item info")] 
    [SerializeField] private Image _itemInfo_ImageSlot;
    [SerializeField] private TextMeshProUGUI _itemInfo_Name;
    [SerializeField] private TextMeshProUGUI _itemInfo_stats;
    [SerializeField] private TextMeshProUGUI _itemInfo_Description;

    private string _thisItem_Name;
    private int _thisItem_Amount;
    private float _thisItem_HappyLevel;
    private float _thisItem_Fun;
    private float _thisItem_Hunger;
    private float _thisItem_Cleanliness;

    //---------------------------------------------- FUN ----------------------------------------------//
    [Header("Plastic Ball")]
    [HideInInspector] public Sprite plasticBallSprite;
    [HideInInspector] public string plasticBallName = "Plastic Ball";
    [HideInInspector] public string plasticBallDescription = "A plastic ball, can give it to your octomon to raise their fun status!";
    [HideInInspector] public int plasticBallAmount;
    [HideInInspector] public float plasticBallHappyLevel = 7.5f;
    [HideInInspector] public float plasticBallFun = 15f;
    [HideInInspector] public float plasticBallHunger = 0f;
    [HideInInspector] public float plasticBallCleanliness = 0f;

    [Header("Bubble Machine")]
    [HideInInspector] public Sprite bubbleMachineSprite;
    [HideInInspector] public string bubbleMachineName = "Bubble Whale";
    [HideInInspector] public string bubbleMachineDescription = "Bubble whale can be a good friend for your octomon!";
    [HideInInspector] public int bubbleMachineAmount;
    [HideInInspector] public float bubbleMachineHappyLevel = 17.5f;
    [HideInInspector] public float bubbleMachineFun = 35f;
    [HideInInspector] public float bubbleMachineHunger = 0f;
    [HideInInspector] public float bubbleMachineCleanliness = 0f;

    //---------------------------------------------- Hunger ----------------------------------------------//

    [Header("Clam")]
    [HideInInspector] public Sprite clamSprite;
    [HideInInspector] public string clamName = "Shell Fish";
    [HideInInspector] public string clamDescription = "Octomons can eat Shell Fish";
    [HideInInspector] public int clamAmount;
    [HideInInspector] public float clamHappyLevel = 7.5f;
    [HideInInspector] public float clamFun = 0f;
    [HideInInspector] public float clamHunger = 15f;
    [HideInInspector] public float clamCleanliness = 0f;

    [Header("Cooked Fish")]
    [HideInInspector] public Sprite cookedFishSprite;
    [HideInInspector] public string cookedFishName = "Cooked Fish";
    [HideInInspector] public string cookedFishDescription = "Octomons Love to eat Fish!";
    [HideInInspector] public int cookedFishAmount;
    [HideInInspector] public float cookedFishHappyLevel = 17.5f;
    [HideInInspector] public float cookedFishFun = 0f;
    [HideInInspector] public float cookedFishHunger = 35f;
    [HideInInspector] public float cookedFishCleanliness = 0f;

    //---------------------------------------------- Cleanliness ----------------------------------------------//
    [Header("Soap")]
    [HideInInspector] public Sprite soapSprite;
    [HideInInspector] public string soapName = "Soap";
    [HideInInspector] public string soapDescription = "Soap, someone's name?";
    [HideInInspector] public int soapAmount;
    [HideInInspector] public float soapHappyLevel = 7.5f;
    [HideInInspector] public float soapFun = 0f;
    [HideInInspector] public float soapHunger = 0f;
    [HideInInspector] public float soapCleanliness = 15f;

    [Header("Shampoo")]
    [HideInInspector] public Sprite shampooSprite;
    [HideInInspector] public string shampooName = "Shampoo";
    [HideInInspector] public string shampooDescription = "A shampoo bottle, keep your octomons clean!";
    [HideInInspector] public int shampooAmount;
    [HideInInspector] public float shampooHappyLevel = 17.5f;
    [HideInInspector] public float shampooFun = 0f;
    [HideInInspector] public float shampooHunger = 0f;
    [HideInInspector] public float shampooCleanliness = 35f;

    //---------------------------------------------- Random Octomon ----------------------------------------------//
    [Header("Random Octomon")]
    [SerializeField] public Sprite randomOctomonSprite;
    [SerializeField] public string randomOctomonName = "Random Octomon";
    [SerializeField] public string randomOctomonDescription = "Get a new random octomon!";

    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _mobileSaveAndLoadManager.LoadItemSlot(this);
        UpdateItemAmountTMP();
    }
    
    //Item info popup
    public void ItemButtonPressed(string itemName)
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        //Canvas Active
        _itemInfoCanvas.GetComponent<CanvasGroup>().alpha = 1;
        _itemInfoCanvas.GetComponent<CanvasGroup>().interactable = true;
        _itemInfoCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;

        _inventoryCanvas.GetComponent<CanvasGroup>().interactable = false;
        _inventoryCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;


        //Info
        if (itemName == "Plastic Ball")
        {
            //this item stats
            _thisItem_Name = plasticBallName;
            _thisItem_Amount = plasticBallAmount;

            _thisItem_HappyLevel = plasticBallHappyLevel;
            _thisItem_Fun = plasticBallFun;
            _thisItem_Hunger = plasticBallHunger;
            _thisItem_Cleanliness = plasticBallCleanliness;

            //UI
            _itemInfo_ImageSlot.sprite = plasticBallSprite;
            _itemInfo_Name.text = plasticBallName;

            _itemInfo_stats.text =
                $"Happy level +{plasticBallHappyLevel}\r\nFun +{plasticBallFun}\r\nHunger +{plasticBallHunger} \r\nCleanliness +{plasticBallCleanliness}";
            _itemInfo_Description.text = plasticBallDescription;
        }
        else if (itemName == "Bubble Machine")
        {
            //this item stats
            _thisItem_Name = bubbleMachineName;
            _thisItem_Amount = bubbleMachineAmount;

            _thisItem_HappyLevel = bubbleMachineHappyLevel;
            _thisItem_Fun = bubbleMachineFun;
            _thisItem_Hunger = bubbleMachineHunger;
            _thisItem_Cleanliness = bubbleMachineCleanliness;

            //UI
            _itemInfo_ImageSlot.sprite = bubbleMachineSprite;
            _itemInfo_Name.text = bubbleMachineName;

            _itemInfo_stats.text =
                $"Happy level +{bubbleMachineHappyLevel}\r\nFun +{bubbleMachineFun}\r\nHunger +{bubbleMachineHunger} \r\nCleanliness +{bubbleMachineCleanliness}";
            _itemInfo_Description.text = bubbleMachineDescription;
        }
        else if (itemName == "Clam")
        {
            //this item stats
            _thisItem_Name = clamName;
            _thisItem_Amount = clamAmount;

            _thisItem_HappyLevel = clamHappyLevel;
            _thisItem_Fun = clamFun;
            _thisItem_Hunger = clamHunger;
            _thisItem_Cleanliness = clamCleanliness;

            //UI
            _itemInfo_ImageSlot.sprite = clamSprite;
            _itemInfo_Name.text = clamName;

            _itemInfo_stats.text =
                $"Happy level +{clamHappyLevel}\r\nFun +{clamFun}\r\nHunger +{clamHunger} \r\nCleanliness +{clamCleanliness}";
            _itemInfo_Description.text = clamDescription;
        }
        else if (itemName == "Cooked Fish")
        {
            //this item stats
            _thisItem_Name = cookedFishName;
            _thisItem_Amount = cookedFishAmount;

            _thisItem_HappyLevel = cookedFishHappyLevel;
            _thisItem_Fun = cookedFishFun;
            _thisItem_Hunger = cookedFishHunger;
            _thisItem_Cleanliness = cookedFishCleanliness;

            //UI
            _itemInfo_ImageSlot.sprite = cookedFishSprite;
            _itemInfo_Name.text = cookedFishName;

            _itemInfo_stats.text =
                $"Happy level +{cookedFishHappyLevel}\r\nFun +{cookedFishFun}\r\nHunger +{cookedFishHunger} \r\nCleanliness +{cookedFishCleanliness}";
            _itemInfo_Description.text = cookedFishDescription;
        }
        else if (itemName == "Soap")
        {
            //this item stats
            _thisItem_Name = soapName;
            _thisItem_Amount = soapAmount;

            _thisItem_HappyLevel = soapHappyLevel;
            _thisItem_Fun = soapFun;
            _thisItem_Hunger = soapHunger;
            _thisItem_Cleanliness = soapCleanliness;

            //UI
            _itemInfo_ImageSlot.sprite = soapSprite;
            _itemInfo_Name.text = soapName;

            _itemInfo_stats.text =
                $"Happy level +{soapHappyLevel}\r\nFun +{soapFun}\r\nHunger +{soapHunger} \r\nCleanliness +{soapCleanliness}";
            _itemInfo_Description.text = soapDescription;
        }
        else if (itemName == "Shampoo")
        {
            //this item stats
            _thisItem_Name = shampooName;
            _thisItem_Amount = shampooAmount;

            _thisItem_HappyLevel = shampooHappyLevel;
            _thisItem_Fun = shampooFun;
            _thisItem_Hunger = shampooHunger;
            _thisItem_Cleanliness = shampooCleanliness;

            //UI
            _itemInfo_ImageSlot.sprite = shampooSprite;
            _itemInfo_Name.text = shampooName;

            _itemInfo_stats.text =
                $"Happy level +{shampooHappyLevel}\r\nFun +{shampooFun}\r\nHunger +{shampooHunger} \r\nCleanliness +{shampooCleanliness}";
            _itemInfo_Description.text = shampooDescription;
        }
    }

    public void CloseItemInfo()
    {
        //Canvas Deactive
        _itemInfoCanvas.GetComponent<CanvasGroup>().alpha = 0;
        _itemInfoCanvas.GetComponent<CanvasGroup>().interactable = false;
        _itemInfoCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;

        _inventoryCanvas.GetComponent<CanvasGroup>().interactable = true;
        _inventoryCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void ItemUseButton()
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        if (_thisItem_Amount > 0)
        {
            CloseItemInfo();
            BackToMainMenuButton();

            if (_thisItem_Name == plasticBallName)
            {
                _profileScript.AddExperience(6);
                plasticBallAmount -= 1;
            }
            else if (_thisItem_Name == bubbleMachineName)
            {
                _profileScript.AddExperience(14);
                bubbleMachineAmount -= 1;
            }
            else if (_thisItem_Name == clamName)
            {
                _profileScript.AddExperience(6);
                clamAmount -= 1;
            }
            else if (_thisItem_Name == cookedFishName)
            {
                _profileScript.AddExperience(14);
                cookedFishAmount -= 1;
            }
            else if (_thisItem_Name == soapName)
            {
                _profileScript.AddExperience(6);
                soapAmount -= 1;
            }
            else if (_thisItem_Name == shampooName)
            {
                _profileScript.AddExperience(14);
                shampooAmount -= 1;
            }

            for (int i = 0; i < _octomonSlot.octomonSlots.Count; i++)
            {
                if (_octomonSlot.octomonSlots[i].octomonActiveStatus)
                {
                    _octomonSlot.octomonSlots[i].octomonCurrentHappyLevel += _thisItem_HappyLevel;
                    _octomonSlot.octomonSlots[i].octomonCurrentFun += _thisItem_Fun;
                    _octomonSlot.octomonSlots[i].octomonCurrentHunger += _thisItem_Hunger;
                    _octomonSlot.octomonSlots[i].octomonCurrentCleanliness += _thisItem_Cleanliness;

                    if (_octomonSlot.octomonSlots[i].octomonCurrentHappyLevel >=
                        _octomonSlot.octomonSlots[i].octomonMaxHappyLevel)
                    {
                        _octomonSlot.octomonSlots[i].octomonCurrentHappyLevel =
                            _octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                    }
                    if (_octomonSlot.octomonSlots[i].octomonCurrentFun >=
                        _octomonSlot.octomonSlots[i].octomonMaxFun)
                    {
                        _octomonSlot.octomonSlots[i].octomonCurrentFun =
                            _octomonSlot.octomonSlots[i].octomonMaxFun;
                    }
                    if (_octomonSlot.octomonSlots[i].octomonCurrentHunger >=
                        _octomonSlot.octomonSlots[i].octomonMaxHunger)
                    {
                        _octomonSlot.octomonSlots[i].octomonCurrentHunger =
                            _octomonSlot.octomonSlots[i].octomonMaxHunger;
                    }
                    if (_octomonSlot.octomonSlots[i].octomonCurrentCleanliness >=
                        _octomonSlot.octomonSlots[i].octomonMaxCleanliness)
                    {
                        _octomonSlot.octomonSlots[i].octomonCurrentCleanliness =
                            _octomonSlot.octomonSlots[i].octomonMaxCleanliness;
                    }
                }
            }

            UpdateItemAmountTMP();
        }
        else if (_thisItem_Amount <= 0)
        {
            print("You don't have this item!");
        }
        _mobileSaveAndLoadManager.SaveItemSlot(this);
        _mobileSaveAndLoadManager.SaveOctomonSlot(_octomonSlot);
    }

    //Update the item amount on text
    public void UpdateItemAmountTMP()
    {
        _plasticBallAmountTMP.text = plasticBallAmount.ToString();
        _bubbleMachineAmountTMP.text = bubbleMachineAmount.ToString();
        _clamAmountTMP.text = clamAmount.ToString();
        _cookedFishAmountTMP.text = cookedFishAmount.ToString();
        _soapAmountTMP.text = soapAmount.ToString();
        _shampooAmountTMP.text = shampooAmount.ToString();
    }

    //Back button
    public void BackToMainMenuButton()
    {
        GameObject inventoryPage = GameObject.FindWithTag("InventoryPage");
        
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

        GameObject.FindWithTag("InventoryCanvas").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.FindWithTag("InventoryCanvas").GetComponent<CanvasGroup>().interactable = false;
        GameObject.FindWithTag("InventoryCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

        inventoryPage.transform.localScale = Vector2.zero;
    }
}