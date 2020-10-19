using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    AudioSource audioSource;
    OptionsManager findObjectOfType;

	private void Awake()
	{
		if(FindObjectsOfType<MusicPlayerScript>().Length > 1)
		{
			Destroy(this.gameObject);
		}
	}

	// Start is called before the first frame update
	void Start()
    {

        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("master volume");
    }
}
