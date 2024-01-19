using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MainCanvas_UI : Singleton<MainCanvas_UI>
{
    [SerializeField] private TextMeshProUGUI _defaultMsg_TMP;
    [SerializeField] private TextMeshProUGUI _helper_TMP;
    [SerializeField] private UI_LetterPanel _UI_letterPanel;

    [SerializeField] public AudioSource _audioSource;
    [SerializeField] public AudioClip _btnClickSFX;


    public void Play_ButtonSound()
    {
        _audioSource.clip = _btnClickSFX;
        _audioSource.Play();
    }

    public void Show_LetterPanel()
    {
        _UI_letterPanel.Show();

    }
    public void Show_Helper()
    {
        Debug.LogError("SHowinf");
        if (!this._helper_TMP.gameObject.activeSelf)
            this._helper_TMP.gameObject.SetActive(true);
    }
    public void Hide_Helper()
    {
        if (this._helper_TMP.gameObject.activeSelf)
            this._helper_TMP.gameObject.SetActive(false);
    }


    public void Show_Message(string message)
    {
        Debug.Log("Messages is Showing");
        this._defaultMsg_TMP.text = message;
        if (!this._defaultMsg_TMP.gameObject.activeSelf)
            this._defaultMsg_TMP.gameObject.SetActive(true);

    }
    public void Hide_Message()
    {
        Debug.Log("Messages is Turned Offf");
        if (this._defaultMsg_TMP.gameObject.activeSelf)
            this._defaultMsg_TMP.gameObject.SetActive(false);
    }

}
