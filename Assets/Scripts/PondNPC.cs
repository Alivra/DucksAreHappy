using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PondNPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    private bool finishedConversation = false;
    private bool startedQuest = false;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;
    public GameObject choice5;

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
                index = 17;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (startedQuest)
            {
                index = 15;
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
            if (index == 2)
            {
                choice1.SetActive(true);
                choice2.SetActive(true);
                choice3.SetActive(true);
            }
            else if (index == 10)
            {
                choice1.SetActive(true);
                choice2.SetActive(true);
            }
            else if (index == 15)
            {
                choice4.SetActive(true);
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
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        if (FindNextEmptyIndex(dialogue) == -1)
        {
            if (index < dialogue.Length - 1)
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                zeroText();
                //finishedConversation = true;
            }
        }
        else
        {
            if (index < FindNextEmptyIndex(dialogue))
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                zeroText();
                //finishedConversation = true;
            }
        }
    }

    int FindNextEmptyIndex(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[index] == "") // Check for empty or null values
            {
                return i;
            }
        }
        return -1; // Return -1 if no empty index is found
    }

    public void goToChoice1()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        index = 3;

        if (index < dialogue.Length - 14)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            startedQuest = true;
        }
        else
        {
            zeroText();
        }

    }

    public void goToChoice2()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        index = 4;

        if (index < dialogue.Length - 14)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            startedQuest = true;
        }
        else
        {
            zeroText();
        }
    }

    public void goToChoice3()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        index = 7;

        if (index < dialogue.Length - 7)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            //zeroText();
            choice1.SetActive(true);
            choice2.SetActive(true);
        }

    }

    public void goToChoice4()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        index = 11;

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
