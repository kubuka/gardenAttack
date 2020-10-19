using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIF = 1f;
    const float MAX_DIF = 3f;

    public  void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {           
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            PlayerPrefs.Save();
         
        }
        else
        {
            Debug.LogError("volume out of range");
        }     
    }
    public void SetDifficulty(float dificullty)
    {
        if(dificullty >= MIN_DIF && dificullty<= MAX_DIF)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, dificullty);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("difficulty out of range");
        }
    }

    public  float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public float GetDifficultyLvl()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }


    public void Deafult()
    {
        FindObjectOfType<OptionsVolume>().SetSliderToDefault();
    }
    
}
