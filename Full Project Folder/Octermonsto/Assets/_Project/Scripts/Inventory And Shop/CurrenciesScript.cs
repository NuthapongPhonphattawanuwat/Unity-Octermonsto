using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrenciesScript : MonoBehaviour
{
    //Currencies
    public int pearl;
    public int blackPearl;
    [SerializeField] private MobileSaveAndLoadManager _mobileSaveAndLoadManager;

    [SerializeField] private TextMeshProUGUI _LobbyPearlTMP;
    [SerializeField] private TextMeshProUGUI _LobbyBlackPearlTMP;
    [SerializeField] private TextMeshProUGUI _OctomonInventoryPearlTMP;
    [SerializeField] private TextMeshProUGUI _OctomonInventoryBlackPearlTMP;
    [SerializeField] private TextMeshProUGUI _InventoryPearlTMP;
    [SerializeField] private TextMeshProUGUI _InventoryBlackPearlTMP;
    [SerializeField] private TextMeshProUGUI _ShopPearlTMP;
    [SerializeField] private TextMeshProUGUI _ShopBlackPearlTMP;

    void Start()
    {
        _mobileSaveAndLoadManager.LoadCurrenciesScripts(this);

        StartCoroutine(SerializeFieldVariablesAssign());
        UpdateCurrenciesText();

        IEnumerator SerializeFieldVariablesAssign()
        {
            _LobbyPearlTMP = GameObject.Find("Lobby Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            _LobbyBlackPearlTMP = GameObject.Find("Lobby Black Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            _OctomonInventoryPearlTMP =
                GameObject.Find("Octomon Inventory Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            _OctomonInventoryBlackPearlTMP =
                GameObject.Find("Octomon Inventory Black Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            _InventoryPearlTMP = GameObject.Find("Inventory Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            _InventoryBlackPearlTMP = GameObject.Find("Inventory Black Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            _ShopPearlTMP = GameObject.Find("Shop Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            _ShopBlackPearlTMP = GameObject.Find("Shop Black Pearl (TMP)").GetComponent<TextMeshProUGUI>();
            yield return new WaitForSeconds(0);
        }
    }

    void Update()
    {

    }

    public void UpdateCurrenciesText()
    {
        _LobbyPearlTMP.text = pearl.ToString();
        _LobbyBlackPearlTMP.text = blackPearl.ToString();
        _OctomonInventoryPearlTMP.text = pearl.ToString();
        _OctomonInventoryBlackPearlTMP.text = blackPearl.ToString();
        _InventoryPearlTMP.text = pearl.ToString();
        _InventoryBlackPearlTMP.text = blackPearl.ToString();
        _ShopPearlTMP.text = pearl.ToString();
        _ShopBlackPearlTMP.text = blackPearl.ToString();
    }

    public void AddCurrencies(int pearlToAdd, int blackPearlToAdd)
    {
        pearl += pearlToAdd;
        blackPearl += blackPearlToAdd;
        UpdateCurrenciesText();
        _mobileSaveAndLoadManager.SaveCurrenciesScript(this);
    }

    public void RemoveCurrencies(int pearlToRemove, int blackPearlToRemove)
    {
        pearl -= pearlToRemove;
        blackPearl -= blackPearlToRemove;
        UpdateCurrenciesText();
        _mobileSaveAndLoadManager.SaveCurrenciesScript(this);
    }
}
