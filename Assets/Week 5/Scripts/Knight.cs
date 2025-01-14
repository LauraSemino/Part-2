using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    bool isDead = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = PlayerPrefs.GetFloat("Health", maxhealth);

        SendMessage("SetHealth", health);
    }
    private void FixedUpdate()
    {
        if (isDead) return;

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
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && clickingOnSelf == false && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
        if (health == 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }
    private void OnMouseDown()
    {
        if (isDead) return;

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

        PlayerPrefs.SetFloat("Health", health);

        if (health == 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }
        
    }
    

}
