using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class increaseMeter : MonoBehaviour
{
    public playerControl playerControl;
    [SerializeField] private GameObject buttonManager;
    [SerializeField] private float increaseRate, glitchRate = 0.85f;
    [SerializeField] private float maxTime, minTime;
    [SerializeField] GameObject presentBG, pastBG, futureBG, mixBG, usualRoad, pastRoad;
    [SerializeField] GameObject[] futureRoads, pastRoads;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioClip defaultMusic, pastMusic, futureMusic;
    [SerializeField] private GameObject gameOver;
    private Slider slider;
    private bool spawnAble;
    

    private void Start()
    {
        slider = GetComponent<Slider>();
        audioSource.clip = defaultMusic;
        audioSource.Play();
        spawnAble = true;
    }

    private void Update()
    {
        if (slider.value < slider.maxValue) //checks if slider value is less than max value
        {
            slider.value += increaseRate * Time.deltaTime; //increase slider value in respect to time
        }

        if (slider.value > 8.5f && slider.value < 9) //increase slider when value between
        {
            pitchChanger();
            audioSource.clip = pastMusic;
            audioSource.Play();
            glitchEffectIncrease();
            if (spawnAble)
            {
                pastRoad = pastRoads[Random.Range(0, pastRoads.Length)];
                pastRoad.SetActive(true);
            }
            usualRoad.SetActive(false);
            GameManagement.gameStage = "past";
            spawnAble = false;
        }

        if (slider.value > 9f && slider.value < 14)
        {
            spawnAble = true;
            mixer.SetFloat("pitch", 1);
            glitchEffectDecrease();
            pastBG.SetActive(true);
            presentBG.SetActive(false);
        }

        if (slider.value > 14.5f && slider.value < 15)
        {
            pitchChanger();
            audioSource.clip = futureMusic;
            audioSource.Play();
            glitchEffectIncrease();
            if (spawnAble)
            {
                futureRoads[Random.Range(0, futureRoads.Length)].SetActive(true);
                pastRoad.SetActive(false);
            }
            GameManagement.gameStage = "future";
            spawnAble = false;
        }

        if (slider.value > 15f)
        {
            mixer.SetFloat("pitch", 1);
            glitchEffectDecrease();
            futureBG.SetActive(true);
            pastBG.SetActive(false);
        }

        if (slider.value > 25f && slider.value < 25.5f)
        {
            glitchEffectIncrease();
            pastRoad.SetActive(false);
            
            GameManagement.gameStage = "mix";
        }

        if (slider.value > 25.5f && slider.value < 26)
        {
            glitchEffectDecrease();
            mixBG.SetActive(true);
            futureBG.SetActive(false);
        }

        if (slider.value >= slider.maxValue)
        {
            gameOver.SetActive(true);
            playerControl.instance.controlAble = false;
            Time.timeScale = 0;
            buttonManager.GetComponent<ButtonManager>().pauseAvailable = false;
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

    private void pitchChanger()
    {
        float setVal = 0;
        if (returnVal() > 1)
        {
            setVal = returnVal();
            while (returnVal() < 1)
            {
                setVal += glitchRate * Time.unscaledDeltaTime;
                mixer.SetFloat("pitch", setVal);
            }
        }

        else
        {
            setVal = returnVal();
            while (returnVal() > 0.5f)
            {
                setVal -= Time.unscaledDeltaTime * glitchRate;
                mixer.SetFloat("pitch", setVal);
            }
        }
    }

    private float returnVal()
    {
        float pitchVal;
        mixer.GetFloat("pitch", out pitchVal);
        return pitchVal;
        
    }
}
