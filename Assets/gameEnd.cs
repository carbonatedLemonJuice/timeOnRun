using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("you won noiceee");
        }
    }
}
