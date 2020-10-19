using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] public int coins = 0;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(coins.ToString());
    }
    public void AddCoin(int ilosc)
    {
        coins += ilosc;
    }
    public void SubtractCoin(int ilosc)
    {
        coins -= ilosc;
    }
}
