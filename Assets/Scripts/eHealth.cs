using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class eHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    int dmg = 50;
    SceneLoader sl;
    Cactus cac;    
    public GameObject partikle;
    [SerializeField] AudioClip ass;

    private void Start()
    {
        sl = FindObjectOfType<SceneLoader>();
        cac = FindObjectOfType<Cactus>();
        if(sl.time <= 150f )
        {
            if (gameObject.GetComponent<Krasnal>() == null)
            {
                health += 50;
            }
            if (sl.time <= 90f)
            {
                if (gameObject.GetComponent<Krasnal>() == null)
                {
                    health += 50;
                }
                else if (gameObject.GetComponent<Krasnal>() != null)
                {

                    health += 100;
                }
            }
        }
    }

    private void Update()
    {
        
        //dmg = cac.dmg;
        if(health <= 0)
        {
            //var a = Instantiate(partikle, transform.position, Quaternion.identity) as GameObject;           
            AudioSource.PlayClipAtPoint(ass, Camera.main.transform.position,0.01f);
            //Destroy(a, 1f);
            FindObjectOfType<CoinSystem>().AddCoin(3);
            Destroy(gameObject);
        }
    }

    public void Hurt()
    {
        health = health - dmg;
    }
    public void HurtAsMotyl(int dmg)
    {
        health = health - dmg;
    }
}
