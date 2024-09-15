using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject pause, slider;
    public bool pauseAvailable;
    [SerializeField] private GameObject tutorial, player;

    private void Start()
    {
        pauseAvailable = true;
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pauseAvailable)
        {
            pauseGame();
        }

        tutorialActive();

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
