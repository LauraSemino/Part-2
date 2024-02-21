using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    Vector2 destination;
    Vector2 move;
    public float speed = 4;
    Rigidbody2D rb;
    Animator animator;
    bool clicked = false;
    // 0 for red, 1 for green
    public float type;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = Camera.main.transform.position;
    }
    private void FixedUpdate()
    {
        move = destination - (Vector2)transform.position;
        if (move.magnitude < 0.1)
        {
            move = Vector2.zero;
        }
        rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clicked == true) 
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetTrigger("move");
            clicked = false;
        }
    }
    private void OnMouseUp()
    {
        clicked = true;
    }
    public void captured(float captured)
    {
        //play death animation

        //check for colour
        if (captured == 0) 
        {
            if (type == 0)
            {
                Destroy(gameObject);
            }
            if (type == 1)
            {
                //you lose
            }
        }
        if (captured == 1)
        {
            if (type == 0)
            {
                //you lose
            }
            if (type == 1)
            {
                Destroy(gameObject);
            }
        }

        
    }
}
