using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DangerLevel : MonoBehaviour
{
    public Slider danger;

    public void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        danger.value = PlayerPrefs.GetFloat("Level", 0);
        if (PlayerPrefs.GetFloat("Level") >= 10)
        {            
            
            SceneManager.LoadScene(nextSceneIndex);

        }
    }
}
