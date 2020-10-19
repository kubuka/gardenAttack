using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WRZUCANIE DO LISTY PRZECIWNIKOW I TYLKO TO
public class Timer : MonoBehaviour
{
    float time = 20f;
    Spawner sp;
    [SerializeField] GameObject lisek;
    [SerializeField] GameObject gnom;
    [SerializeField] GameObject jabba;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        sp = FindObjectOfType<Spawner>();
        do
        {
            yield return new WaitForSeconds(time);
            if (sp.maxSpawn > 3f)
            {
                sp.maxSpawn -= 1f;
            }
            if(sp.minSpawn > 1f)
            {
               sp.minSpawn -= 1f;
            }
            if(time > 5f)
            {
                time -= 1;
            }
            if(sp.minSpawn == 7f)
            {              
                sp.a.Add(lisek);
            }
            if (sp.minSpawn == 6f)
            {
                sp.a.Add(jabba);
            }
            if(sp.minSpawn == 4f)
            {
                sp.a.Add(lisek);
                sp.a.Add(gnom);
            }
            
           
        } while (true);
    }

    // Update is called once per frame
    void Update()
    {
        
           
    }
}
