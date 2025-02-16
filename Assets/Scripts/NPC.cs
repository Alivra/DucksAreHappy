using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    public GameObject dialougePanel;
    public Text dialougeText;
    public string[] dialouge;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    void Start() {
        zeroText();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose) {
            if (dialougePanel.activeInHierarchy) {
                zeroText();

            } else {
                dialougePanel.SetActive(true);
                StartCoroutine(Typing());

            }

        }

    }

    public void zeroText() {
        dialougeText.text = "";
        index = 0;
        dialougePanel.SetActive(false);

    }

    IEnumerator Typing() {
        foreach(char letter in dialouge[index].ToCharArray()) {
            dialougeText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }

    }

    public void NextLine() {
        if(index < dialouge.Length - 1) {
            index++;
            dialougeText.text = "";
            StartCoroutine(Typing());

        } else {
            zeroText();

        }

    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsClose = false;
            zeroText();

        }

    }

}
