using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UIElements;

public class Creature : MonoBehaviour
{
    Vector2 destination;
    Vector2 move;
    public float speed = 4;
    Rigidbody2D rb;
    Animator animator;
    Transform shrink;
    public AnimationCurve ac;
    bool clicked = false;
    // 0 for red, 1 for green
    public float type;
    public bool lerpDie = false;
    public float lerpTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shrink = GetComponent<Transform>();
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
            
            clicked = false;
        }
        animator.SetFloat("move", move.magnitude);
        
        if (lerpDie == true)
        {
            //lerp time :D
            lerpTimer += 1f * Time.deltaTime;
            float interpolation = ac.Evaluate(lerpTimer);
            shrink.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }
        
    }
    private void OnMouseUp()
    {
        animator.SetTrigger("picked");
        clicked = true;
    }
    public void captured(float captured)
    {
       

        animator.SetTrigger("captured");
        lerpDie = true;

        //check for colour
        if (captured == 0) 
        {
            if (type == 0)
            {
                Destroy(gameObject, 1);
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
               Destroy(gameObject, 1);
            }
        }

        
    }
}
