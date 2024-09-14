using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class increaseMeter : MonoBehaviour
{
    [SerializeField] private float increaseRate, glitchRate = 0.65f;
    [SerializeField] private float maxTime, minTime;
    [SerializeField] GameObject presentBG, pastBG, futureBG, mixBG, usualRoad;
    [SerializeField] GameObject[] futureRoads;
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
            GameManagement.gameStage = "past";
        }

        if (slider.value > 9f && slider.value < 15)
        {
            glitchEffectDecrease();
            pastBG.SetActive(true);
            presentBG.SetActive(false);
        }

        if (slider.value > 14.5f && slider.value < 15)
        {
            glitchEffectIncrease();
            futureBG.SetActive(true);
            pastBG.SetActive(false);
            futureRoads[Random.Range(0, futureRoads.Length)].SetActive(true);
            usualRoad.SetActive(false);
            GameManagement.gameStage = "future";
        }

        if (slider.value > 15f)
        {
            glitchEffectDecrease();
            futureBG.SetActive(false);
            mixBG.SetActive(true);
            GameManagement.gameStage = "mix";
        }
    }

    private void glitchEffectDecrease()
    {
        while (Camera.main.GetComponent<DigitalGlitch>().intensity > 0)
        {
            Camera.main.GetComponent<DigitalGlitch>().intensity -= Time.unscaledDeltaTime * (glitchRate + 2.5f);
        }
    }

    private void glitchEffectIncrease()
    {
        while (Camera.main.GetComponent<DigitalGlitch>().intensity < 0.6f)
        {
            Camera.main.GetComponent<DigitalGlitch>().intensity += glitchRate * Time.unscaledDeltaTime;
        }
    }
}
