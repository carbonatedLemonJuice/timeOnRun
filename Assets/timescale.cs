using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timescale : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Material mat;

    void Start()
    {
        if (mat != null)
        {
            mat.SetFloat("_fade", 1);
        }

        Time.timeScale = 1;   
    }
}
