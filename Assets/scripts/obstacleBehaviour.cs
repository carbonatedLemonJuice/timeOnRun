using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); //sets movement behavour to obstacle(s)
    }

    private void OnTriggerEnter2D(Collider2D collision) //destroys obstacles in case its out of screen
    {
        if (collision.CompareTag("destruct"))
        {
            Destroy(gameObject);
        }
    }
}
