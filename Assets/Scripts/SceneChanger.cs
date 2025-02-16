using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public void GoToCredits() {
        SceneManager.LoadScene("CreditsScene");

    }

    public void GoToTitle() {
        SceneManager.LoadScene("TitleScene");

    }

    public void GoToGame() {
        SceneManager.LoadScene("SampleScene");

    }

    public void GoToEnding1() {

    }

    public void GoToEnding2() {

    }

    public void GoToEnding3() {

    }

    public void GoToEnding4() {

    }

}
