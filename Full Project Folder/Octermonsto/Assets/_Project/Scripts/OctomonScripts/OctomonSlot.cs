using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OctomonSlot : MonoBehaviour//, IDataPersistence
{
    [Header("Canvas")]
    [SerializeField] private GameObject _octomonInventoryCanvas;
    [SerializeField] private GameObject _octomonStatCanvas;

    [Header("Scripts")]
    [SerializeField] private MobileSaveAndLoadManager _mobileSaveAndLoadManager;
    [SerializeField] private ActiveOctomonController _activeOctomonController; 
    [SerializeField] private OctomonData _octomonData;
    [SerializeField] private ProfileScript _profileScript;
    [SerializeField] private AudioManager _audioManager;

    //------------------------------------Active Octomon info------------------------------------//
    [Header("Active Octomon Info")]
    public RuntimeAnimatorController activeOctomonAnimatorCTRL;

    public bool octomonActive = false;
    public string activeOctomonName;

    public float activeOctomonMaxHappyLevel;
    public float activeOctomonMaxFun;
    public float activeOctomonMaxHunger;
    public float activeOctomonMaxCleanliness;

    public float activeOctomonCurrentHappyLevel;
    public float activeOctomonCurrentFun;
    public float activeOctomonCurrentHunger;
    public float activeOctomonCurrentCleanliness;

    [Header("Active Octomon Emotions")]
    [SerializeField] private Image _emotionImage;
    [SerializeField] private Sprite _empty;

    [SerializeField] private Sprite _angry;
    [SerializeField] private Sprite _dirty;
    [SerializeField] private Sprite _happy;
    [SerializeField] private Sprite _hungry;
    [SerializeField] private Sprite _sad;

    //------------------------------------Octomon slots------------------------------------//

    public List<OctomonSlotClass> octomonSlots = new List<OctomonSlotClass>();
    
    //------------------------------------Octomon Stats Canvas------------------------------------//
    [Header("Octomon Stats Canvas")]
    private int _thisOctomonSlotNum;

    [SerializeField] private TextMeshProUGUI _octomonStat_NotificationTMP;

    [SerializeField] private Image _OctomonStat_ImageSlot;
    [SerializeField] private TextMeshProUGUI _OctomonStat_Name; 
    [SerializeField] private TextMeshProUGUI _OctomonStat_Stats;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _octomonData = GameObject.FindWithTag("Octomon Data").GetComponent<OctomonData>();
        _activeOctomonController = GameObject.FindWithTag("Active Octomon Controller").GetComponent<ActiveOctomonController>();
        _mobileSaveAndLoadManager.LoadOctomonSlot(this);

        for (int i = 0; i < octomonSlots.Count; i++)
        {
            if (octomonSlots[i].octomonSprite == null)
            {
                octomonSlots[i].slot.SetActive(false);
            }
        }

        //ActiveOctomon's emotions check loop
        StartCoroutine(ActiveOctomonEmotionCheck());
        IEnumerator ActiveOctomonEmotionCheck()
        {
            yield return new WaitForSeconds(3);
            _emotionImage.enabled = false;
            yield return new WaitForSeconds(7);
            if (activeOctomonCurrentHappyLevel >= (activeOctomonMaxHappyLevel * 0.75f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _happy;
            }
            else if (activeOctomonCurrentFun <= (activeOctomonMaxFun * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _angry;
            }
            else if (activeOctomonCurrentHunger <= (activeOctomonMaxHunger * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _hungry;
            }
            else if (activeOctomonCurrentCleanliness <= (activeOctomonMaxCleanliness * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _dirty;
            }
            else
            {
                _emotionImage.enabled = false;
            }

            yield return new WaitForSeconds(3);
            _emotionImage.enabled = false;
            yield return new WaitForSeconds(7);

            if (activeOctomonCurrentFun <= (activeOctomonMaxFun * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _angry;
            }
            else if (activeOctomonCurrentHunger <= (activeOctomonMaxHunger * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _hungry;
            }
            else if (activeOctomonCurrentCleanliness <= (activeOctomonMaxCleanliness * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _dirty;
            }
            else if (activeOctomonCurrentHappyLevel >= (activeOctomonMaxHappyLevel * 0.75f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _happy;
            }
            else
            {
                _emotionImage.enabled = false;
            }

            yield return new WaitForSeconds(3);
            _emotionImage.enabled = false;
            yield return new WaitForSeconds(7);

            if (activeOctomonCurrentHunger <= (activeOctomonMaxHunger * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _hungry;
            }
            else if (activeOctomonCurrentCleanliness <= (activeOctomonMaxCleanliness * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _dirty;
            }
            else if (activeOctomonCurrentHappyLevel >= (activeOctomonMaxHappyLevel * 0.75f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _happy;
            }
            else if (activeOctomonCurrentFun <= (activeOctomonMaxFun * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _angry;
            }
            else
            {
                _emotionImage.enabled = false;
            }

            yield return new WaitForSeconds(3);
            _emotionImage.enabled = false;
            yield return new WaitForSeconds(7);

            if (activeOctomonCurrentCleanliness <= (activeOctomonMaxCleanliness * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _dirty;
            }
            else if (activeOctomonCurrentHappyLevel >= (activeOctomonMaxHappyLevel * 0.75f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _happy;
            }
            else if (activeOctomonCurrentFun <= (activeOctomonMaxFun * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _angry;
            }
            else if (activeOctomonCurrentHunger <= (activeOctomonMaxHunger * 0.3f))
            {
                _emotionImage.enabled = true;
                _emotionImage.sprite = _hungry;
            }
            else
            {
                _emotionImage.enabled = false;
            }

            //continue the loop
            StartCoroutine(ActiveOctomonEmotionCheck());
        }
    }

    private void Update()
    {
        for (int i = 0; i < octomonSlots.Count; i++)
        {
            if (octomonSlots[i].octomonActiveStatus)
            {
                octomonSlots[i].octomonCurrentHappyLevel -= 0.0001f;
                if (octomonSlots[i].octomonCurrentHappyLevel <= 0)
                {
                    octomonSlots[i].octomonCurrentHappyLevel = 0;
                }
                octomonSlots[i].octomonCurrentFun -= 0.0001f;
                if (octomonSlots[i].octomonCurrentFun <= 0)
                {
                    octomonSlots[i].octomonCurrentFun = 0;
                }
                octomonSlots[i].octomonCurrentHunger -= 0.0001f;
                if (octomonSlots[i].octomonCurrentHunger <= 0)
                {
                    octomonSlots[i].octomonCurrentHunger = 0;
                }
                octomonSlots[i].octomonCurrentCleanliness -= 0.0001f;
                if (octomonSlots[i].octomonCurrentCleanliness <= 0)
                {
                    octomonSlots[i].octomonCurrentCleanliness = 0;
                }

                activeOctomonCurrentHappyLevel = octomonSlots[i].octomonCurrentHappyLevel;
                activeOctomonCurrentFun = octomonSlots[i].octomonCurrentFun;
                activeOctomonCurrentHunger = octomonSlots[i].octomonCurrentHunger;
                activeOctomonCurrentCleanliness = octomonSlots[i].octomonCurrentCleanliness;
                break;
            }
        }
    }

    //Random Octomon Method
    public void BasicRandomOctomon()
    {
        //Variable "x"
        int x = 0;

        //random x depend on player level
        if (_profileScript.playerLevel >= 15)
        {
            x = Random.Range(1, 101);
        }
        else if (_profileScript.playerLevel >= 9)
        {
            x = Random.Range(1, 96);
        }
        else if (_profileScript.playerLevel >= 5)
        {
            x = Random.Range(1, 84);
        }
        else if (_profileScript.playerLevel >= 1)
        {
            x = Random.Range(1, 49);
        }

        //Octomon rarity depend on "x"
        //Uncommon
        if (x >= 1 && x <= 48)
        {
            //Random octomon in this rarity again
            x = Random.Range(1, 4);

            if (x == 1)
            {
                NewOctomonAdd(_octomonData.roundName, _octomonData.roundAnimatorCTRL, _octomonData.roundSprite,
                    _octomonData.roundBaseHappyLevel, _octomonData.roundBaseFun, _octomonData.roundBaseHunger,
                    _octomonData.roundBaseCleanliness);
                Debug.Log("You got round octomon!");
            }
            else if (x == 2)
            {
                NewOctomonAdd(_octomonData.pointyName, _octomonData.pointyAnimatorCTRL, _octomonData.pointySprite,
                    _octomonData.pointyBaseHappyLevel, _octomonData.pointyBaseFun, _octomonData.pointyBaseHunger,
                    _octomonData.pointyBaseCleanliness);
                Debug.Log("You got pointy octomon!");
            }
            else if (x == 3)
            {
                NewOctomonAdd(_octomonData.buttonName, _octomonData.buttonAnimatorCTRL, _octomonData.buttonSprite,
                    _octomonData.buttonBaseHappyLevel, _octomonData.buttonBaseFun, _octomonData.buttonBaseHunger,
                    _octomonData.buttonBaseCleanliness);
                Debug.Log("You got button octomon!");
            }
            _profileScript.AddExperience(50);
        }
        //Superior
        else if (x >= 49 && x <= 83 && _profileScript.playerLevel >= 5)
        {
            //Random octomon in this rarity again
            x = Random.Range(1, 4);
            if (x == 1)
            {
                NewOctomonAdd(_octomonData.strawberryName, _octomonData.strawberryAnimatorCTRL, _octomonData.strawberrySprite,
                    _octomonData.strawberryBaseHappyLevel, _octomonData.strawberryBaseFun, _octomonData.strawberryBaseHunger,
                    _octomonData.strawberryBaseCleanliness);
                Debug.Log("You got strawberry octomon!");
            }
            else if (x == 2)
            {
                NewOctomonAdd(_octomonData.cactusName, _octomonData.cactusAnimatorCTRL, _octomonData.cactusSprite,
                    _octomonData.cactusBaseHappyLevel, _octomonData.cactusBaseFun, _octomonData.cactusBaseHunger,
                    _octomonData.cactusBaseCleanliness);
                Debug.Log("You got cactus octomon!");
            }
            else if (x == 3)
            {
                NewOctomonAdd(_octomonData.devilName, _octomonData.devilAnimatorCTRL, _octomonData.devilSprite,
                    _octomonData.devilBaseHappyLevel, _octomonData.devilBaseFun, _octomonData.devilBaseHunger,
                    _octomonData.devilBaseCleanliness);
                Debug.Log("You got devil octomon!");
            }
            _profileScript.AddExperience(100);
        }
        //Legendary
        else if (x >= 84 && x <= 95 && _profileScript.playerLevel >= 9)
        {
            //Random octomon in this rarity again
            x = Random.Range(1, 3);
            if (x == 1)
            {
                NewOctomonAdd(_octomonData.mummyName, _octomonData.mummyAnimatorCTRL, _octomonData.mummySprite,
                    _octomonData.mummyBaseHappyLevel, _octomonData.mummyBaseFun, _octomonData.mummyBaseHunger,
                    _octomonData.mummyBaseCleanliness);
                Debug.Log("You got mummy octomon!");
            }
            else if (x == 2)
            {
                NewOctomonAdd(_octomonData.pumpkinName, _octomonData.pumpkinAnimatorCTRL, _octomonData.pumpkinSprite,
                    _octomonData.pumpkinBaseHappyLevel, _octomonData.pumpkinBaseFun, _octomonData.pumpkinBaseHunger,
                    _octomonData.pumpkinBaseCleanliness);
                Debug.Log("You got pumpkin octomon!");
            }
            _profileScript.AddExperience(175);
        }
        //Divine
        else if (x >= 96 && x <= 100 && _profileScript.playerLevel >= 15)
        {
            x=Random.Range(1, 2);
            if (x == 1)
            {
                //Random octomon in this rarity again
                NewOctomonAdd(_octomonData.takoName, _octomonData.takoAnimatorCTRL, _octomonData.takoSprite,
                    _octomonData.takoBaseHappyLevel, _octomonData.takoBaseFun, _octomonData.takoBaseHunger,
                    _octomonData.takoBaseCleanliness);
                Debug.Log("You got tako octomon!");
            }
            _profileScript.AddExperience(375);
        }

        //Save OctomonSlot script
        _mobileSaveAndLoadManager.SaveOctomonSlot(this);
    }

    //Method to add new octomon, also use for load system
    public void NewOctomonAdd(string name, RuntimeAnimatorController animatorController, Sprite sprite, float happyLevel, float fun, float hunger, float cleanliness) 
    {
        for (int i = 0; i < octomonSlots.Count; i++)
        {
            if (octomonSlots[i].octomonSprite == null)
            {
                octomonSlots[i].slot.SetActive(true);
                octomonSlots[i].octomonName = name;
                octomonSlots[i].octomonAnimatorCTRL = animatorController;
                octomonSlots[i].octomonSprite = sprite;

                octomonSlots[i].octomonMaxHappyLevel = happyLevel;
                octomonSlots[i].octomonMaxFun = fun;
                octomonSlots[i].octomonMaxHunger = hunger;
                octomonSlots[i].octomonMaxCleanliness = cleanliness;

                octomonSlots[i].octomonCurrentHappyLevel = happyLevel;
                octomonSlots[i].octomonCurrentFun = fun;
                octomonSlots[i].octomonCurrentHunger = hunger;
                octomonSlots[i].octomonCurrentCleanliness = cleanliness;
                
                octomonSlots[i].octomonNameTMP.text = name;
                octomonSlots[i].octomonImage.sprite = sprite;
                break;
            }
        }
    }

    //Only for first time playing
    public void OctomonActive(int octomonSlotNum)
    {
        activeOctomonAnimatorCTRL = octomonSlots[octomonSlotNum].octomonAnimatorCTRL;
        _activeOctomonController.octomonSlot.GetComponent<Animator>().runtimeAnimatorController = activeOctomonAnimatorCTRL;
        octomonActive = true;
        octomonSlots[octomonSlotNum].octomonActiveStatus = true;
        activeOctomonName = octomonSlots[octomonSlotNum].octomonName;
        
        activeOctomonMaxHappyLevel = octomonSlots[octomonSlotNum].octomonMaxHappyLevel;
        activeOctomonMaxFun = octomonSlots[octomonSlotNum].octomonMaxFun;
        activeOctomonMaxHunger = octomonSlots[octomonSlotNum].octomonMaxHunger;
        activeOctomonMaxCleanliness = octomonSlots[octomonSlotNum].octomonMaxCleanliness;

        activeOctomonCurrentHappyLevel = octomonSlots[octomonSlotNum].octomonCurrentHappyLevel;
        activeOctomonCurrentFun = octomonSlots[octomonSlotNum].octomonCurrentFun;
        activeOctomonCurrentHunger = octomonSlots[octomonSlotNum].octomonCurrentHunger;
        activeOctomonCurrentCleanliness = octomonSlots[octomonSlotNum].octomonCurrentCleanliness;

        Debug.Log($"OctomonSlot {octomonSlotNum} Activated");
    }

    //Buttons
    //Pressed any slot in octomon inventory to open OctomonStatCanvas
    public void OctomonSlotPressed(int octomonSlotNum)
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        _thisOctomonSlotNum = octomonSlotNum;

        //Canvas Active
        _octomonStatCanvas.GetComponent<CanvasGroup>().alpha = 1;
        _octomonStatCanvas.GetComponent<CanvasGroup>().interactable = true;
        _octomonStatCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;

        _octomonInventoryCanvas.GetComponent<CanvasGroup>().interactable = false;
        _octomonInventoryCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
        //Stats
        _OctomonStat_ImageSlot.sprite = octomonSlots[octomonSlotNum].octomonSprite;
        _OctomonStat_Name.text = octomonSlots[octomonSlotNum].octomonName;
        _OctomonStat_Stats.text =
            $"Happy level : {(int)octomonSlots[octomonSlotNum].octomonCurrentHappyLevel}/{(int)octomonSlots[octomonSlotNum].octomonMaxHappyLevel} \r\nFun : {(int)octomonSlots[octomonSlotNum].octomonCurrentFun}/{(int)octomonSlots[octomonSlotNum].octomonMaxFun} \r\nHunger : {(int)octomonSlots[octomonSlotNum].octomonCurrentHunger}/{(int)octomonSlots[octomonSlotNum].octomonMaxHunger} \r\nCleanliness : {(int)octomonSlots[octomonSlotNum].octomonCurrentCleanliness}/{(int)octomonSlots[octomonSlotNum].octomonMaxCleanliness}";

        //octomonStats.text = $"Happy level : {_activeOctomonCurrentHappyLevel}/{_activeOctomonMaxHappyLevel} \r\nFun : {_activeOctomonCurrentFun}/{_activeOctomonMaxFun} \r\nHunger : {_activeOctomonCurrentHunger}/{_activeOctomonMaxHunger} \r\nCleanliness : {_activeOctomonCurrentCleanliness}/{_activeOctomonMaxCleanliness}";
    }
    //Active octomon button
    public void OctomonSlotActive()
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        StopAllCoroutines();
        StartCoroutine(ActiveText());

        activeOctomonAnimatorCTRL = octomonSlots[_thisOctomonSlotNum].octomonAnimatorCTRL;
        _activeOctomonController.octomonSlot.GetComponent<Animator>().runtimeAnimatorController = activeOctomonAnimatorCTRL;
        octomonActive = true;
        octomonSlots[_thisOctomonSlotNum].octomonActiveStatus = true;
        activeOctomonName = octomonSlots[_thisOctomonSlotNum].octomonName;

        activeOctomonMaxHappyLevel = octomonSlots[_thisOctomonSlotNum].octomonMaxHappyLevel;
        activeOctomonMaxFun = octomonSlots[_thisOctomonSlotNum].octomonMaxFun;
        activeOctomonMaxHunger = octomonSlots[_thisOctomonSlotNum].octomonMaxHunger;
        activeOctomonMaxCleanliness = octomonSlots[_thisOctomonSlotNum].octomonMaxCleanliness;

        activeOctomonCurrentHappyLevel = octomonSlots[_thisOctomonSlotNum].octomonCurrentHappyLevel;
        activeOctomonCurrentFun = octomonSlots[_thisOctomonSlotNum].octomonCurrentFun;
        activeOctomonCurrentHunger = octomonSlots[_thisOctomonSlotNum].octomonCurrentHunger;
        activeOctomonCurrentCleanliness = octomonSlots[_thisOctomonSlotNum].octomonCurrentCleanliness;

        Debug.Log($"OctomonSlot {_thisOctomonSlotNum} Activated");
        
        IEnumerator ActiveText()
        {
            _octomonStat_NotificationTMP.text = $"{octomonSlots[_thisOctomonSlotNum].octomonName} is now waiting for you \r\nat the lobby!";

            _octomonStat_NotificationTMP.color = new Color(12 / 255f, 188 / 255f, 13 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(0, 92 / 255f, 1 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(12 / 255f, 188 / 255f, 13 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(0, 92 / 255f, 1 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(12 / 255f, 188 / 255f, 13 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(0, 92 / 255f, 1 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(12 / 255f, 188 / 255f, 13 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(0, 92 / 255f, 1 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(12 / 255f, 188 / 255f, 13 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(0, 92 / 255f, 1 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(12 / 255f, 188 / 255f, 13 / 255f);
            yield return new WaitForSeconds(0.25f);
            _octomonStat_NotificationTMP.color = new Color(0, 92 / 255f, 1 / 255f);
            
            _octomonStat_NotificationTMP.text = "";
        }
    }
    //Close OctomonStatCanvas
    public void CloseOctomonStat()
    {
        _octomonStatCanvas.GetComponent<CanvasGroup>().alpha = 0;
        _octomonStatCanvas.GetComponent<CanvasGroup>().interactable = false;
        _octomonStatCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;

        _octomonInventoryCanvas.GetComponent<CanvasGroup>().interactable = true;
        _octomonInventoryCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    //Back to main menu button
    public void BackToMainMenuButton()
    {
        GameObject octomonInventoryBackground = GameObject.FindWithTag("OctomonScroll");
        
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

        GameObject.FindWithTag("OctomonInventoryCanvas").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.FindWithTag("OctomonInventoryCanvas").GetComponent<CanvasGroup>().interactable = false;
        GameObject.FindWithTag("OctomonInventoryCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

        octomonInventoryBackground.transform.localScale = Vector2.zero;
    }
}