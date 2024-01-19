using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour
{

    public AudioSource _playerSource;
    public AudioSource _playerMainSource;
    [SerializeField] private AudioClip[] _WalkAudio_SFX;
    [SerializeField] private AudioClip _crushingPaper_SFX;
    [SerializeField] private AudioClip _object_SFX;


    private void Start()
    {
        this._playerSource = this.GetComponent<AudioSource>();
    }

    public void Player_Audio_Walk(bool isWalking)
    {
        if (isWalking)
            _playerMainSource.Play();
        else
            _playerMainSource.Stop();
    }

    public void Player_Audio_PickUp_Letter()
    {
        this._playerSource.Stop();
        this._playerSource.clip = this._crushingPaper_SFX;
        this._playerSource.Play();
    }
    public void Player_Audio_PicKUp_Object()
    {
        this._playerSource.Stop();
        this._playerSource.clip = this._object_SFX;
        this._playerSource.Play();

    }
    public void Player_Audi_Stop()
    {
        this._playerSource.Stop();
    }

    private enum RandomWalk_SFX
    {
        random1 = 0,
        random2 = 1,
        random3 = 2,
    }

}
