using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int Health;
    public Slider health_slider;

    private const int MAX_HEALTH = 100;

    private void Start()
    {
        Health = MAX_HEALTH;
    }
    public void DecreaseHealth(int amountOfHealth)
    {
        Health -= amountOfHealth;
        health_slider.value = Health;
        if(Health <= 0)
        {
            //player is dead
            Destroy(gameObject);
            Debug.Log("you are dead ");
        }
    }
}
