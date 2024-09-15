using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackOutScript : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(BlackOut());
    }

    IEnumerator BlackOut()
    {
        for (float i = 0; i < 1; i += Time.unscaledDeltaTime * 0.5f)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, i);
            yield return null;
        }
        SceneManager.LoadScene(3);
    }
}
