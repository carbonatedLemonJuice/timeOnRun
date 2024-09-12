using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QTETextScript : MonoBehaviour
{

    TMP_Text myText;
    [SerializeField] string[] buttons;
    [SerializeField] GameObject QTE;

    private void OnEnable()
    {
        GetComponent<TMP_Text>().text = buttons[Random.Range(0, 6)];
        //asigning of the correct key to press
        switch (GetComponent<TMP_Text>().text)
        {
            case "[Q]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.Q;
                break;
            case "[E]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.E;
                break;
            case "[T]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.T;
                break;
            case "[R]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.R;
                break;
            case "[W]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.W;
                break;
            case "[S]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.S;
                break;
        }
    }
}
