using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;
    bool clickingOnSelf = false;
    public float health;
    public float maxhealth = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxhealth;
    }
    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickingOnSelf == false)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
    }
    private void OnMouseDown()
    {
        clickingOnSelf = true;
        SendMessage("takedamage",1);
        
    }
    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }
    public void takedamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxhealth);
        if(health == 0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("TakeDamage");
        }
        
    }
}
