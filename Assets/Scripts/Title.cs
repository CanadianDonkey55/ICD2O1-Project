using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    void Update()
    {
        // Check for any button press to load the main menu
        if (Input.anyKeyDown) SceneManager.LoadScene(0);   
    }
}