using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public Animator anim;
    [SerializeField] float speed = 2.5f;
    public RaycastHit2D[] hit;
    [SerializeField] Transform nos;
    bool a = false;
    eHealth eh;
    
    // Start is called before the first frame update
    void Start()
    {
        eh = GetComponent<eHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newXpos = transform.position.x - speed * Time.fixedDeltaTime;
        transform.position = new Vector2(newXpos, transform.position.y);
    }

    private void Update()
    {
        hit = Physics2D.RaycastAll(nos.position, transform.TransformDirection(Vector2.left), 1f);
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "kaktus" || collision.tag == "tropy" || collision.tag == "gravestone")
        {
            if (hit.Length <= 2)
            {

                anim.SetTrigger("jump");
            }
            else if (hit.Length > 2)
            {
                anim.SetTrigger("jedzenie");
                speed = 0;
                StartCoroutine(Jedzenie());
            }

            
        }
        //to sie tyczy tego ze liz nie przeskakuje nad motylem bo lata cnie
        if(collision.tag == "motyl")
        {
            anim.SetTrigger("jedzenie");
            speed = 0;
            StartCoroutine(Jedzenie());
        }
        IEnumerator Jedzenie()
        {
            do
            {
                if (collision != null)
                {
                    if (collision.GetComponent<gHealth>() != null)
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
        if(collision.tag == "Shreder")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "cukinia")
        {
            eh.Hurt();
        }
    }

        void BackToNormal()

        {
            anim.SetTrigger("normal");           
        }

    public void BackToNormal2(int speed)
       {
            anim.SetTrigger("nor");
            this.speed = speed;
       }
        
    

}
