using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaneSpawn : MonoBehaviour
{
    public GameObject plane;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(plane);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {
            Instantiate(plane);
            timer = Random.Range(1, 5);
        }
        timer -= 1f * Time.deltaTime;
    }
}
