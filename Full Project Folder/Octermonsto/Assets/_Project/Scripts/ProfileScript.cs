using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ProfileScript : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private MobileSaveAndLoadManager _mobileSaveAndLoadManager;
    [SerializeField] private CurrenciesScript _currenciesScript;

    [HideInInspector] public string playerName;
    public int playerLevel;
    [HideInInspector] public int totalExp;
    [HideInInspector] public int nextLevelExp;
    [HideInInspector] public int nextLevelPearl;

    [Header("TMPs")]
    [SerializeField] private TextMeshProUGUI _profileButton_playerNameTMP;
    [SerializeField] private TextMeshProUGUI _playerNameTMP;
    [SerializeField] private TextMeshProUGUI _playerLevelTMP;
    [SerializeField] private TextMeshProUGUI _playerExpTMP;

    void Start()
    {
        _mobileSaveAndLoadManager.LoadProfileScript(this);

        _profileButton_playerNameTMP.text = playerName;

        _playerNameTMP.text = playerName;
        _playerLevelTMP.text = $"{playerLevel}";
        _playerExpTMP.text = $"{totalExp}/{nextLevelExp}";
    }

    public void AddExperience(int expAmount)
    {
        totalExp += expAmount;

        //If Exp reach the next level Exp
        if (totalExp >= nextLevelExp)
        {
            //Player level up
            playerLevel += 1;

            //Check if player getting first time Level-up pearl
            if (nextLevelPearl == 0)
            {
                nextLevelPearl = 500;
            }

            //player get level u-up pearl
            _currenciesScript.AddCurrencies(nextLevelPearl, 0);

            //Exp for next level up increase by 20%
            nextLevelExp = nextLevelExp + (int)Mathf.Round(nextLevelExp * 1.2f);
            //Pearl reward for next level up increase by 20%
            nextLevelPearl = nextLevelPearl + (int)Mathf.Round(nextLevelPearl * 1.2f);
        }

        //Update player name, level, CurrentExp/NextLevelExp
        _playerNameTMP.text = playerName;
        _playerLevelTMP.text = $"{playerLevel}";
        _playerExpTMP.text = $"{totalExp}/{nextLevelExp}";
    }

    public void CloseProfileButton()
    {
        GameObject profileBg = GameObject.FindWithTag("ProfileBackground");
        
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

        GameObject.FindWithTag("ProfileCanvas").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.FindWithTag("ProfileCanvas").GetComponent<CanvasGroup>().interactable = false;
        GameObject.FindWithTag("ProfileCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

        profileBg.transform.localScale = Vector2.zero;
    }
}