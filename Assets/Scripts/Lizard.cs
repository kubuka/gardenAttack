using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    float speed = 1.5f;
    public Animator anim;
    eHealth eH;
    gHealth gh;
    bool a = true;
    

    private void Start()
    {
        eH = GetComponent<eHealth>();
        gh = FindObjectOfType<gHealth>();
    }

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
        }else if (collision.tag == "cukinia")
        {
            eH.Hurt();
        }else if(collision.tag == "tropy" || collision.tag == "kaktus" || collision.tag == "gravestone" || collision.tag == "motyl")
        {
            anim.SetTrigger("onObject");           
            speed = 0;
            StartCoroutine(Jedzenie());
            
        }
        IEnumerator Jedzenie()
        {
            do
            {
                if (collision != null)
                {
                    if(collision.GetComponent<gHealth>() != null)
                    {
                        a = true;
                        collision.GetComponent<gHealth>().Hurting();
                        yield return new WaitForSeconds(0.001f);
                    }
                    else
                    {
                        a = true;                        
                        yield return new WaitForSeconds(0.001f);
                    }
                    
                }
                else
                {
                    break;
                }
                                
            } while (a);

        }
    }
    public void Walk(float speed)
    {
        this.speed = speed;
    }
    public void SetTriggerToWalkAfterJump()
    {
        anim.SetTrigger("afterJump");
    }

    public void KoniecJedzenia(int speed)
    {
        anim.SetTrigger("killed");
        this.speed = speed;
        a = false;
    }
    
    
}
