using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float timer;
    public float speed = 3;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        rb.MovePosition(rb.position + (Vector2)transform.right * -speed * Time.deltaTime);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("takedamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);

    }
}
