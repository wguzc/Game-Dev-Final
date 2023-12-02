using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Default volume changes") == 0){
            masterSlider.value = .1f;
            musicSlider.value = .1f;
            sfxSlider.value = .1f;
            PlayerPrefs.SetInt("default volume changed", 1);
        }

        masterSlider.value = PlayerPrefs.GetFloat("Master");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(string name, Slider slider){
        PlayerPrefs.SetFloat(name,slider.value);
        float volume = Mathf.Log10(slider.value) * 20;
        if(slider.value == 0){
            volume= -80;
        }

        mixer.SetFloat(name,volume);

    }


    public void SetMasterVolume(){
        SetVolume("Master", masterSlider);
    }

    public void SetSFXVolume(){
        SetVolume("SFX", sfxSlider);
    }

    public void SetMusicVolume(){
        SetVolume("Music", musicSlider);
    }


}
