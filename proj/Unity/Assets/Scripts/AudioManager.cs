
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public AudioMixer _MasterMixer;
    public AudioManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void SetMasterVolume(Slider volume){
        _MasterMixer.SetFloat ("master", (volume.value * 0.8f));
    }

}