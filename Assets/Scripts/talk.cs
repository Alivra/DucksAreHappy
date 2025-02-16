using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
     public TextPrinter DarwinIntro;
     public TextPrinter Quest;
     public TextPrinter Credentials;
     public TextPrinter AmnesiaInfo;

     bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        DarwinIntro.gameObject.SetActive(false);
        Quest.gameObject.SetActive(false);
        Credentials.gameObject.SetActive(false);
        AmnesiaInfo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            DarwinIntro.gameObject.SetActive(true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        // Check if the duck should interact witha Player
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("exit");
        // Check if the duck should interact witha Player
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
