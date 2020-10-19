using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Animator anim;
    Helthpoint hp;
    timesup ts;
    [SerializeField] TextMeshProUGUI text;
    [HideInInspector]
    public float time;
    OnlyLoadNextScene only;
    [SerializeField] GameObject lose;
    public GameObject win;
    
    // Start is called before the first frame update
    void Start()
    {
        only = FindObjectOfType<OnlyLoadNextScene>();
        ts = FindObjectOfType<timesup>();
        if(SceneManager.GetActiveScene().name == "Lvl1")
        {
            time = ts.time;
        }       
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(Splash());
        }       
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Lvl1")
        {
            time -= 1f * Time.deltaTime;
            text.SetText(time.ToString());

            int i = FindObjectsOfType<eHealth>().Length;

            hp = FindObjectOfType<Helthpoint>();
            if (hp.health <= 0)
            {
                FindObjectOfType<Spawner>().StopCoo();
                lose.SetActive(true);
            }
            if (time <= 0)
            {
                FindObjectOfType<Spawner>().StopCoo();

                if (i == 0 && hp.health > 0)
                {
                    win.SetActive(true);
                }
            }
        }                   
    }


    IEnumerator Splash()
    {
        yield return new WaitForSeconds(2.8f);
        anim.SetTrigger("intro");
        
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Wyjscie()
    {
        Application.Quit();
    }
    
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Options()
    {               
        SceneManager.LoadScene("Options");
    }
    public void PlayClick()
    {
        anim.SetTrigger("intro");
    }
    public void OptionsClick()
    {
        anim.SetTrigger("options");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void MainMenuClick()
    {
        anim.SetTrigger("play");
    }
    void OffImage()
    {
        GetComponentInChildren<Image>().enabled = false;
    }
    void OnImage()
    {
        GetComponentInChildren<Image>().enabled = true;
    }
}
