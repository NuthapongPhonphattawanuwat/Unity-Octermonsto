using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FirstTimePlaying : MonoBehaviour
{
    [Header("Scripts")] 
    [SerializeField] private ProfileScript _profileScript;
    [SerializeField] private OctomonData _octomonData;
    [SerializeField] private OctomonSlot _octomonSlot;
    [SerializeField] private CurrenciesScript _currenciesScript;
    [SerializeField] private AudioManager _audioManager;

    [Header("-")]
    [SerializeField] private ItemSlot _itemSlot;
    [SerializeField] private MobileSaveAndLoadManager _mobileSaveAndLoadManager;
    
    [SerializeField] private TextMeshProUGUI _firstTimePlayingTMP;
    [SerializeField] private TextMeshProUGUI _emptyNameErrorTMP;
    [SerializeField] private TextMeshProUGUI _profileButtonTMP;
    [SerializeField] private TextMeshProUGUI _profilePlayerNameTMP;
    [SerializeField] private GameObject _randomButton;

    [SerializeField] private TextMeshProUGUI _octomonAcquiredTMP;
    private string _playerName;
    
    [Header("Octomon Pics")]
    [SerializeField] private GameObject _octomonPicSlot;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _profileScript = GameObject.FindWithTag("Profile Script").GetComponent<ProfileScript>();
        _octomonSlot = GameObject.FindWithTag("Octomon Slot").GetComponent<OctomonSlot>();
        _octomonData = GameObject.FindWithTag("Octomon Data").GetComponent<OctomonData>();

        StartCoroutine(CheckIfAlreadyHaveAnOctomon());

        IEnumerator CheckIfAlreadyHaveAnOctomon()
        {
            yield return new WaitForSeconds(0.5f);
            if (_octomonSlot.octomonSlots[0].octomonSprite != null)
            {
                GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
                Destroy(GameObject.FindWithTag("FirstTimePlayingCanvas"));
            }
        }

        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = false;
        _randomButton.SetActive(false);
    }

    //For name input
    public void PlayerNameInputRead(string playerNameInput)
    {
        _playerName = playerNameInput;
        Debug.Log("Player's name is " + _playerName);
    }

    public void DoneNameInputButton()
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        if (string.IsNullOrWhiteSpace(_playerName))
        {
            IEnumerator BlinkingTextAndDisappear()
            {
                _emptyNameErrorTMP.text = "YOU CANNOT LEAVE YOUR NAME EMPTY\r\nTRY AGAIN";
                _emptyNameErrorTMP.color = new Color(192/255f, 0, 0);
                yield return new WaitForSeconds(0.5f);
                _emptyNameErrorTMP.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                yield return new WaitForSeconds(0.5f);
                _emptyNameErrorTMP.color = new Color(192 / 255f, 0, 0);
                yield return new WaitForSeconds(0.5f);
                _emptyNameErrorTMP.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                yield return new WaitForSeconds(0.5f);
                _emptyNameErrorTMP.color = new Color(192 / 255f, 0, 0);
                yield return new WaitForSeconds(0.5f);
                _emptyNameErrorTMP.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                yield return new WaitForSeconds(0.5f);
                _emptyNameErrorTMP.text = "";
            }
            StopAllCoroutines();
            StartCoroutine(BlinkingTextAndDisappear());
        }
        else
        {
            _profileScript.playerName = _playerName;
            _profileScript.playerLevel = 0;
            _profileScript.totalExp = 0;
            _profileScript.nextLevelExp = 100;
            _profileScript.AddExperience(100);

            _mobileSaveAndLoadManager.SaveProfileScript(_profileScript);

            _profileButtonTMP.text = $"{_playerName}";
            _profilePlayerNameTMP.text = $"{_playerName}";
            Debug.Log("Set player's name to " + _playerName);

            _firstTimePlayingTMP.text = "Now let's get you first friend!";
            _randomButton.SetActive(true);

            _itemSlot.plasticBallAmount += 10;
            _itemSlot.bubbleMachineAmount += 10;
            _itemSlot.clamAmount += 10;
            _itemSlot.cookedFishAmount += 10;
            _itemSlot.soapAmount += 10;
            _itemSlot.shampooAmount += 10;

            Destroy(GameObject.Find("Save Player Name Button"));
            Destroy(GameObject.Find("playerNameInputField (TMP)"));
            Destroy(_emptyNameErrorTMP);
        }
    }

    public void NormalRandom()
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        IEnumerator FirstOctomonTimer()
        {
            Destroy(_randomButton);
            _firstTimePlayingTMP.text = "";

            _mobileSaveAndLoadManager.SaveOctomonSlot(_octomonSlot);

            _currenciesScript.AddCurrencies(100, 0);
            _mobileSaveAndLoadManager.SaveCurrenciesScript(_currenciesScript);
            _itemSlot.UpdateItemAmountTMP();
            yield return new WaitForSeconds(3);
            GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
            Destroy(GameObject.FindWithTag("FirstTimePlayingCanvas"));
        }

        int x = 0;
        x = Random.Range(1, 101);

        //Uncommon
        if (x >= 1 && x <= 48)
        {
            x = Random.Range(1, 4);
            if (x == 1)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.roundName, _octomonData.roundAnimatorCTRL,
                    _octomonData.roundSprite, _octomonData.roundBaseHappyLevel, _octomonData.roundBaseFun,
                    _octomonData.roundBaseHunger, _octomonData.roundBaseCleanliness);
                _octomonAcquiredTMP.text = "You got round octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.roundSprite;
                Debug.Log("You got round octomon!");
            }
            else if (x == 2)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.pointyName, _octomonData.pointyAnimatorCTRL,
                    _octomonData.pointySprite, _octomonData.pointyBaseHappyLevel, _octomonData.pointyBaseFun,
                    _octomonData.pointyBaseHunger, _octomonData.pointyBaseCleanliness);
                _octomonAcquiredTMP.text = "You got pointy octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.pointySprite;
                Debug.Log("You got pointy octomon!");
            }
            else if (x == 3)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.buttonName, _octomonData.buttonAnimatorCTRL, _octomonData.buttonSprite,
                    _octomonData.buttonBaseHappyLevel, _octomonData.buttonBaseFun, _octomonData.buttonBaseHunger,
                    _octomonData.buttonBaseCleanliness);
                _octomonAcquiredTMP.text = "You got button octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.buttonSprite;
                Debug.Log("You got button octomon!");
            }
            _profileScript.AddExperience(50);
        }
        //Superior
        else if (x >= 49 && x <= 83)
        {
            x = Random.Range(1, 4);
            if (x == 1)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.strawberryName, _octomonData.strawberryAnimatorCTRL,
                    _octomonData.strawberrySprite,
                    _octomonData.strawberryBaseHappyLevel, _octomonData.strawberryBaseFun,
                    _octomonData.strawberryBaseHunger,
                    _octomonData.strawberryBaseCleanliness);
                _octomonAcquiredTMP.text = "You got strawberry octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.strawberrySprite;
                Debug.Log("You got strawberry octomon!");
            }
            else if (x == 2)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.cactusName, _octomonData.cactusAnimatorCTRL,
                    _octomonData.cactusSprite, _octomonData.cactusBaseHappyLevel, _octomonData.cactusBaseFun,
                    _octomonData.cactusBaseHunger, _octomonData.cactusBaseCleanliness);
                _octomonAcquiredTMP.text = "You got cactus octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.cactusSprite;
                Debug.Log("You got cactus octomon!");
            }
            else if (x == 3)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.devilName, _octomonData.devilAnimatorCTRL,
                    _octomonData.devilSprite, _octomonData.devilBaseHappyLevel, _octomonData.devilBaseFun,
                    _octomonData.devilBaseHunger, _octomonData.devilBaseCleanliness);
                _octomonAcquiredTMP.text = "You got devil octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.devilSprite;
                Debug.Log("You got devil octomon!");
            }
            _profileScript.AddExperience(100);
        }
        //Legendary
        else if (x >= 84 && x <= 95)
        {
            x = Random.Range(1, 3);
            if (x == 1)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.mummyName, _octomonData.mummyAnimatorCTRL,
                    _octomonData.mummySprite, _octomonData.mummyBaseHappyLevel, _octomonData.mummyBaseFun,
                    _octomonData.mummyBaseHunger, _octomonData.mummyBaseCleanliness);
                _octomonAcquiredTMP.text = "You got mummy octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.mummySprite;
                Debug.Log("You got mummy octomon!");
            }
            else if (x == 2)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.pumpkinName, _octomonData.pumpkinAnimatorCTRL,
                    _octomonData.pumpkinSprite,
                    _octomonData.pumpkinBaseHappyLevel, _octomonData.pumpkinBaseFun, _octomonData.pumpkinBaseHunger,
                    _octomonData.pumpkinBaseCleanliness);
                _octomonAcquiredTMP.text = "You got pumpkin octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.pumpkinSprite;
                Debug.Log("You got pumpkin octomon!");
            }
            _profileScript.AddExperience(175);
        }
        //Divine
        else if (x >= 96 && x <= 100)
        {
            x = Random.Range(1, 2);
            if (x == 1)
            {
                _octomonSlot.NewOctomonAdd(_octomonData.takoName, _octomonData.takoAnimatorCTRL,
                    _octomonData.takoSprite,
                    _octomonData.takoBaseHappyLevel, _octomonData.takoBaseFun, _octomonData.takoBaseHunger,
                    _octomonData.takoBaseCleanliness);
                _octomonAcquiredTMP.text = "You got tako octomon!";
                _octomonSlot.OctomonActive(0);
                _octomonPicSlot.GetComponent<SpriteRenderer>().sprite = _octomonData.takoSprite;
                Debug.Log("You got tako octomon!");
            }
            _profileScript.AddExperience(375);
        }

        StartCoroutine(FirstOctomonTimer());
    }
}