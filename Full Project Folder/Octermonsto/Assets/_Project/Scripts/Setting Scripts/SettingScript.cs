using UnityEngine;

public class SettingScript : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;

    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void BackToMainMenu()
    {
        GameObject settingPage = GameObject.FindWithTag("SettingPage");
        
        _audioManager.Play(AudioManager.SoundName.BUTTON);
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable = true;
        GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;

        GameObject.FindWithTag("SettingCanvas").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.FindWithTag("SettingCanvas").GetComponent<CanvasGroup>().interactable = false;
        GameObject.FindWithTag("SettingCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

        settingPage.transform.localScale = Vector2.zero;
    }
}
