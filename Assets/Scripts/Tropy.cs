using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tropy : MonoBehaviour
{
    bool looping = true;
    CoinSystem cs;
    [SerializeField] Animator anim;
    Star star;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        star = GetComponentInChildren<Star>();
        do
        {           
            yield return new WaitForSeconds(5);
            cs = FindObjectOfType<CoinSystem>();
            star.Launch();
            cs.AddCoin(4);
            
        } while (looping == true);
              
    }

    public void basicAnim()
    {
        anim.SetTrigger("a");
    }
    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
    
}
