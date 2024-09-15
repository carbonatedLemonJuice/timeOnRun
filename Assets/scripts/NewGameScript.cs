using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour
{
    public void NewGamePressed()
    {
        SceneManager.LoadScene(1);
    }
}
