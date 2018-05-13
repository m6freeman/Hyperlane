using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Help()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Stats()
    {
        SceneManager.LoadScene("Stats");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Options");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
