using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPrinter : MonoBehaviour {
    // get the string and the TMT_Text
    string textToType = "This is the line to print.";
    TMP_Text subtitleTextMesh;

    void Awake() {
        // Get the TMP_Text component
        subtitleTextMesh = GetComponent<TMP_Text>();

    }

    // Start is called before the first frame update
    void Start() {
        // Call TypeTextCO() to type the text
        StartCoroutine(TypeTextCO());

    }

    IEnumerator TypeTextCO() {
        // Clear the text before typing
        subtitleTextMesh.text = string.Empty;

        // Loop through each character and add it to the text
        for (int index = 0; index < textToType.Length; index++) {
            subtitleTextMesh.text += textToType[index];
            yield return new WaitForSeconds(0.05f);

        }

        yield return null;

    }

}
