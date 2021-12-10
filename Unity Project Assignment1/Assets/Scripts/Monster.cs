using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject deathfxPrefab;//destory fx
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "stone")
        {
            Destroy(gameObject, 0.2f);
            Destroy(other.gameObject);
            Instantiate(deathfxPrefab, transform.position, Quaternion.identity);
        }
      
    }
}
