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
    private bool gotChallenged = false;

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

        if (finishedConversation)
        {
            StartCoroutine(MoveUpwards());
        }
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
                index = 21;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (finishedConversation)
            {
                index = 25;
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
            else if (index == 6 || index == 9 || index == 21)
            {
                choice3.SetActive(true);
                choice4.SetActive(true);
            }
            else if (gotChallenged)
            {
                index = 10;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else
            {
                contButton.SetActive(true);
            }
        }
    }
    public float moveSpeed = 2f; // Speed of movement
    public float duration = 3f;  // Time in seconds to move up

    private IEnumerator MoveUpwards()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
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
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

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
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        index = 2;

        if (index < 7)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            gotChallenged = true;
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
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        index = 7;

        if (index < 10)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            gotChallenged = true;
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
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        index = 22;

        if (index < 23)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            disgraced = true;

        }
        else
        {
            zeroText();
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
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        index = 10;

        if (index < 11)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            answer1.SetActive(true);
            answer2.SetActive(true);
            answer3.SetActive(true);
        }
        else
        {
            //answer1.SetActive(true);
            //answer2.SetActive(true);
            //answer3.SetActive(true);

        }
    }

    public void goToRightAnswer1()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        contButton.SetActive(false);

        index = 12;

        if (index < 13)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            answer4.SetActive(true);
            answer5.SetActive(true);
            answer6.SetActive(true);
        }
        else
        {
            //answer4.SetActive(true);
            //answer5.SetActive(true);
            //answer6.SetActive(true);

        }
    }

    public void goToRightAnswer2()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        contButton.SetActive(false);

        index = 14;

        if (index < 15)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            answer7.SetActive(true);
            answer8.SetActive(true);
            answer9.SetActive(true);
        }
        else
        {
            //answer7.SetActive(true);
            //answer8.SetActive(true);
            //answer9.SetActive(true);

        }
    }

    public void goToRightAnswer3()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        contButton.SetActive(false);

        index = 16;

        if (index < 17)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            disgraced = false;
            finishedConversation = true;

        }
        else
        {
            zeroText();
        }
    }

    public void goToWrongAnswer()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

        answer1.SetActive(false);
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        answer7.SetActive(false);
        answer8.SetActive(false);
        answer9.SetActive(false);

        contButton.SetActive(false);

        index = 18;

        if (index < 19)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            disgraced = true;

        }
        else
        {
            zeroText();
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
