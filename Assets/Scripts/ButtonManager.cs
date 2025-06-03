using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject winScreen;

    // Load the main game scene
    public void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    // Quit the game
    public void QuitButton()
    {
        Application.Quit();
    }

    // Continues playing the game even after winning
    public void ContinueButton()
    {
        winScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Returns to menu screen
    public void ReturnButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}