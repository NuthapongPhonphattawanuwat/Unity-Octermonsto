using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject _ShopCanvas;
    [SerializeField] private GameObject _itemInfoCanvas;

    [Header("Scripts")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MobileSaveAndLoadManager _mobileSaveAndLoadManager;
    [SerializeField] private CurrenciesScript _currenciesScript;
    [SerializeField] private ItemSlot _itemSlot;
    [SerializeField] private OctomonSlot _octomonSlot;
    

    [Header("Items price TMPs")]
    [SerializeField] private TextMeshProUGUI _plasticBallPriceTMP;
    [SerializeField] private TextMeshProUGUI _bubbleMachinePriceTMP;
    [SerializeField] private TextMeshProUGUI _clamPriceTMP;
    [SerializeField] private TextMeshProUGUI _cookedFishPriceTMP;
    [SerializeField] private TextMeshProUGUI _soapPriceTMP;
    [SerializeField] private TextMeshProUGUI _shampooPriceTMP;

    [HideInInspector] public int plasticBallPricePearl = 10;
    [HideInInspector] public int bubbleMachinePricePearl = 20;
    [HideInInspector] public int clamPricePearl = 10;
    [HideInInspector] public int cookedFishPricePearl = 20;
    [HideInInspector] public int soapPricePearl = 10;
    [HideInInspector] public int shampooPricePearl = 20;
    [HideInInspector] public int randomOctomonPricePearl = 30;

    [Header("Item info Canvas")]
    [SerializeField] private Image _itemInfo_ImageSlot;
    [SerializeField] private TextMeshProUGUI _itemInfo_Price;
    [SerializeField] private TextMeshProUGUI _itemInfo_Name;
    [SerializeField] private TextMeshProUGUI _itemInfo_stats;
    [SerializeField] private TextMeshProUGUI _itemInfo_Description;
    [SerializeField] private TextMeshProUGUI _itemInfo_Noti;
    [SerializeField] private GameObject _itemInfo_NotiBackground;

    [SerializeField] private TextMeshProUGUI _itemInfo_BigDescription;

    private string _thisItem_Name;
    private int _thisItem_Amount;
    private int _thisItem_Price_Pearl;
    private string _thisItem_Description;
    private float _thisItem_HappyLevel;
    private float _thisItem_Fun;
    private float _thisItem_Hunger;
    private float _thisItem_Cleanliness;

    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _plasticBallPriceTMP.text = plasticBallPricePearl.ToString();
        _bubbleMachinePriceTMP.text = bubbleMachinePricePearl.ToString();
        _clamPriceTMP.text = clamPricePearl.ToString();
        _cookedFishPriceTMP.text = cookedFishPricePearl.ToString();
        _soapPriceTMP.text = soapPricePearl.ToString();
        _shampooPriceTMP.text = shampooPricePearl.ToString();
    }

    public void ShopItemPressed(string itemName)
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        //Canvas Active
        _itemInfoCanvas.GetComponent<CanvasGroup>().alpha = 1;
        _itemInfoCanvas.GetComponent<CanvasGroup>().interactable = true;
        _itemInfoCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;

        _ShopCanvas.GetComponent<CanvasGroup>().interactable = false;
        _ShopCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;

        _itemSlot.UpdateItemAmountTMP();
        if (itemName == "Plastic Ball")
        {
            //this item stats
            _thisItem_Name = _itemSlot.plasticBallName;
            _thisItem_Amount = _itemSlot.plasticBallAmount;
            _thisItem_Description = _itemSlot.plasticBallDescription;
            _thisItem_HappyLevel = _itemSlot.plasticBallHappyLevel;
            _thisItem_Fun = _itemSlot.plasticBallFun;
            _thisItem_Hunger = _itemSlot.plasticBallHunger;
            _thisItem_Cleanliness = _itemSlot.plasticBallCleanliness;
            _thisItem_Price_Pearl = plasticBallPricePearl;
            //UI
            _itemInfo_ImageSlot.sprite = _itemSlot.plasticBallSprite;
            _itemInfo_Name.text = $"{_thisItem_Name} : {_thisItem_Amount}";

            _itemInfo_stats.text =
                $"Happy level +{_thisItem_HappyLevel}\r\nFun +{_thisItem_Fun}\r\nHunger +{_thisItem_Hunger} \r\nCleanliness +{_thisItem_Cleanliness}";
            _itemInfo_Description.text = _thisItem_Description;
        }
        else if (itemName == "Bubble Machine")
        {
            //this item stats
            _thisItem_Name = _itemSlot.bubbleMachineName;
            _thisItem_Amount = _itemSlot.bubbleMachineAmount;
            _thisItem_Description = _itemSlot.bubbleMachineDescription;
            _thisItem_HappyLevel = _itemSlot.bubbleMachineHappyLevel;
            _thisItem_Fun = _itemSlot.bubbleMachineFun;
            _thisItem_Hunger = _itemSlot.bubbleMachineHunger;
            _thisItem_Cleanliness = _itemSlot.bubbleMachineCleanliness;
            _thisItem_Price_Pearl = bubbleMachinePricePearl;
            //UI
            _itemInfo_ImageSlot.sprite = _itemSlot.bubbleMachineSprite;
            _itemInfo_Name.text = $"{_thisItem_Name} : {_thisItem_Amount}";

            _itemInfo_stats.text =
                $"Happy level +{_thisItem_HappyLevel}\r\nFun +{_thisItem_Fun}\r\nHunger +{_thisItem_Hunger} \r\nCleanliness +{_thisItem_Cleanliness}";
            _itemInfo_Description.text = _thisItem_Description;
        }
        else if (itemName == "Clam")
        {
            //this item stats
            _thisItem_Name = _itemSlot.clamName;
            _thisItem_Amount = _itemSlot.clamAmount;
            _thisItem_Description = _itemSlot.clamDescription;
            _thisItem_HappyLevel = _itemSlot.clamHappyLevel;
            _thisItem_Fun = _itemSlot.clamFun;
            _thisItem_Hunger = _itemSlot.clamHunger;
            _thisItem_Cleanliness = _itemSlot.clamCleanliness;
            _thisItem_Price_Pearl = clamPricePearl;
            //UI
            _itemInfo_ImageSlot.sprite = _itemSlot.clamSprite;
            _itemInfo_Name.text = $"{_thisItem_Name} : {_thisItem_Amount}";

            _itemInfo_stats.text =
                $"Happy level +{_thisItem_HappyLevel}\r\nFun +{_thisItem_Fun}\r\nHunger +{_thisItem_Hunger} \r\nCleanliness +{_thisItem_Cleanliness}";
            _itemInfo_Description.text = _thisItem_Description;
        }
        else if (itemName == "Cooked Fish")
        {
            //this item stats
            _thisItem_Name = _itemSlot.cookedFishName;
            _thisItem_Amount = _itemSlot.cookedFishAmount;
            _thisItem_Description = _itemSlot.cookedFishDescription;
            _thisItem_HappyLevel = _itemSlot.cookedFishHappyLevel;
            _thisItem_Fun = _itemSlot.cookedFishFun;
            _thisItem_Hunger = _itemSlot.cookedFishHunger;
            _thisItem_Cleanliness = _itemSlot.cookedFishCleanliness;
            _thisItem_Price_Pearl = cookedFishPricePearl;
            //UI
            _itemInfo_ImageSlot.sprite = _itemSlot.cookedFishSprite;
            _itemInfo_Name.text = $"{_thisItem_Name} : {_thisItem_Amount}";

            _itemInfo_stats.text =
                $"Happy level +{_thisItem_HappyLevel}\r\nFun +{_thisItem_Fun}\r\nHunger +{_thisItem_Hunger} \r\nCleanliness +{_thisItem_Cleanliness}";
            _itemInfo_Description.text = _thisItem_Description;
        }
        else if (itemName == "Soap")
        {
            //this item stats
            _thisItem_Name = _itemSlot.soapName;
            _thisItem_Amount = _itemSlot.soapAmount;
            _thisItem_Description = _itemSlot.soapDescription;
            _thisItem_HappyLevel = _itemSlot.soapHappyLevel;
            _thisItem_Fun = _itemSlot.soapFun;
            _thisItem_Hunger = _itemSlot.soapHunger;
            _thisItem_Cleanliness = _itemSlot.soapCleanliness;
            _thisItem_Price_Pearl = soapPricePearl;
            //UI
            _itemInfo_ImageSlot.sprite = _itemSlot.soapSprite;
            _itemInfo_Name.text = $"{_thisItem_Name} : {_thisItem_Amount}";

            _itemInfo_stats.text =
                $"Happy level +{_thisItem_HappyLevel}\r\nFun +{_thisItem_Fun}\r\nHunger +{_thisItem_Hunger} \r\nCleanliness +{_thisItem_Cleanliness}";
            _itemInfo_Description.text = _thisItem_Description;
        }
        else if (itemName == "Shampoo")
        {
            //this item stats
            _thisItem_Name = _itemSlot.shampooName;
            _thisItem_Amount = _itemSlot.shampooAmount;
            _thisItem_Description = _itemSlot.shampooDescription;
            _thisItem_HappyLevel = _itemSlot.shampooHappyLevel;
            _thisItem_Fun = _itemSlot.shampooFun;
            _thisItem_Hunger = _itemSlot.shampooHunger;
            _thisItem_Cleanliness = _itemSlot.shampooCleanliness;
            _thisItem_Price_Pearl = shampooPricePearl;
            //UI
            _itemInfo_ImageSlot.sprite = _itemSlot.shampooSprite;
            _itemInfo_Name.text = $"{_thisItem_Name} : {_thisItem_Amount}";

            _itemInfo_stats.text =
                $"Happy level +{_thisItem_HappyLevel}\r\nFun +{_thisItem_Fun}\r\nHunger +{_thisItem_Hunger} \r\nCleanliness +{_thisItem_Cleanliness}";
            _itemInfo_Description.text = _thisItem_Description;
        }
        else if (itemName == "Random Octomon")
        {
            _thisItem_Name = _itemSlot.randomOctomonName;
            _thisItem_Description = _itemSlot.randomOctomonDescription;
            _thisItem_Price_Pearl = randomOctomonPricePearl;

            _itemInfo_ImageSlot.sprite = _itemSlot.randomOctomonSprite;
            _itemInfo_Name.text = _thisItem_Name;
            _itemInfo_BigDescription.text = _thisItem_Description;
        }

        _itemInfo_Price.text = _thisItem_Price_Pearl.ToString();
    }

    public void BuyButton()
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        if (_thisItem_Price_Pearl <= _currenciesScript.pearl)
        {
            if (_thisItem_Name == _itemSlot.plasticBallName)
            {
                _itemSlot.plasticBallAmount += 1;
                _currenciesScript.RemoveCurrencies(_thisItem_Price_Pearl, 0);
                StopCoroutine(Delay());
                StartCoroutine(Delay());
            }
            else if (_thisItem_Name == _itemSlot.bubbleMachineName)
            {
                _itemSlot.bubbleMachineAmount += 1;
                _currenciesScript.RemoveCurrencies(_thisItem_Price_Pearl, 0);
                StopCoroutine(Delay());
                StartCoroutine(Delay());
            }
            else if (_thisItem_Name == _itemSlot.clamName)
            {
                _itemSlot.clamAmount += 1;
                _currenciesScript.RemoveCurrencies(_thisItem_Price_Pearl, 0);
                StopCoroutine(Delay());
                StartCoroutine(Delay());
            }
            else if (_thisItem_Name == _itemSlot.cookedFishName)
            {
                _itemSlot.cookedFishAmount += 1;
                _currenciesScript.RemoveCurrencies(_thisItem_Price_Pearl, 0);
                StopCoroutine(Delay());
                StartCoroutine(Delay());
            }
            else if (_thisItem_Name == _itemSlot.soapName)
            {
                _itemSlot.soapAmount += 1;
                _currenciesScript.RemoveCurrencies(_thisItem_Price_Pearl, 0);
                StopCoroutine(Delay());
                StartCoroutine(Delay());
            }
            else if (_thisItem_Name == _itemSlot.shampooName)
            {
                _itemSlot.shampooAmount += 1;
                _currenciesScript.RemoveCurrencies(_thisItem_Price_Pearl, 0);
                StopCoroutine(Delay());
                StartCoroutine(Delay());
            }
            else if (_thisItem_Name == _itemSlot.randomOctomonName)
            {
                if (_octomonSlot.octomonSlots[_octomonSlot.octomonSlots.Count - 1].octomonSprite != null) //_octomonSlot.octomonSlots[9].octomonName != "")
                {
                    print($"{_octomonSlot.octomonSlots.Count}");
                    StopCoroutine(DelayRandomOctomon());
                    StartCoroutine(DelayRandomOctomon());

                    IEnumerator DelayRandomOctomon()
                    {
                        _currenciesScript.UpdateCurrenciesText();
                        _itemInfo_Noti.text = _itemInfo_Noti.text = $"Your Octomon Inventory is full!";
                        _itemInfo_Noti.color = Color.red;
                        _itemInfo_NotiBackground.SetActive(true);
                        yield return new WaitForSeconds(2);
                        _itemInfo_Noti.text = "";
                        _itemInfo_NotiBackground.SetActive(false);
                    }
                }
                else
                {
                    //Random
                    _octomonSlot.BasicRandomOctomon();
                    _currenciesScript.RemoveCurrencies(_thisItem_Price_Pearl,0);

                    StopCoroutine(Delay());
                    StartCoroutine(Delay());
                }
            }
            //print((_thisItem_Name));
            //print($"You bought 1 {_thisItem_Name} for {_thisItem_Price_Pearl} pearl");

            IEnumerator Delay()
            {
                _itemInfo_Noti.text = _itemInfo_Noti.text = $"You bought 1 {_thisItem_Name} for {_thisItem_Price_Pearl} pearl";
                _itemInfo_Noti.color = Color.green;
                _itemInfo_NotiBackground.SetActive(true);
                yield return new WaitForSeconds(2);
                _itemInfo_Noti.text = "";
                _itemInfo_NotiBackground.SetActive(false);
            }
        }
        else if (_thisItem_Price_Pearl > _currenciesScript.pearl)
        {
            StopAllCoroutines();
            StartCoroutine(Delay());
            print("Not Enough Pearl");

            IEnumerator Delay()
            {
                _currenciesScript.UpdateCurrenciesText();
                _itemInfo_Noti.text = "Not enough pearl!";
                _itemInfo_Noti.color = Color.red;
                _itemInfo_NotiBackground.SetActive(true);
                yield return new WaitForSeconds(2);
                _itemInfo_Noti.text = "";
                _itemInfo_NotiBackground.SetActive(false);
            }
        }

        _itemSlot.UpdateItemAmountTMP();

        _mobileSaveAndLoadManager.SaveCurrenciesScript(_currenciesScript);
        _mobileSaveAndLoadManager.SaveItemSlot(_itemSlot);
    }

    public void BackToMainMenuButton()
    {
        GameObject shopPage = GameObject.FindWithTag("ShopPage");
        
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

        GameObject.FindWithTag("ShopCanvas").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.FindWithTag("ShopCanvas").GetComponent<CanvasGroup>().interactable = false;
        GameObject.FindWithTag("ShopCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        
        shopPage.transform.localScale = Vector2.zero;
    }

    public void CloseItemInfo()
    {
        
        
        _itemInfo_BigDescription.text = "";
        _itemInfo_Description.text = "";
        _itemInfo_stats.text = "";
        //Canvas Deactive
        _itemInfoCanvas.GetComponent<CanvasGroup>().alpha = 0;
        _itemInfoCanvas.GetComponent<CanvasGroup>().interactable = false;
        _itemInfoCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;

        _ShopCanvas.GetComponent<CanvasGroup>().interactable = true;
        _ShopCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;

        
    }
}