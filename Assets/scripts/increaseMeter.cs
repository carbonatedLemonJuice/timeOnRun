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
        if (slider.value < slider.maxValue) //checks if slider value is less than max value
        {
            slider.value = slider.value + increaseRate * Time.deltaTime; //increase slider value in respect to time
        }
    }
}
