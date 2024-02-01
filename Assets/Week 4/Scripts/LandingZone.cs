using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{
    Rigidbody2D rb;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (rb.OverlapPoint(new Vector2(collision.transform.position.x, collision.transform.position.y)))
        {
            collision.gameObject.GetComponent<Plane>().landed = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        score += 0.5f;
    }
}
