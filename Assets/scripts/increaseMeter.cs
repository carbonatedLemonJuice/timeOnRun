using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class increaseMeter : MonoBehaviour
{
    [SerializeField] private float increaseRate, glitchRate = 0.65f;
    [SerializeField] private float maxTime, minTime;
    [SerializeField] GameObject presentBG, mixBG;
    private Slider slider;
    

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value < slider.maxValue) //checks if slider value is less than max value
        {
            slider.value += increaseRate * Time.deltaTime; //increase slider value in respect to time
        }

        if (slider.value > 8.5f && slider.value < 9) //increase slider when value between
        {
            glitchEffectIncrease();
        }

        if (slider.value > 9f && slider.value < 15)
        {
            mixBG.SetActive(true);
            presentBG.SetActive(false);
            glitchEffectDecrease();
        }

        if (slider.value > 14.5f && slider.value < 15)
        {
            presentBG.SetActive(true);
            mixBG.SetActive(false);
            glitchEffectIncrease();
        }

        if (slider.value > 15f)
        {
            
            glitchEffectDecrease();
        }
    }

    private void glitchEffectDecrease()
    {
        while (Camera.main.GetComponent<DigitalGlitch>().intensity > 0)
        {
            Camera.main.GetComponent<DigitalGlitch>().intensity -= Time.deltaTime * (glitchRate + 2.5f);
        }
    }

    private void glitchEffectIncrease()
    {
        while (Camera.main.GetComponent<DigitalGlitch>().intensity < 0.6f)
        {
            Camera.main.GetComponent<DigitalGlitch>().intensity += glitchRate * Time.deltaTime;
        }
    }
}
