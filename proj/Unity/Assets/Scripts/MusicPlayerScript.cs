using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class MusicPlayerScript : MonoBehaviour
{
	public GameObject musicObject;
	public Slider musicSlider;

	private AudioSource musicAudio;
	private float MusicVolume = 0.1f;

	void Start()
	{
		musicObject = GameObject.FindWithTag("Music");
		musicAudio = musicObject.GetComponent<AudioSource>();

		MusicVolume = PlayerPrefs.GetFloat("music");
		musicAudio.volume = MusicVolume;
		musicSlider.value = MusicVolume;
	}

	void Update()
	{
		musicAudio.volume = MusicVolume;
		PlayerPrefs.SetFloat("music", MusicVolume);
	}

	public void updateVolume(float volume)
	{
		MusicVolume = volume;
	}
}