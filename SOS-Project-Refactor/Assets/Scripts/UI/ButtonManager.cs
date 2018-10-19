using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public string previousScene = "Start Scene";

    public void STARTGAME()
    {
        SceneManager.LoadScene("Setup");
        previousScene = "Start Scene";
    }

    public void CREDITS()
    {
        SceneManager.LoadScene("Credits Scene");
        previousScene = "Start Scene";
    }

    public void HOWTOPLAY()
    {
        SceneManager.LoadScene("HowTo Scene");
        previousScene = "Start Scene";

    }
    public void BACK() {
        SceneManager.LoadScene("Start Scene");
    }

    public void QUITGAME()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
