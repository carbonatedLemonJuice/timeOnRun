using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    public void MainMenuPressed(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
        GameManagement.gameStage = "default";

    }
}
