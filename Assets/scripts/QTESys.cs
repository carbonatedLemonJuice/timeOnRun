using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{
    public static QTESys instance;

    public playerControl playerControl;
    [SerializeField] GameObject qteText, player, manager, wrong;
    public GameObject faultyObstacle;
    public KeyCode corKey;
    public float timeToPress;
    private TMP_Text myText;
    private Vector3 cameraDefault;
    [SerializeField] private CinemachineVirtualCamera cam;
    private float qteTimer;
    private bool fail;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        fail = false;
        StartCoroutine(AnyPressTime());
        StartCoroutine(timer()); //calling coroutine to switch camera and pause time
        playerControl.instance.controlAble = false;
        manager.GetComponent<ButtonManager>().pauseAvailable = false;
        qteTimer = 0;
        StartCoroutine(TimeToFail());
    }

    IEnumerator AnyPressTime()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        fail = true;
    }

    IEnumerator TimeToFail()
    {
        //time before QTE fails
        yield return new WaitForSecondsRealtime(timeToPress);
        FailActions();
    }
    private void Update()
    {
        qteTimer += Time.unscaledDeltaTime;
        if (Input.GetKeyDown(corKey))
        {
            if (faultyObstacle.name == "ThreeHoles(Clone)")
            {
                if (Random.Range(0, 3) == 1)
                {
                    playerControl.instance.isGoingForward = true;
                    playerControl.instance.GoForwardStart(1.8f);
                }
            }
            else
            {
                playerControl.instance.isGoingBack = true;
                playerControl.instance.GoBackStart(qteTimer);
            }
            QTEOut();
        }
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.keyCode != corKey && fail)
        {
            FailActions();
        }
        else if (e.isKey && fail)
        {
            fail = false;
        }
    }

    private void FailActions()
    {
        QTEOut();
        playerControl.instance.isGoingBack = true;
        playerControl.instance.GoBackStart(timeToPress);
        wrong.SetActive(true);
    }

    private void QTEOut()
    {
        //default view of camera etc.
        playerControl.instance.controlAble = true;
        faultyObstacle.GetComponent<BoxCollider2D>().enabled = false;
        faultyObstacle.GetComponent<obstacleBehaviour>().speed = 0;
        faultyObstacle.GetComponent<dissolveEffect>().callFade();
        Time.timeScale = 1f;
        GameObject.Find("Manager").GetComponent<ButtonManager>().backToPause = true;
        cam.Priority = 0;
        this.gameObject.SetActive(false);
    }
    
    private IEnumerator timer()
    {
        cam.Priority = 10;
        yield return new WaitForSeconds(0.15f); //changing priority is time dependant, if timescale set to zero, it wont work;
        Time.timeScale = 0;
        if (!faultyObstacle.gameObject.GetComponent<obstacleBehaviour>().isLong)
            faultyObstacle.gameObject.transform.position = new Vector3(player.transform.position.x + 1.5f, faultyObstacle.gameObject.transform.position.y, faultyObstacle.gameObject.transform.position.z);
        else
            faultyObstacle.gameObject.transform.position = new Vector3(player.transform.position.x + 2.5f, faultyObstacle.gameObject.transform.position.y, faultyObstacle.gameObject.transform.position.z);
    }
}