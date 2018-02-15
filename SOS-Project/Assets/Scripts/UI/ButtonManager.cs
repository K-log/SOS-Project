using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void STARTGAME()
    {
        SceneManager.LoadScene(1);
    }

    public void CREDITS()
    {
        SceneManager.LoadScene(2);
    }

    public void HOWTOPLAY()
    {
        SceneManager.LoadScene(3);

    }


    public void QUITGAME()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
