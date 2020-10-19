using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gHealth : MonoBehaviour
{
    public float health = 100;
    int speed;
    Lizard liz;
    Fox fox;
    List<GameObject> lista = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        liz = FindObjectOfType<Lizard>();
        fox = FindObjectOfType<Fox>();
    }

    private void Update()
    {
        //Debug.Log(lista.Count);
        if (health <= 0)
        {
            foreach (var item in lista)
            {
                if(item.GetComponent<Lizard>() != null)
                {
                    item.GetComponent<Lizard>().KoniecJedzenia(1);                  
                }
                if (item.GetComponent<Fox>() != null)
                {
                    item.GetComponent<Fox>().BackToNormal2(2);                   
                }                
            }
            Destroy(gameObject);         
        }
    }
    public void Hurting()
    {
        health -= 1.52f;            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Lizard>() != null)
        {
            lista.Add(collision.gameObject);
        }else if(collision.GetComponent<Fox>() != null)
        {
            lista.Add(collision.gameObject);
        }
       
    }
}
