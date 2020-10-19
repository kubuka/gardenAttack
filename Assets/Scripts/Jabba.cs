using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jabba : MonoBehaviour
{
    float speed = 1.5f;
    Animator anim;
    eHealth eH;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        eH = GetComponent<eHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newXpos = transform.position.x - speed * Time.fixedDeltaTime;
        transform.position = new Vector2(newXpos, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shreder")
        {
          
            Destroy(gameObject);
        }

        if(collision.tag == "cukinia")
        {
            eH.Hurt();
        }

        
    }
}
