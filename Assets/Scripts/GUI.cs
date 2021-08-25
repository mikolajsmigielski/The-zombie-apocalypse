using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField]
    Text BulletsCounter;
    void Awake()
    {
        FindObjectOfType<PlayerShooting>().OnBulletsChanged += bullets =>
        {
            BulletsCounter.text = bullets.ToString();
        };
    }

   
    void Update()
    {
        
    }
}
