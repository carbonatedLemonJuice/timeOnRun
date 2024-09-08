using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class increaseMeter : MonoBehaviour
{
    [SerializeField] private float increaseRate;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value < slider.maxValue)
        {
            slider.value = slider.value + increaseRate * Time.deltaTime;
        }
    }
}
