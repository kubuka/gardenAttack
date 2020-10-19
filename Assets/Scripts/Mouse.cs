using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject kaktus;
    public int cost;
    Grid gr;
    const string DEFENDER_NAME = "Defenders";
    GameObject defenderParent;

    private void Start()
    {
        defenderParent = GameObject.Find(DEFENDER_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_NAME);
        }
    }
    private void OnMouseDown()
    {
        if(cost <= FindObjectOfType<CoinSystem>().coins)
        {             
                    SpawnDefender(SnapToGrid(placeToClick()));
                    FindObjectOfType<CoinSystem>().SubtractCoin(cost);          
        }
        else
        {
            Debug.Log("za mało kasy");
        }
        
    }
    private Vector2 placeToClick()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);   
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        
        return worldPos ;
    }
    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        Vector2 newPos = new Vector2(newX, newY);
        return newPos;
    }

    void SpawnDefender(Vector2 a)
    {
        var c = (Instantiate(kaktus, a, Quaternion.identity) as GameObject).transform.parent = defenderParent.transform;
    }
}
