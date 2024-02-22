using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    
    Color normal;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normal = sr.color;
        Selected(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {

        Controller.SetSelectedPlayer(this);

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
    public void Move(Vector2 direction)
    { 
        rb.AddForce(direction * speed);
    }
}
