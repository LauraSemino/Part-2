using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    public void SetHealth(float h)
    {
        slider.value = PlayerPrefs.GetFloat("Health", h);
    }
    public void takedamage(float damage)
    {
        slider.value -= damage;
    }
    
}
