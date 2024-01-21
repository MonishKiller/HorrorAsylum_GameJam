using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Item_Puzzle : MonoBehaviour
{
    [SerializeField] private int puzzleNo = 0;
    [SerializeField] private Transform transformTarget;
    [SerializeField] private GameObject key;

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
        Instantiate(key, this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);

    }

}
