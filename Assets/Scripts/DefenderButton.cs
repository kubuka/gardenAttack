using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    public bool selected;
    public GameObject kaktusb;
    public GameObject tropy;
    public GameObject grave;
    public GameObject motyl;
    [SerializeField] DefenderButton[] lista;
    [SerializeField] Color32 a;
    
    public void OnMouseDown()
    {
        lista = FindObjectsOfType<DefenderButton>();
        foreach (var item in lista)
        {
           
            item.GetComponent<SpriteRenderer>().color = a;            
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        
    }
    private void Update()
    {
        foreach (var item in lista)
        {
            if(GetComponent<SpriteRenderer>().color == a)
            {
                selected = false;
            }
            else
            {
                selected = true;
            }
        }

        if(selected == true)
        {
            if(gameObject.tag == "kakbut")
            {
                FindObjectOfType<Mouse>().kaktus = kaktusb;
                FindObjectOfType<Mouse>().cost = 20;
            }
            else if(gameObject.tag == "tropbut")
            {
                FindObjectOfType<Mouse>().kaktus = tropy;
                FindObjectOfType<Mouse>().cost = 15;
            }else if(gameObject.tag == "gravbut")
            {
                FindObjectOfType<Mouse>().kaktus = grave;
                FindObjectOfType<Mouse>().cost = 10;
            }else if(gameObject.tag == "motbut")
            {
                FindObjectOfType<Mouse>().kaktus = motyl;
                FindObjectOfType<Mouse>().cost = 30;
            }
        }
    }
    private void Start()
    {
        lista = FindObjectsOfType<DefenderButton>();
        a = new Color32(41, 41, 41, 255);
        gameObject.GetComponent<SpriteRenderer>().color = a;
    }

}
