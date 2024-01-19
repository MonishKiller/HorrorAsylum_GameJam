using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_LetterPanel : MonoBehaviour
{
    [SerializeField] private Button BTN_Close;
    [SerializeField] private Button BTN_Letter1;
    [SerializeField] private Button BTN_Letter2;
    [SerializeField] private Button BTN_Letter3;
    [SerializeField] private Image IMG_LetterPanel;
    [SerializeField] private Sprite[] letterGrp;
    private void Start()
    {
        this.BTN_Letter1.onClick.AddListener(Handle_Letter1BTN);
        this.BTN_Letter2.onClick.AddListener(Handle_Letter2BTN);
        this.BTN_Letter3.onClick.AddListener(Handle_Letter3BTN);
        this.BTN_Close.onClick.AddListener(Handel_CloseBtn);


    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Toggle_Letter(letterGrp[3]);

    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

    }

    private void Handel_CloseBtn()
    {
        MainCanvas_UI.Instance.Play_ButtonSound();
        this.Hide();
    }
    private void Handle_Letter1BTN()
    {
        Debug.Log("Showing letter 1");
        MainCanvas_UI.Instance.Play_ButtonSound();
     
    }
    private void Handle_Letter2BTN()
    {
        Debug.Log("Showing letter 2");
        MainCanvas_UI.Instance.Play_ButtonSound();
      
    }
    private void Handle_Letter3BTN()
    {
        Debug.Log("Showing letter 3");
        MainCanvas_UI.Instance.Play_ButtonSound();
    }
    private void Toggle_Letter(Sprite letterSprite)
    {
        this.IMG_LetterPanel.sprite = letterSprite;

    }

}
