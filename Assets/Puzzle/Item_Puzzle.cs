using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;
using UnityEngine.Serialization;

public class Item_Puzzle : MonoBehaviour,IInteractable
{
    [SerializeField] private int puzzleNo = 0;
    [SerializeField] private Transform transformTarget;
    [SerializeField] private GameObject key;
    [SerializeField] private AudioSource _audioSource;

    public void Item_PickPuzzle()
    {
        Puzzle.Instance.OnShow_Puzzle(puzzleNo);
    }

    public void HideandUnHide(bool hide)
    {
        if(hide)
            this.gameObject.SetActive(false);
        else
        {
            this.gameObject.SetActive(true);
        }
        
    }

    public void PuzzleSolved()
    {
        MainCanvas_UI.Instance.Hide_Helper();
        Instantiate(key, this.transform.position,Quaternion.identity);
        _audioSource.Play();
        Destroy(this.gameObject);

    }

    public void Interact()
    {
        this.Item_PickPuzzle();
    }
}
