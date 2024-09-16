using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class decreaseDissolve : MonoBehaviour
{
    private float num;
    [SerializeField] private Material mat, mat2;
    private bool coroutine;

    void Start()
    {
        coroutine = true;
        num = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        if (coroutine)
        {
            StartCoroutine(fadeAway());
        }
    }

    private IEnumerator fadeAway()
    {
        coroutine = false;
        while (mat.GetFloat("_fade") > 0)
        {
            num -= Time.deltaTime * 0.45f;
            mat.SetFloat("_fade", num);
            mat2.SetFloat("_fade", num);
            yield return null;
        }
        
    }
}
