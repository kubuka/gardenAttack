using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Krasnal : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float speed = 1.5f;
    RaycastHit2D[] hit;
    public Transform placeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        hit = Physics2D.RaycastAll(placeToSpawn.position, transform.TransformDirection(Vector2.left), 0.0001f);

        foreach (var item in hit)
        {
            if(item.collider.tag == "tropy" || item.collider.tag == "kaktus" || item.collider.tag == "gravestone" || item.collider.tag == "motyl")
            {
                anim.SetTrigger("koniec");
                speed = 0;
            }
        }
            //ZAPAMIETAC LINQ DZIALA TYLKO Z JEDNYM IFEM
        if (!hit.Any(i => i.collider.GetComponent<gHealth>()))
        {
            if((!hit.Any(i => i.collider.GetComponent<motylek>())))
            {
                anim.SetTrigger("start");
                speed = 1.5f;
            }
            
        }
    }
    void FixedUpdate()
    {
        var newXpos = transform.position.x - speed * Time.fixedDeltaTime;
        transform.position = new Vector2(newXpos, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "cukinia")
        {
            GetComponent<eHealth>().Hurt();
        }
        if(collision.tag == "Shreder")
        {
            Destroy(gameObject);
        }
    }
}
