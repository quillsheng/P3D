using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource audioS;
    [SerializeField] private AudioClip[] footstepSounds;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        audioS = GetComponent<AudioSource>();
       
    }

    void Update()
    {
        if (cc.isGrounded && audioS.isPlaying == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                int n = Random.Range(1, footstepSounds.Length);
                audioS.clip = footstepSounds[n];
                audioS.PlayOneShot(audioS.clip);
                // move picked sound to index 0 so it's not picked next time
                footstepSounds[n] = footstepSounds[0];
                footstepSounds[0] = audioS.clip;
                audioS.volume = Random.Range(0.6f, 1);
                audioS.pitch = Random.Range(0.7f, 1.1f);
                audioS.Play();
            }
              
        }
    }
}
