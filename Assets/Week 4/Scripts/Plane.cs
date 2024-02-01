using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastposition;
    LineRenderer lineRenderer;
    Rigidbody2D rb2d;
    Vector2 currentPosition;
    public float speed;
    public AnimationCurve landing;
    float timerValue;
    public Sprite[] sprites;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.Rotate(0, 0, Random.Range(-180,180));
        speed = Random.Range(1, 3);
        //populate array with sprites

        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
        
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            //rotate
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb2d.rotation = -angle;
        }
        rb2d.MovePosition(rb2d.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);
                for(int i = 0; i<lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }
    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastposition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastposition = newPosition;
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
      
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector3.Distance(currentPosition, collision.transform.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

