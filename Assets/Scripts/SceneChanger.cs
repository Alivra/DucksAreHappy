using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void GoToCredits() {
        SceneManager.LoadScene("CreditsScene");

    }

    public void GoToTitle() {
        SceneManager.LoadScene("TitleScene");

    }

    public void GoToGame() {
        SceneManager.LoadScene("SampleScene");

    }

    public void GoToShredE() {
        SceneManager.LoadScene("shredE");
    }

    public void GoToShredI() {
        SceneManager.LoadScene("shredI");
    }

    public void GoToLeave() {
        SceneManager.LoadScene("Leave");

    }

    public void GoToEat() {
        SceneManager.LoadScene("Eat");

    }

}
