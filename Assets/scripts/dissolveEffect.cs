using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveEffect : MonoBehaviour
{
    private float decreaseVal = 1.5f;
    private float num = 1;

    private Material mat;

    private void Start()
    {;
        mat = GetComponent<SpriteRenderer>().material;
    }

    public void callFade()
    {
        StartCoroutine(fadeAway());
    }

    private IEnumerator fadeAway()
    {
        float elapsedTime = 0;
        while (mat.GetFloat("_fade") > 0)
        {
            num -= Time.deltaTime * decreaseVal;
            elapsedTime += Time.deltaTime;
            mat.SetFloat("_fade", num);
            yield return null;
            Debug.Log("num value is : " + num);
        }
    }
}
