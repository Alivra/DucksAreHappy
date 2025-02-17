using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SirQuacksNPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    private bool finishedConversation = false;
    private bool disgraced = false;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;

    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;
    public GameObject answer4;
    public GameObject answer5;
    public GameObject answer6;
    public GameObject answer7;
    public GameObject answer8;
    public GameObject answer9;


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
            else if (disgraced)
            {
                index = 19;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (finishedConversation)
            {
                index = 21;
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
                choice2.SetActive(true);
            }
            else if (index == 19)
            {
                choice3.SetActive(true);
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

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

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

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        index = 2;

        if (index < 7)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            choice3.SetActive(true);
            choice4.SetActive(true);
        }

    }

    public void goToChoice2()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        index = 7;

        if (index < 10)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            choice3.SetActive(true);
            choice4.SetActive(true);
        }
    }

    public void goToChoice3()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        index = 20;

        if (index < 20)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            zeroText();
            disgraced = true;
        }

    }

    public void goToChoice4()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
        contButton.SetActive(false);

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        index = 12;

        if (index < 12)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            answer1.SetActive(true);
            answer2.SetActive(true);
            answer3.SetActive(true);

        }
    }

    public void goToRightAnswer1()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        contButton.SetActive(false);

        index = 14;

        if (index < 14)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            answer4.SetActive(true);
            answer5.SetActive(true);
            answer6.SetActive(true);

        }
    }

    public void goToRightAnswer2()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        contButton.SetActive(false);

        index = 16;

        if (index < 16)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            answer7.SetActive(true);
            answer8.SetActive(true);
            answer9.SetActive(true);

        }
    }

    public void goToRightAnswer3()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        contButton.SetActive(false);

        index = 18;

        if (index < 18)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            disgraced = false;
            finishedConversation = true;
        }
    }

    public void goToWrongAnswer()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);
        answer1.SetActive(false);

        contButton.SetActive(false);

        index = 20;

        if (index < 20)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            disgraced = true;
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
