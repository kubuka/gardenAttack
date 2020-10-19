using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject lizard;
    [SerializeField] GameObject lisek;
     float timeToRun;
    [SerializeField] Vector3[] lista;
    [SerializeField] bool looping;
    public List<GameObject> a;
    public float minSpawn;
    public float maxSpawn;
    float difficultyLvl;
    const string ENEMIES_NAME = "Enemies";
    GameObject enemiesParent;
    
    
    IEnumerator Start()
    {
        enemiesParent = GameObject.Find(ENEMIES_NAME);
        if (!enemiesParent)
        {
            enemiesParent = new GameObject(ENEMIES_NAME);
        }

        a = new List<GameObject>();
        a.Add(lizard);
        a.Add(lizard);

        looping = false;
        lista = new Vector3[5];
        lista[0] = new Vector3(10f, 1.25f, 0);
        lista[1] = new Vector3(10f, 2.25f, 0);
        lista[2] = new Vector3(10f, 3.25f, 0);
        lista[3] = new Vector3(10f, 4.25f, 0);
        lista[4] = new Vector3(10f, 5.25f, 0);

        do
        {
            timeToRun = Random.Range(minSpawn, maxSpawn);
            yield return new WaitForSeconds(timeToRun);            
            PropSpawn();
            
            looping = true;
        } while (looping);

    }

    // Update is called once per frame
    void Awake()
    {
        difficultyLvl = PlayerPrefs.GetFloat("difficulty");
        minSpawn -= difficultyLvl;
        maxSpawn -= difficultyLvl;
    }
    public void StopCoo()
    {
        StopCoroutine("Start");
        this.enabled = false;
    }

    private void PropSpawn()
    {
        int r = Random.Range(0, 5);
        int z = Random.Range(0, a.Count);
        
       if(a[z].name == "krasnal")
        {
            var yPos = Random.Range(1, 6);
            var newYpos = Mathf.RoundToInt(yPos);
            var Spawn = Instantiate(a[z], new Vector2(10f,newYpos), Quaternion.identity) as GameObject;
            Spawn.transform.parent = enemiesParent.transform;
        }
        else
        {
            var Spawn = Instantiate(a[z], lista[r], Quaternion.identity) as GameObject;
            Spawn.transform.parent = enemiesParent.transform;
        }
            
           

    }
}
