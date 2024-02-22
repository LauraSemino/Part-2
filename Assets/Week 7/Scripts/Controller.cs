using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Controller : MonoBehaviour
{
    
    public TextMeshProUGUI ScoreCount;
    public static float score;
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 1;
    Vector2 direction;
    public static FootballPlayer SelectedPlayer { get; private set; }
    public static void SetSelectedPlayer(FootballPlayer player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        SelectedPlayer = player;
        SelectedPlayer.Selected(true);
    }
    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }
    private void Update()
    {
        
        ScoreCount.text = score.ToString();

        if (SelectedPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            //start charge
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //increase charge 
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //release charge
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized * charge;
        }

       

    }
}
