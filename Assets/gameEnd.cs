using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEnd : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject buttonManager;
    public playerControl playerControl;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("you won noiceee");
        }

        if (collision.CompareTag("gameOver"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            buttonManager.GetComponent<ButtonManager>().pauseAvailable = false;
            playerControl.controlAble = false;
        }
    }
}
