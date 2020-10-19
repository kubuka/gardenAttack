using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cactus : MonoBehaviour
{
    public GameObject ogor;
    public Transform placeToSpawn;
    [SerializeField] public int dmg = 50;
    public Animator anim;
    public RaycastHit2D[] hit;
    const string SHOOT_NAME = "Shoot";
    GameObject shootParent;

    void Start()
    {
        shootParent = GameObject.Find(SHOOT_NAME);
        if (!shootParent)
        {
            shootParent = new GameObject(SHOOT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.RaycastAll(placeToSpawn.position, transform.TransformDirection(Vector2.right), Mathf.Infinity);
        
        foreach (var item in hit)
        {
            
            if (item.collider.tag == "enemy")
            {
                
                 anim.SetTrigger("Start");
                
            }
            
        }
        if(!hit.Any(i=>i.collider.tag == "enemy"))
        {
            anim.SetTrigger("Stop");
        }
    }
    public void SpawnOgor()
    {
        var spawn = (Instantiate(ogor, placeToSpawn.position, Quaternion.identity) as GameObject).transform.parent = shootParent.transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }
   

}
