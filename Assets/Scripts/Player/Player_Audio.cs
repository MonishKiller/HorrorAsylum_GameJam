using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player_Audio : MonoBehaviour
{

   public AudioSource _playerSFX;
    public AudioSource _playerWalk;
    public AudioSource _playerBreathing;
    public AudioSource _musicLoop;
    public AudioSource[] _playerScared;
    [SerializeField] private AudioClip[] _WalkAudio_SFX;
    [SerializeField] private AudioClip _crushingPaper_SFX;
    [SerializeField] private AudioClip _object_SFX;
    [SerializeField] private AudioClip[] _breathingSFX;
    [SerializeField] private AudioClip _musicSFX;


    private void Start()
    {
        this._playerSFX = this.GetComponent<AudioSource>();
        Play_MusicLoop();
        Play_BreathingLoop();
    }

    public void Player_Audio_Walk(bool isWalking)
    {
        if (isWalking)
            _playerWalk.Play();
        else
            _playerWalk.Stop();
    }

    public void Player_Audio_PickUp_Letter()
    {
        this._playerSFX.Stop();
        this._playerSFX.clip = this._crushingPaper_SFX;
        this._playerSFX.Play();
    }
    public void Player_Audio_PicKUp_Object()
    {
        this._playerSFX.Stop();
        this._playerSFX.clip = this._object_SFX;
        this._playerSFX.Play();

    }

    public void Stop_PlayerScared()
    {
        for (int i = 0; i < _playerScared.Length; i++)
        {
            _playerScared[i].Stop();
        }
        
    }
    public void Play_PlayerScared()
    {
        for (int i = 0; i < _playerScared.Length; i++)
        {
            _playerScared[i].Play();
        }
        Invoke("Stop_PlayerScared",3f);
    }
    public void Player_Audi_Stop()
    {
        this._playerSFX.Stop();
    }

    public void Play_MusicLoop()
    {
        this._musicLoop.clip = this._musicSFX;
        _musicLoop.Play();
    }

    public void Play_BreathingLoop()
    {
        this._playerBreathing.clip = this._breathingSFX[0];
        _playerBreathing.Play();
    }

    private enum RandomWalk_SFX
    {
        random1 = 0,
        random2 = 1,
        random3 = 2,
    }

}
