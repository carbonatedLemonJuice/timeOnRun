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


    private void OnEnable()
    {
        Time.timeScale = 0;
        //Camera zoom
        Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        Camera.main.orthographicSize = 2;
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
        Camera.main.transform.position = new Vector3(0, 0, -10);
        Camera.main.orthographicSize = 5;
        Destroy(faultyObstacle);
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

}
