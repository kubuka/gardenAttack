using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motylek : MonoBehaviour
{
    List<GameObject> listasmierci;
    int speed = -1;
    bool activate = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        listasmierci = new List<GameObject>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newXpos = transform.position.x - speed * Time.fixedDeltaTime;
        transform.position = new Vector2(newXpos, transform.position.y);
    }

    private void Update()
    {
       
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shreder")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "enemy")
        {
            
            if(listasmierci.Count == 0)
            {
                if(collision.GetComponent<Jabba>() == null)
                {
                    speed = 0;
                    listasmierci.Add(collision.gameObject);
                    anim.SetTrigger("wybuch");
                }
                
            }
            else if(collision.GetComponent<Jabba>() == null)
            {
                listasmierci.Add(collision.gameObject);
            }
                      
        }
    }
    public void Wybuch()
    {
            foreach (var item in listasmierci)
            {
                if(item == null)
                {
                Destroy(gameObject);
            }
                else
                {
                    item.GetComponent<eHealth>().HurtAsMotyl(500);
                }                 
            }
        Destroy(gameObject);
    }
}
