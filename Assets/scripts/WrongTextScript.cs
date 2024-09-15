using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WrongTextScript : MonoBehaviour
{
    [SerializeField] float waitTime;

    private void OnEnable()
    {
        StartCoroutine(WrongTimer());
    }
    IEnumerator WrongTimer()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        gameObject.SetActive(false);
    }
}
