using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timesup : MonoBehaviour
{
    [SerializeField] Slider linia;
    SceneLoader sc;
   public  float time = 50f;
    // Start is called before the first frame update
    void Start()
    {
        linia.GetComponent<Image>();
        sc = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        linia.value = sc.time/time;

		if(linia.value <= 0)
		{
			FindObjectOfType<Spawner>().StopCoo();
			sc.win.SetActive(true);
		}
    }
}
