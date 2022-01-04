using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator anim;
    //public GameObject death;
    //public GameObject sleep;
    private AudioSource audioSource;
    // Exposed audio variables
    [Header("Audio")]
    [Tooltip("An array of footstep sounds. One gets randonly selected to play")]
    [SerializeField] private AudioClip[] MonsterSounds;
   

    // Private audio variables
 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           anim.SetTrigger("Sleep");
           audioSource.clip = MonsterSounds[1];
           audioSource.PlayOneShot(audioSource.clip);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Die");
            audioSource.clip = MonsterSounds[2];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //if (other.tag == "potion")
    //{
    //Destroy(gameObject, 0.2f);
    //Destroy(other.gameObject);
    //}

    //}
}
