using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    [SerializeField] GameObject pause, slider;
    public bool pauseAvailable, backToPause;
    [SerializeField] private GameObject tutorial, player;

    private void Start()
    {
        instance = this;
        pauseAvailable = true;
        backToPause = false;
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pauseAvailable)
        {
            pauseGame();
        }

        tutorialActive();
        //Debug.Log(pauseAvailable);

        if (backToPause)
        {
            pauseAvailable = true;
            backToPause = false;
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        slider.SetActive(false);
        player.GetComponent<playerControl>().controlAble = false;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        slider.SetActive(true);
        pauseAvailable = true;
        player.GetComponent<playerControl>().controlAble = true;   
    }

    private void tutorialActive()
    {
        if (tutorial.activeInHierarchy)
        {
            pauseAvailable = false;
        }
    }
}
