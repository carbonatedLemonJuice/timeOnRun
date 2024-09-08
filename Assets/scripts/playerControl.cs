using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] private float maxYvalue, minYvalue; //allocates maximum and minimum y value player position can have
    [SerializeField] private float yDifferenceVal; //allocates the distance between two consequitive position
    private float currentYvalue; //stores current y value of player

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentYvalue = transform.position.y; //takes current y position of player
            if (currentYvalue > minYvalue) //checks if current y greater than min y
            {
                //if so, moves the player down
                Debug.Log("down arrow pressed");
                currentYvalue -= yDifferenceVal;
                transform.position = new Vector3(transform.position.x, currentYvalue, transform.position.z);
            }
        }

        else if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            currentYvalue = transform.position.y;//takes current y position of player
            if (currentYvalue < maxYvalue) //checks if current y less than max y
            {
                //if so, moves player up
                Debug.Log("up arrow pressed");
                currentYvalue += yDifferenceVal;
                transform.position = new Vector3(transform.position.x, currentYvalue, transform.position.z);
            }
        }
    }
}
