using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsVolume : MonoBehaviour
{
    [SerializeField] OptionsManager om;
    [SerializeField] Slider slider;
    [SerializeField] Slider dslider;
    void Start()
    {
        slider.value = om.GetMasterVolume();
        dslider.value = om.GetDifficultyLvl();
    }

    void Update()
    {
        om.SetMasterVolume(slider.value);
        om.SetDifficulty(dslider.value);       
    }

    public void SetSliderToDefault()
    {
        slider.value = 0.5f;
        dslider.value = 1;
    }
}
