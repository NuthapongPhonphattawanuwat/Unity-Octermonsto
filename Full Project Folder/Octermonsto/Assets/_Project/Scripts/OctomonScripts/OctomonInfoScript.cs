using TMPro;
using UnityEngine;

public class OctomonInfoScript : MonoBehaviour
{
    public TextMeshProUGUI octomonStats;
    public TextMeshProUGUI octomonName;

    private OctomonSlot _octomonSlot;

    private float _activeOctomonMaxHappyLevel;
    private float _activeOctomonMaxFun;
    private float _activeOctomonMaxHunger;
    private float _activeOctomonMaxCleanliness;

    private float _activeOctomonCurrentHappyLevel;
    private float _activeOctomonCurrentFun;
    private float _activeOctomonCurrentHunger;
    private float _activeOctomonCurrentCleanliness;

    private void Start()
    {
        _octomonSlot = GameObject
            .FindWithTag("Octomon Slot").GetComponent<OctomonSlot>();
    }

    private void Update()
    {
        if (_octomonSlot.octomonActive || _octomonSlot.activeOctomonName != null)
        {
            //octomon Info
            _activeOctomonCurrentHappyLevel = (int)_octomonSlot.activeOctomonCurrentHappyLevel;
            _activeOctomonCurrentFun = (int)_octomonSlot.activeOctomonCurrentFun;
            _activeOctomonCurrentHunger = (int)_octomonSlot.activeOctomonCurrentHunger;
            _activeOctomonCurrentCleanliness= (int)_octomonSlot.activeOctomonCurrentCleanliness;

            _activeOctomonMaxHappyLevel = (int)_octomonSlot.activeOctomonMaxHappyLevel;
            _activeOctomonMaxFun = (int)_octomonSlot.activeOctomonMaxFun;
            _activeOctomonMaxHunger = (int)_octomonSlot.activeOctomonMaxHunger;
            _activeOctomonMaxCleanliness = (int)_octomonSlot.activeOctomonMaxCleanliness;

            octomonStats.text =
                $"Happy level : {_activeOctomonCurrentHappyLevel}/{_activeOctomonMaxHappyLevel} \r\nFun : {_activeOctomonCurrentFun}/{_activeOctomonMaxFun} \r\nHunger : {_activeOctomonCurrentHunger}/{_activeOctomonMaxHunger} \r\nCleanliness : {_activeOctomonCurrentCleanliness}/{_activeOctomonMaxCleanliness}";
        }
    }
    
    public void CloseOctomonInfoButton()
    {
        GameObject octomonInfoBG = GameObject.FindWithTag("OctomonInfoBackground");
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        GameObject.FindWithTag("OctomonInfoCanvas").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.FindWithTag("OctomonInfoCanvas").GetComponent<CanvasGroup>().interactable = false;
        GameObject.FindWithTag("OctomonInfoCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

        // octomonInfoBG.transform.localScale = Vector2.zero;
    }
}