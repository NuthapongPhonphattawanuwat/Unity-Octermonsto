using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSaveAndLoadManager : MonoBehaviour
{
    [SerializeField] private OctomonSlot _octomonSlot;
    [SerializeField] private OctomonData _octomonData;
    [SerializeField] private ItemSlot _itemSlot;
    [SerializeField] private ProfileScript _profileScript;
    [SerializeField] private CurrenciesScript _currenciesScript;

    private bool _playing = true;
    private void Start()
    {
        StartCoroutine(SaveGame());
        IEnumerator SaveGame()
        {
            yield return new WaitForSeconds(30);
            _playing = true;
            SaveItemSlot(_itemSlot);
            SaveOctomonSlot(_octomonSlot);
            SaveProfileScript(_profileScript);
            SaveCurrenciesScript(_currenciesScript);
            StartCoroutine(SaveGameLoop());
        }

        IEnumerator SaveGameLoop()
        {
            if (_playing)
            {
                yield return new WaitForSeconds(30);
                StartCoroutine(SaveGame());
            }
        }
    }

    public void SaveAll()
    {
        SaveItemSlot(_itemSlot);
        SaveOctomonSlot(_octomonSlot);
        SaveProfileScript(_profileScript);
        SaveCurrenciesScript(_currenciesScript);
    }

    public void LoadAll()
    {
        LoadItemSlot(_itemSlot);
        LoadOctomonSlot(_octomonSlot);
        LoadProfileScript(_profileScript);
        LoadCurrenciesScripts(_currenciesScript);
    }

    public void SaveProfileScript(ProfileScript profileScript)
    {
        SaveManager.instance.state.profileScript_playerName = profileScript.playerName;
        SaveManager.instance.state.profileScript_playerLevel = profileScript.playerLevel;
        SaveManager.instance.state.profileScript_totalExp = profileScript.totalExp;
        SaveManager.instance.state.profileScript_nextLevelExp = profileScript.nextLevelExp;
        SaveManager.instance.state.profileSctipt_nextLevelPearl = profileScript.nextLevelPearl;

        SaveManager.instance.Save();
        print("ProfileScript Saved");
    }
    public void LoadProfileScript(ProfileScript profileScript)
    {
        profileScript.playerName = SaveManager.instance.state.profileScript_playerName;
        profileScript.playerLevel = SaveManager.instance.state.profileScript_playerLevel;
        profileScript.totalExp = SaveManager.instance.state.profileScript_totalExp;
        profileScript.nextLevelExp = SaveManager.instance.state.profileScript_nextLevelExp;
        profileScript.nextLevelPearl = SaveManager.instance.state.profileSctipt_nextLevelPearl;
    }
    public void SaveItemSlot(ItemSlot itemSlot)
    {
        SaveManager.instance.state.itemSlot_plasticBallAmount = itemSlot.plasticBallAmount;
        SaveManager.instance.state.itemSlot_bubbleMachineAmount = itemSlot.bubbleMachineAmount;
        SaveManager.instance.state.itemSlot_clamAmount = itemSlot.clamAmount;
        SaveManager.instance.state.itemSlot_cookedFishAmount = itemSlot.cookedFishAmount;
        SaveManager.instance.state.itemSlot_soapAmount = itemSlot.soapAmount;
        SaveManager.instance.state.itemSlot_shampooAmount = itemSlot.shampooAmount;

        SaveManager.instance.Save();
        Debug.Log("Item slot Saved");
    }
    public void LoadItemSlot(ItemSlot itemSlot)
    {
        itemSlot.plasticBallAmount = SaveManager.instance.state.itemSlot_plasticBallAmount;
        itemSlot.bubbleMachineAmount = SaveManager.instance.state.itemSlot_bubbleMachineAmount;
        itemSlot.clamAmount = SaveManager.instance.state.itemSlot_clamAmount;
        itemSlot.cookedFishAmount = SaveManager.instance.state.itemSlot_cookedFishAmount;
        itemSlot.soapAmount = SaveManager.instance.state.itemSlot_soapAmount;
        itemSlot.shampooAmount = SaveManager.instance.state.itemSlot_shampooAmount;
    }
    public void SaveCurrenciesScript(CurrenciesScript currenciesScript)
    {
        SaveManager.instance.state.currenciesScript_pearl = currenciesScript.pearl;
        SaveManager.instance.state.currenciesScript_blackPearl = currenciesScript.blackPearl;
        print("CurrenciesScript Saved");
    }
    public void LoadCurrenciesScripts(CurrenciesScript currenciesScript)
    {
        currenciesScript.pearl = SaveManager.instance.state.currenciesScript_pearl;
        currenciesScript.blackPearl = SaveManager.instance.state.currenciesScript_blackPearl;
    }
    public void SaveOctomonSlot(OctomonSlot octomonSlot)
    {
        SaveManager.instance.Save();
        for (int i = 0; i < octomonSlot.octomonSlots.Count; i++)
        {
            if (i == 0)
            {
                SaveManager.instance.state.octomonSlot_name1 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel1 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun1 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger1 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness1 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel1 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun1 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger1 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness1 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 1)
            {
                SaveManager.instance.state.octomonSlot_name2 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel2 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun2 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger2 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness2 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel2 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun2 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger2 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness2 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 2)
            {
                SaveManager.instance.state.octomonSlot_name3 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel3 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun3 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger3 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness3 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel3 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun3 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger3 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness3 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 3)
            {
                SaveManager.instance.state.octomonSlot_name4 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel4 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun4 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger4 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness4 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel4 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun4 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger4 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness4 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 4)
            {
                SaveManager.instance.state.octomonSlot_name5 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel5 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun5 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger5 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness5 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel5 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun5 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger5 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness5 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 5)
            {
                SaveManager.instance.state.octomonSlot_name6 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel6 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun6 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger6 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness6 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel6 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun6 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger6 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness6 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 6)
            {
                SaveManager.instance.state.octomonSlot_name7 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel7 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun7 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger7 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness7 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel7 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun7 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger7 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness7 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 7)
            {
                SaveManager.instance.state.octomonSlot_name8 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel8 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun8 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger8 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness8 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel8 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun8 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger8 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness8 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 8)
            {
                SaveManager.instance.state.octomonSlot_name9 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel9 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun9 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger9 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness9 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel9 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun9 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger9 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness9 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 9)
            {
                SaveManager.instance.state.octomonSlot_name10 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel10 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun10 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger10 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness10 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel10 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun10 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger10 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness10 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 10)
            {
                SaveManager.instance.state.octomonSlot_name11 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel11 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun11 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger11 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness11 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel11 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun11 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger11 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness11 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 11)
            {
                SaveManager.instance.state.octomonSlot_name12 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel12 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun12 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger12 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness12 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel12 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun12 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger12 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness12 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 12)
            {
                SaveManager.instance.state.octomonSlot_name13 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel13 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun13 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger13 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness13 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel13 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun13 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger13 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness13 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 13)
            {
                SaveManager.instance.state.octomonSlot_name14 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel14 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun14 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger14 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness14 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel14 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun14 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger14 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness14 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 14)
            {
                SaveManager.instance.state.octomonSlot_name15 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel15 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun15 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger15 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness15 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel15 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun15 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger15 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness15 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 15)
            {
                SaveManager.instance.state.octomonSlot_name16 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel16 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun16 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger16 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness16 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel16 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun16 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger16 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness16 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 16)
            {
                SaveManager.instance.state.octomonSlot_name17 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel17 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun17 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger17 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness17 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel17 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun17 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger17 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness17 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 17)
            {
                SaveManager.instance.state.octomonSlot_name18 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel18 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun18 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger18 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness18 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel18 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun18 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger18 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness18 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 18)
            {
                SaveManager.instance.state.octomonSlot_name19 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel19 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun19 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger19 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness19 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel19 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun19 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger19 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness19 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 19)
            {
                SaveManager.instance.state.octomonSlot_name20 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel20 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun20 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger20 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness20 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel20 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun20 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger20 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness20 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 20)
            {
                SaveManager.instance.state.octomonSlot_name21 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel21 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun21 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger21 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness21 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel21 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun21 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger21 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness21 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 21)
            {
                SaveManager.instance.state.octomonSlot_name22 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel22 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun22 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger22 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness22 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel22 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun22 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger22 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness22 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 22)
            {
                SaveManager.instance.state.octomonSlot_name23 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel23 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun23 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger23 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness23 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel23 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun23 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger23 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness23 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 23)
            {
                SaveManager.instance.state.octomonSlot_name24 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel24 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun24 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger24 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness24 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel24 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun24 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger24 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness24 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 24)
            {
                SaveManager.instance.state.octomonSlot_name25 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel25 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun25 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger25 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness25 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel25 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun25 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger25 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness25 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 25)
            {
                SaveManager.instance.state.octomonSlot_name26 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel26 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun26 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger26 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness26 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel26 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun26 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger26 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness26 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 26)
            {
                SaveManager.instance.state.octomonSlot_name27 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel27 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun27 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger27 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness27 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel27 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun27 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger27 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness27 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 27)
            {
                SaveManager.instance.state.octomonSlot_name28 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel28 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun28 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger28 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness28 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel28 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun28 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger28 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness28 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 28)
            {
                SaveManager.instance.state.octomonSlot_name29 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel29 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun29 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger29 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness29 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel29 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun29 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger29 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness29 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 29)
            {
                SaveManager.instance.state.octomonSlot_name30 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel30 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun30 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger30 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness30 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel30 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun30 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger30 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness30 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 30)
            {
                SaveManager.instance.state.octomonSlot_name31 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel31 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun31 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger31 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness31 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel31 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun31 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger31 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness31 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 31)
            {
                SaveManager.instance.state.octomonSlot_name32 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel32 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun32 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger32 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness32 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel32 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun32 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger32 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness32 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 32)
            {
                SaveManager.instance.state.octomonSlot_name33 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel33 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun33 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger33 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness33 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel33 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun33 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger33 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness33 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 33)
            {
                SaveManager.instance.state.octomonSlot_name34 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel34 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun34 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger34 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness34 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel34 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun34 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger34 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness34 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 34)
            {
                SaveManager.instance.state.octomonSlot_name35 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel35 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun35 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger35 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness35 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel35 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun35 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger35 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness35 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 35)
            {
                SaveManager.instance.state.octomonSlot_name36 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel36 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun36 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger36 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness36 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel36 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun36 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger36 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness36 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 36)
            {
                SaveManager.instance.state.octomonSlot_name37 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel37 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun37 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger37 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness37 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel37 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun37 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger37 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness37 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 37)
            {
                SaveManager.instance.state.octomonSlot_name38 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel38 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun38 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger38 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness38 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel38 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun38 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger38 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness38 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 38)
            {
                SaveManager.instance.state.octomonSlot_name39 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel39 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun39 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger39 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness39 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel39 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun39 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger39 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness39 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 39)
            {
                SaveManager.instance.state.octomonSlot_name40 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel40 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun40 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger40 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness40 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel40 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun40 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger40 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness40 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 40)
            {
                SaveManager.instance.state.octomonSlot_name41 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel41 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun41 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger41 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness41 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel41 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun41 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger41 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness41 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 41)
            {
                SaveManager.instance.state.octomonSlot_name42 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel42 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun42 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger42 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness42 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel42 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun42 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger42 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness42 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 42)
            {
                SaveManager.instance.state.octomonSlot_name43 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel43 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun43 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger43 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness43 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel43 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun43 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger43 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness43 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 43)
            {
                SaveManager.instance.state.octomonSlot_name44 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel44 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun44 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger44 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness44 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel44 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun44 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger44 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness44 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 44)
            {
                SaveManager.instance.state.octomonSlot_name45 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel45 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun45 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger45 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness45 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel45 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun45 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger45 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness45 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 45)
            {
                SaveManager.instance.state.octomonSlot_name46 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel46 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun46 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger46 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness46 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel46 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun46 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger46 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness46 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 46)
            {
                SaveManager.instance.state.octomonSlot_name47 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel47 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun47 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger47 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness47 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel47 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun47 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger47 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness47 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 47)
            {
                SaveManager.instance.state.octomonSlot_name48 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel48 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun48 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger48 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness48 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel48 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun48 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger48 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness48 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 48)
            {
                SaveManager.instance.state.octomonSlot_name49 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel49 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun49 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger49 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness49 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel49 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun49 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger49 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness49 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
            else if (i == 49)
            {
                SaveManager.instance.state.octomonSlot_name50 = octomonSlot.octomonSlots[i].octomonName;

                SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel50 = octomonSlot.octomonSlots[i].octomonMaxHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonMaxFun50 = octomonSlot.octomonSlots[i].octomonMaxFun;
                SaveManager.instance.state.octomonSlot_octomonMaxHunger50 = octomonSlot.octomonSlots[i].octomonMaxHunger;
                SaveManager.instance.state.octomonSlot_octomonMaxCleanliness50 = octomonSlot.octomonSlots[i].octomonMaxCleanliness;

                SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel50 = octomonSlot.octomonSlots[i].octomonCurrentHappyLevel;
                SaveManager.instance.state.octomonSlot_octomonCurrentFun50 = octomonSlot.octomonSlots[i].octomonCurrentFun;
                SaveManager.instance.state.octomonSlot_octomonCurrentHunger50 = octomonSlot.octomonSlots[i].octomonCurrentHunger;
                SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness50 = octomonSlot.octomonSlots[i].octomonCurrentCleanliness;
            }
        }
        SaveManager.instance.Save();
        Debug.Log("Octomon slot Saved");
    }
    public void LoadOctomonSlot(OctomonSlot octomonSlot)
    {
        for (int i = 0; i < octomonSlot.octomonSlots.Count; i++)
        {
            if (i == 0)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name1;

                LoadCheckOctomon();
                octomonSlot.OctomonActive(0);

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel1;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun1;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger1;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness1;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel1;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun1;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger1;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness1;
            }
            else if (i == 1)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name2;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel2;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun2;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger2;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness2;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel2;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun2;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger2;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness2;
            }
            else if (i == 2)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name3;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel3;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun3;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger3;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness3;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel3;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun3;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger3;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness3;
            }
            else if (i == 3)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name4;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel4;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun4;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger4;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness4;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel4;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun4;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger4;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness4;
            }
            else if (i == 4)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name5;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel5;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun5;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger5;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness5;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel5;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun5;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger5;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness5;
            }
            else if (i == 5)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name6;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel6;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun6;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger6;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness6;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel6;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun6;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger6;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness6;
            }
            else if (i == 6)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name7;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel7;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun7;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger7;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness7;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel7;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun7;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger7;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness7;
            }
            else if (i == 7)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name8;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel8;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun8;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger8;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness8;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel8;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun8;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger8;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness8;
            }
            else if (i == 8)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name9;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel9;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun9;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger9;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness9;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel9;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun9;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger9;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness9;
            }
            else if (i == 9)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name10;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel10;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun10;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger10;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness10;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel10;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun10;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger10;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness10;
            }
            else if (i == 10)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name11;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel11;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun11;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger11;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness11;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel11;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun11;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger11;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness11;
            }
            else if (i == 11)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name12;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel12;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun12;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger12;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness12;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel12;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun12;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger12;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness12;
            }
            else if (i == 12)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name13;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel13;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun13;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger13;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness13;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel13;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun13;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger13;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness13;
            }
            else if (i == 13)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name14;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel14;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun14;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger14;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness14;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel14;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun14;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger14;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness14;
            }
            else if (i == 14)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name15;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel15;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun15;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger15;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness15;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel15;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun15;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger15;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness15;
            }
            else if (i == 15)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name16;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel16;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun16;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger16;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness16;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel16;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun16;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger16;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness16;
            }
            else if (i == 16)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name17;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel17;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun17;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger17;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness17;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel17;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun17;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger17;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness17;
            }
            else if (i == 17)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name18;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel18;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun18;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger18;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness18;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel18;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun18;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger18;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness18;
            }
            else if (i == 18)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name19;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel19;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun19;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger19;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness19;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel19;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun19;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger19;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness19;
            }
            else if (i == 19)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name20;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel20;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun20;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger20;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness20;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel20;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun20;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger20;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness20;
            }
            else if (i == 20)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name21;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel21;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun21;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger21;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness21;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel21;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun21;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger21;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness21;
            }
            else if (i == 21)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name22;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel22;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun22;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger22;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness22;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel22;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun22;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger22;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness22;
            }
            else if (i == 22)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name23;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel23;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun23;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger23;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness23;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel23;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun23;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger23;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness23;
            }
            else if (i == 23)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name24;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel24;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun24;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger24;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness24;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel24;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun24;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger24;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness24;
            }
            else if (i == 24)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name25;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel25;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun25;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger25;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness25;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel25;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun25;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger25;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness25;
            }
            else if (i == 25)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name26;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel26;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun26;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger26;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness26;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel26;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun26;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger26;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness26;
            }
            else if (i == 26)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name27;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel27;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun27;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger27;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness27;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel27;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun27;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger27;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness27;
            }
            else if (i == 27)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name28;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel28;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun28;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger28;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness28;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel28;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun28;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger28;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness28;
            }
            else if (i == 28)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name29;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel29;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun29;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger29;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness29;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel29;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun29;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger29;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness29;
            }
            else if (i == 29)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name30;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel30;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun30;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger30;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness30;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel30;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun30;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger30;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness30;
            }
            else if (i == 30)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name31;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel31;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun31;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger31;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness31;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel31;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun31;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger31;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness31;
            }
            else if (i == 31)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name32;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel32;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun32;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger32;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness32;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel32;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun32;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger32;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness32;
            }
            else if (i == 32)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name33;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel33;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun33;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger33;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness33;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel33;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun33;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger33;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness33;
            }
            else if (i == 33)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name34;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel34;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun34;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger34;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness34;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel34;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun34;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger34;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness34;
            }
            else if (i == 34)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name35;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel35;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun35;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger35;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness35;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel35;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun35;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger35;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness35;
            }
            else if (i == 35)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name36;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel36;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun36;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger36;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness36;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel36;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun36;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger36;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness36;
            }
            else if (i == 36)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name37;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel37;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun37;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger37;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness37;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel37;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun37;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger37;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness37;
            }
            else if (i == 37)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name38;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel38;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun38;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger38;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness38;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel38;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun38;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger38;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness38;
            }
            else if (i == 38)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name39;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel39;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun39;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger39;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness39;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel39;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun39;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger39;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness39;
            }
            else if (i == 39)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name40;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel40;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun40;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger40;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness40;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel40;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun40;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger40;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness40;
            }
            else if (i == 40)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name41;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel41;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun41;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger41;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness41;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel41;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun41;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger41;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness41;
            }
            else if (i == 41)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name42;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel42;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun42;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger42;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness42;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel42;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun42;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger42;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness42;
            }
            else if (i == 42)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name43;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel43;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun43;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger43;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness43;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel43;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun43;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger43;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness43;
            }
            else if (i == 43)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name44;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel44;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun44;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger44;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness44;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel44;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun44;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger44;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness44;
            }
            else if (i == 44)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name45;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel45;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun45;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger45;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness45;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel45;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun45;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger45;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness45;
            }
            else if (i == 45)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name46;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel46;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun46;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger46;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness46;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel46;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun46;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger46;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness46;
            }
            else if (i == 46)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name47;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel47;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun47;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger47;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness47;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel47;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun47;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger47;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness47;
            }
            else if (i == 47)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name48;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel48;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun48;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger48;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness48;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel48;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun48;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger48;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness48;
            }
            else if (i == 48)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name49;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel49;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun49;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger49;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness49;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel49;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun49;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger49;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness49;
            }
            else if (i == 49)
            {
                octomonSlot.octomonSlots[i].octomonName = SaveManager.instance.state.octomonSlot_name50;

                LoadCheckOctomon();

                octomonSlot.octomonSlots[i].octomonMaxHappyLevel = SaveManager.instance.state.octomonSlot_octomonMaxHappyLevel50;
                octomonSlot.octomonSlots[i].octomonMaxFun = SaveManager.instance.state.octomonSlot_octomonMaxFun50;
                octomonSlot.octomonSlots[i].octomonMaxHunger = SaveManager.instance.state.octomonSlot_octomonMaxHunger50;
                octomonSlot.octomonSlots[i].octomonMaxCleanliness = SaveManager.instance.state.octomonSlot_octomonMaxCleanliness50;

                octomonSlot.octomonSlots[i].octomonCurrentHappyLevel = SaveManager.instance.state.octomonSlot_octomonCurrentHappyLevel50;
                octomonSlot.octomonSlots[i].octomonCurrentFun = SaveManager.instance.state.octomonSlot_octomonCurrentFun50;
                octomonSlot.octomonSlots[i].octomonCurrentHunger = SaveManager.instance.state.octomonSlot_octomonCurrentHunger50;
                octomonSlot.octomonSlots[i].octomonCurrentCleanliness = SaveManager.instance.state.octomonSlot_octomonCurrentCleanliness50;
            }
            else
            {
                break;
            }

            void LoadCheckOctomon()
            {
                if (octomonSlot.octomonSlots[i].octomonName == "Round")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.roundName, _octomonData.roundAnimatorCTRL,
                        _octomonData.roundSprite, _octomonData.roundBaseHappyLevel, _octomonData.roundBaseFun,
                        _octomonData.roundBaseHunger, _octomonData.roundBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Pointy")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.pointyName, _octomonData.pointyAnimatorCTRL,
                        _octomonData.pointySprite, _octomonData.pointyBaseHappyLevel, _octomonData.pointyBaseFun,
                        _octomonData.pointyBaseHunger, _octomonData.pointyBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Tako")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.takoName, _octomonData.takoAnimatorCTRL,
                        _octomonData.takoSprite, _octomonData.takoBaseHappyLevel, _octomonData.takoBaseFun,
                        _octomonData.takoBaseHunger, _octomonData.takoBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Cactus")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.cactusName, _octomonData.cactusAnimatorCTRL,
                        _octomonData.cactusSprite, _octomonData.cactusBaseHappyLevel, _octomonData.cactusBaseFun,
                        _octomonData.cactusBaseHunger, _octomonData.cactusBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Mummy")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.mummyName, _octomonData.mummyAnimatorCTRL,
                        _octomonData.mummySprite, _octomonData.mummyBaseHappyLevel, _octomonData.mummyBaseFun,
                        _octomonData.mummyBaseHunger, _octomonData.mummyBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Strawberry")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.strawberryName, _octomonData.strawberryAnimatorCTRL,
                        _octomonData.strawberrySprite, _octomonData.strawberryBaseHappyLevel, _octomonData.strawberryBaseFun,
                        _octomonData.strawberryBaseHunger, _octomonData.strawberryBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Devil")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.devilName, _octomonData.devilAnimatorCTRL,
                        _octomonData.devilSprite, _octomonData.devilBaseHappyLevel, _octomonData.devilBaseFun,
                        _octomonData.devilBaseHunger, _octomonData.devilBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Button")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.buttonName, _octomonData.buttonAnimatorCTRL,
                        _octomonData.buttonSprite, _octomonData.buttonBaseHappyLevel, _octomonData.buttonBaseFun,
                        _octomonData.buttonBaseHunger, _octomonData.buttonBaseCleanliness);
                }
                else if (octomonSlot.octomonSlots[i].octomonName == "Pumpkin")
                {
                    octomonSlot.NewOctomonAdd(_octomonData.pumpkinName, _octomonData.pumpkinAnimatorCTRL,
                        _octomonData.pumpkinSprite, _octomonData.pumpkinBaseHappyLevel, _octomonData.pumpkinBaseFun,
                        _octomonData.pumpkinBaseHunger, _octomonData.pumpkinBaseCleanliness);
                }
            }
        }
        SaveManager.instance.Load();

        Debug.Log("Game Loaded");
    }
}