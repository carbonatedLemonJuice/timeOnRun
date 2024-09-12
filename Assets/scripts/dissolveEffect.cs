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

    public void callFade() //public function that starts coroutine fadeAway()
    {
        StartCoroutine(fadeAway());
    }

    private IEnumerator fadeAway()
    {
        while (mat.GetFloat("_fade") > 0) //runs while fade value in material is greater than zero
        {
            num -= Time.deltaTime * decreaseVal; //decrease a num value over time
            mat.SetFloat("_fade", num); //sets num to fade in material
            yield return null;
            Debug.Log("num value is : " + num);
        }
    }
}
