using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator anim;
    //public GameObject death;
    //public GameObject sleep;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           anim.SetTrigger("Sleep");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Die");
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
