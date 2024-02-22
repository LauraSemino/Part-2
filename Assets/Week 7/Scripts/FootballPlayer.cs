using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    
    Color normal;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        normal = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {

        Selected(true);

    }
    public void Selected(bool selected)
    {
        if (selected)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = normal;
        }
    }
}
