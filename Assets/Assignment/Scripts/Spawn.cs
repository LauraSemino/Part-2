using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Spawn : MonoBehaviour
{
    public GameObject redrobot;
    public GameObject greenrobot;
    public float timer;
    public int robotC;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<Transform>();
        redrobot.transform.position = spawn.position;
        greenrobot.transform.position = spawn.position;
        PlayerPrefs.SetFloat("Level", 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (timer <= 0)
        {
            robotC = Random.Range(0, 2);
            if(robotC == 0) 
            {
                PlayerPrefs.SetFloat("Level", PlayerPrefs.GetFloat("Level") + 1);
                Instantiate(redrobot);
            }
            if (robotC == 1)
            {
                PlayerPrefs.SetFloat("Level", PlayerPrefs.GetFloat("Level") + 1);
                Instantiate(greenrobot);
            }
            timer = Random.Range(1, 3);
        }
        timer -= 1f * Time.deltaTime;
    }
}
