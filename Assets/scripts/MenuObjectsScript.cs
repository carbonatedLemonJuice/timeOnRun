using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjectsScript : MonoBehaviour
{
    [SerializeField] private float velocity;
    private void Update()
    {
        this.transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destruct"))
        {
            if (this.CompareTag("vehicle"))
            {
                Destroy(gameObject);
            }
            else
            {
                this.transform.position = new Vector3(-17, this.transform.position.y, this.transform.position.z);
            }
        }
    }
}
