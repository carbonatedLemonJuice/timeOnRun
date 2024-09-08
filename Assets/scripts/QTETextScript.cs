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
        GetComponent<TMP_Text>().text = buttons[Random.Range(0, 3)];
        //asigning of the correct key to press
        switch (GetComponent<TMP_Text>().text)
        {
            case "[Q]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.Q;
                break;
            case "[P]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.P;
                break;
            case "[U]":
                QTE.GetComponent<QTESys>().corKey = KeyCode.U;
                break;
        }
    }
}
