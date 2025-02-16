using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk : MonoBehaviour
{
     public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the duck should interact witha Player
        if ((collision.gameObject.CompareTag("Player"))&& Input.GetKeyDown(KeyCode.Space))
        {
            text.gameObject.SetActive(true);
        }
    }
}
