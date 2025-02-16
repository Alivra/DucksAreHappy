using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    private bool finishedConversation;
    public GameObject choice1;

    void Start()
    {
        dialogueText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else if (finishedConversation)
            {
                index = dialogue.Length - 1;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            if (index == 1)
            {
                choice1.SetActive(true);
            }
            else
            {
                contButton.SetActive(true);
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        choice1.SetActive(false);
        contButton.SetActive(false);

        if (index < dialogue.Length - 3)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            finishedConversation = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
