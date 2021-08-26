using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField]
    Text BulletsCounter;
    [SerializeField]
    Text HealthCounter;
    void Awake()
    {
        FindObjectOfType<PlayerShooting>().OnBulletsChanged += bullets =>
        {
            BulletsCounter.text = bullets.ToString();
        };
        FindObjectOfType<Player>().GetComponent<Entity>().OnHealthChange += health =>
        {
            HealthCounter.text = health.ToString();
        };
    }

   
    void Update()
    {
        
    }
}
