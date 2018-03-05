using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void STARTGAME()
    {
        SceneManager.LoadScene("Setup");
    }

    public void CREDITS()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    public void HOWTOPLAY()
    {
        SceneManager.LoadScene("HowTo Scene");

    }


    public void QUITGAME()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
