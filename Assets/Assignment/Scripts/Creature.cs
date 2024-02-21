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
        destination = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
        
    }
    private void FixedUpdate()
    {
        //creates a destination for the creature
        move = destination - (Vector2)transform.position;
        //stops it from moving when its almost at 0
        if (move.magnitude < 0.1)
        {
            move = Vector2.zero;
        }
        rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);

    }
    // Update is called once per frame
    void Update()
    {
        //checks if you click on the creature to command it
        if (Input.GetMouseButtonDown(0) && clicked == true) 
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            clicked = false;
        }
        animator.SetFloat("move", move.magnitude);
        
        if (lerpDie == true)
        {
            //lerp time :D
            //causes them to fall into the place they need to be
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
        

        //check for colour
        if (captured == 0) 
        {
            if (type == 0)
            {
                PlayerPrefs.SetFloat("Level", PlayerPrefs.GetFloat("Level") - 1);
                lerpDie = true;
                Destroy(gameObject, 1);
            }
            if (type == 1)
            {

                PlayerPrefs.SetFloat("Level", PlayerPrefs.GetFloat("Level")+10);
                //you lose
            }
        }
        if (captured == 1)
        {
            if (type == 0)
            {
                PlayerPrefs.SetFloat("Level", PlayerPrefs.GetFloat("Level") + 10);
                //you lose
            }
            if (type == 1)
            {
                PlayerPrefs.SetFloat("Level", PlayerPrefs.GetFloat("Level") - 1);
                lerpDie = true;
                Destroy(gameObject, 1);
            }
        }

        
    }
}
