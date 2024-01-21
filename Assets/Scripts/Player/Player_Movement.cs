using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.8f;

    [SerializeField] private GameObject timelineTest;
    [SerializeField]
    private Player_Audio player_Audio;
    Vector3 velocity;

    private void Start()
    {
        this.player_Audio = this.GetComponent<Player_Audio>();
    }
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        if (move.magnitude > 0 && !this.player_Audio._playerWalk.isPlaying)
        {
            // If there's movement and audio is not playing, play the walking sound.
            this.player_Audio.Player_Audio_Walk(true);
        }
        else if (move.magnitude == 0 && this.player_Audio._playerWalk.isPlaying)
        {
            // If there's no movement and audio is playing, stop the walking sound.
            this.player_Audio.Player_Audio_Walk(false);
        }


        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

}
