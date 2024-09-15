using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject pause, slider;
    public bool pauseAvailable;
    private void Start()
    {
        pauseAvailable = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pauseAvailable)
        {
            PauseSwitcher();
        }
    }

    public void PauseSwitcher()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        GameObject.Find("player").GetComponent<playerControl>().controlAble = !GameObject.Find("player").GetComponent<playerControl>().controlAble;
        pause.SetActive(!pause.activeSelf);
        slider.SetActive(!slider.activeSelf);
    }
}
