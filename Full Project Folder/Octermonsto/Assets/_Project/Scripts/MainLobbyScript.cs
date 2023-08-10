using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainLobbyScript : MonoBehaviour
{
    [Header("Script")] 
    [SerializeField] private ProfileScript _profileScript;
    [SerializeField] private AudioManager _audioManager;

    [Header("Canvas")]
    [SerializeField] private Canvas _mainLobbyCanvas; 
    [SerializeField] private Canvas _octomonInventoryCanvas;

    [Header("TMP")]
    [SerializeField] public TextMeshProUGUI mainLobbyMessageTMP;

    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    //Buttons
    public void ProfileButton()
    {
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = false;
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

        GameObject.FindWithTag("ProfileCanvas").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.FindWithTag("ProfileCanvas").GetComponent<CanvasGroup>().interactable = true;
        GameObject.FindWithTag("ProfileCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void SettingButton()
    {
        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            GameObject settingBg = GameObject.FindWithTag("SettingBackground");
            
            _audioManager.Play(AudioManager.SoundName.BUTTON);
            yield return new WaitForSeconds(0f);
            GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = false;
            GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

            GameObject.FindWithTag("SettingCanvas").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.FindWithTag("SettingCanvas").GetComponent<CanvasGroup>().interactable = true;
            GameObject.FindWithTag("SettingCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

            settingBg.GetComponent<CanvasGroup>().alpha = 1;

        }
    }

    public void InventoryButton()
    {
        StopAllCoroutines();
        StartCoroutine(Delay());

        IEnumerator Delay()
        {
            GameObject inventoryBg = GameObject.FindWithTag("InventoryBackground");
            
            _audioManager.Play(AudioManager.SoundName.BUTTON);
            yield return new WaitForSeconds(0.0f);
            GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = false;
            GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

            GameObject.FindWithTag("InventoryCanvas").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.FindWithTag("InventoryCanvas").GetComponent<CanvasGroup>().interactable = true;
            GameObject.FindWithTag("InventoryCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

            inventoryBg.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    public void ShopButton()
    {
        if (_profileScript.playerLevel < 3)
        {
            StopAllCoroutines();
            StartCoroutine(Delay());

            IEnumerator Delay()
            { 
                
                
                _audioManager.Play(AudioManager.SoundName.BUTTON);
                yield return new WaitForSeconds(0.0f);
                mainLobbyMessageTMP.text = "This section unlock at Level 3";
                yield return new WaitForSeconds(2.5f);
                mainLobbyMessageTMP.text = "";

                
            }
        }
        else if (_profileScript.playerLevel >= 3)
        {
            StopAllCoroutines();
            StartCoroutine(Delay());

            IEnumerator Delay()
            {
                GameObject shopBg = GameObject.FindWithTag("ShopBackground");
                
                _audioManager.Play(AudioManager.SoundName.BUTTON);
                yield return new WaitForSeconds(0.0f);
                GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = false;
                GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

                GameObject.FindWithTag("ShopCanvas").GetComponent<CanvasGroup>().alpha = 1;
                GameObject.FindWithTag("ShopCanvas").GetComponent<CanvasGroup>().interactable = true;
                GameObject.FindWithTag("ShopCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
                
                shopBg.GetComponent<CanvasGroup>().alpha = 1;
                
            }
        }
    }

    public void OctomonInfoButton()
    {
        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            _audioManager.Play(AudioManager.SoundName.BUTTON);
            yield return new WaitForSeconds(0.0f);
            GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = false;
            GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

            GameObject.FindWithTag("OctomonInfoCanvas").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.FindWithTag("OctomonInfoCanvas").GetComponent<CanvasGroup>().interactable = true;
            GameObject.FindWithTag("OctomonInfoCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void OctomonButton()
    {
        
        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            GameObject octoInventoryBg = GameObject.FindWithTag("OctomonInventoryBackground");
            
            _audioManager.Play(AudioManager.SoundName.BUTTON);
            yield return new WaitForSeconds(0f);
            _mainLobbyCanvas.GetComponent<CanvasGroup>().interactable = false;
            _mainLobbyCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
            _octomonInventoryCanvas.GetComponent<CanvasGroup>().alpha = 1;
            _octomonInventoryCanvas.GetComponent<CanvasGroup>().interactable = true;
            _octomonInventoryCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
            
            octoInventoryBg.GetComponent<CanvasGroup>().alpha = 1;
        }
        _octomonInventoryCanvas.GetComponent<CanvasGroup>().alpha = 1;
        _octomonInventoryCanvas.GetComponent<CanvasGroup>().interactable = true;
        _octomonInventoryCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
}
