using UnityEngine;
using UnityEngine.UI;

public class SFX_Manager : MonoBehaviour
{
    
	private static readonly string FirstPlay = "FirstPlay";
	private static readonly string VolumePref = "VolumePref";
	private static readonly string MusicPref = "MusicPref";

	private int firstPlayInt;

	public Slider volumeSlider, musicSlider;
	private float volumeFloat, musicFloat;
    
	public AudioSource volumeAudio;
	public AudioSource musicAudio;


    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0) 
        {
        	volumeFloat = .5f;
        	musicFloat = .5f;
        	volumeSlider.value = volumeFloat;
        	musicSlider.value = musicFloat;
        	PlayerPrefs.SetFloat(VolumePref, volumeFloat);
        	PlayerPrefs.SetFloat(MusicPref, musicFloat);
        	PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
        	volumeFloat = PlayerPrefs.GetFloat(VolumePref);
        	volumeSlider.value = volumeFloat;
        	musicFloat = PlayerPrefs.GetFloat(MusicPref);
        	musicSlider.value = musicFloat;
        }
    }

    public void SaveSoundSettings()
    {
    	PlayerPrefs.SetFloat(VolumePref, volumeSlider.value);
    	PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
    	if (!inFocus)
    	{
    		SaveSoundSettings();
    	}
    }

    public void UpdateSound() 
    {
    	volumeAudio.volume = volumeSlider.value;
    	musicAudio.volume = musicSlider.value;

    	/*
    	for (int i = 0; i < volumeAudio.length; i++)
    	{
    		volumeAudio[i].volume = volumeSlider.value;
    	}
    	*/
    }

}
