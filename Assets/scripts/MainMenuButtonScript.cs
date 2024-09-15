using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    public void MainMenuPressed()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}