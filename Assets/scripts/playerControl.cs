using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] private int currentLine = 0; //allocates maximum and minimum y value player position can have
    [SerializeField] private float yDifferenceVal; //allocates the distance between two consequitive position
    [SerializeField] private GameObject qteSys, timeEnt;
    public bool controlAble;
    private float speed = 0.1f;
    private float speedBack = 6;
    private float currentYvalue; //stores current y value of player
    public bool isGoingForward = false;
    public bool isGoingBack = false;
    private float timeBack = 0;

    private void Start()
    {
        controlAble = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && controlAble)
        {
            currentYvalue = transform.position.y; //takes current y position of player
            if (currentLine <= 3) //checks if current y greater than min y
            {
                //if so, moves the player down
                Debug.Log("down arrow pressed");
                currentYvalue -= yDifferenceVal;
                currentLine += 1;
                transform.position = new Vector3(transform.position.x, currentYvalue, transform.position.z);
            }
        }

        else if (Input.GetKeyDown (KeyCode.UpArrow) && controlAble)
        {
            currentYvalue = transform.position.y;//takes current y position of player
            if (currentLine >= 1) //checks if current y less than max y
            {
                //if so, moves player up
                Debug.Log("up arrow pressed");
                currentYvalue += yDifferenceVal;
                currentLine -= 1;
                transform.position = new Vector3(transform.position.x, currentYvalue, transform.position.z);
            }
        }
        if (!isGoingForward && !isGoingBack)
        {
            timeEnt.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (isGoingBack)
        {
            timeEnt.transform.Translate(Vector3.right * speedBack * Time.deltaTime);
        }
        else
        {
            timeEnt.transform.Translate(Vector3.left * speedBack * Time.deltaTime);

        }
    }

    public void GoBackStart(float timeToBack)
    {
        StartCoroutine(GoBack(timeToBack));
    }

    IEnumerator GoBack(float timeToBack)
    {
        //time of going back (punishment for crash)
        yield return new WaitForSeconds(timeToBack);
        isGoingBack = false;
    }
    public void GoForwardStart(float timeToBack)
    {
        StartCoroutine(GoForward(timeToBack));
    }

    IEnumerator GoForward(float timeToBack)
    {
        //time of going back (punishment for crash)
        yield return new WaitForSeconds(timeToBack);
        isGoingForward = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            qteSys.SetActive(true);
            qteSys.GetComponent<QTESys>().faultyObstacle = collision.gameObject;
            if (!collision.gameObject.GetComponent<obstacleBehaviour>().isLong)
                collision.gameObject.transform.position = new Vector3(this.transform.position.x + 1.5f, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            else
                collision.gameObject.transform.position = new Vector3(this.transform.position.x + 2.5f, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
        }
        if (collision.CompareTag("destruct"))
        {
            Destroy(gameObject);
        }
    }
}
