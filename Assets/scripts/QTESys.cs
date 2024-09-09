using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{
    [SerializeField] GameObject qteText, player;
    public GameObject faultyObstacle;
    public KeyCode corKey;
    public float timeToPress;
    private TMP_Text myText;
    private Vector3 cameraDefault;
    [SerializeField] private CinemachineVirtualCamera cam;

    private void OnEnable()
    {
        
        StartCoroutine(timer()); //calling coroutine to switch camera and pause time
        player.GetComponent<playerControl>().controlAble = false;
        StartCoroutine(TimeToFail());
    }

    IEnumerator TimeToFail()
    {
        //time before QTE fails
        yield return new WaitForSecondsRealtime(timeToPress);
        QTEOut();
        player.GetComponent<playerControl>().isGoingBack = true;
        player.GetComponent<playerControl>().GoBackStart(1f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(corKey))
        {
            if (faultyObstacle.name == "obstacle_4(Clone)")
            {
                player.GetComponent<playerControl>().isGoingForward = true;
                player.GetComponent<playerControl>().GoForwardStart(0.5f);
            }
            else
            {
                player.GetComponent<playerControl>().isGoingBack = true;
                player.GetComponent<playerControl>().GoBackStart(0.5f);
            }
            QTEOut();
        }
    }

    private void QTEOut()
    {
        //default view of camera etc.
        player.GetComponent<playerControl>().controlAble = true;
        Destroy(faultyObstacle);
        Time.timeScale = 1f;
        cam.Priority = 0;
        this.gameObject.SetActive(false);
    }
    
    private IEnumerator timer()
    {
        cam.Priority = 10;
        yield return new WaitForSeconds(0.15f); //changing priority is time dependant, if timescale set to zero, it wont work;
        Time.timeScale = 0;
    }

}