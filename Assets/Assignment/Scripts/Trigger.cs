using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    //Set 0 for red, 1 for green

    public float colour;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("captured", colour, SendMessageOptions.DontRequireReceiver);

    }
}
