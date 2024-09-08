using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] private float maxYvalue, minYvalue; //allocates maximum and minimum y value player position can have
    [SerializeField] private float yDifferenceVal; 
    private float currentYvalue; //stores current y value of player

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentYvalue = transform.position.y;
            if (currentYvalue > minYvalue)
            {
                Debug.Log("down arrow pressed");
                currentYvalue -= yDifferenceVal;
                transform.position = new Vector3(transform.position.x, currentYvalue, transform.position.z);
            }
        }

        else if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            currentYvalue = transform.position.y;
            if (currentYvalue < maxYvalue)
            {
                Debug.Log("up arrow pressed");
                currentYvalue += yDifferenceVal;
                transform.position = new Vector3(transform.position.x, currentYvalue, transform.position.z);
            }
        }
    }
}
