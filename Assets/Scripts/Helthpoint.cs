using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Helthpoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public int health = 999;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(health.ToString());
        if(health < 0)
        {
            health = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(health > 0)
        {
            if (collision.GetComponent<Lizard>() != null || collision.GetComponent<Jabba>() != null)
            {
                health -= 10;
            }
            else if (collision.GetComponent<Fox>() != null || collision.GetComponent<Krasnal>() != null)
            {
                health -= 15;
            }
        }
        
    }
}
