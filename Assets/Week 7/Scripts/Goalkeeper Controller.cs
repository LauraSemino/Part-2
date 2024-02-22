using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 direction;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.SelectedPlayer == null) return;
       
        direction = (Vector2)transform.position - (Vector2)Controller.SelectedPlayer.transform.position;
        distance = direction.magnitude;
        direction.Normalize(); 
    }
    private void FixedUpdate()
    {
        if(distance/2 < 2.5f)
        {
            rb.position = (Vector2)transform.position - direction * distance / 2;
        }
        else
        {
            rb.position = (Vector2)transform.position - direction * 2.5f;
        }
    }
}
