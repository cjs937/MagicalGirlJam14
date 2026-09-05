using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManagementScript : MonoBehaviour
{
    AudioMixer mix;
    [SerializeField] Slider musicSlider, sfxSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVol", 0.5f);
		sfxSlider.value = PlayerPrefs.GetFloat("sfxVol", 0.5f);
        UpdateMusicVolume(musicSlider.value);
        UpdateSFXVolume(sfxSlider.value);
    }

    public void UpdateMusicVolume(float vol)
    {
        mix.SetFloat("MusicVol", Mathf.Log10(vol) * 20);
		PlayerPrefs.SetFloat("musicVol", vol);
	}

    public void UpdateSFXVolume(float vol)
    {
        mix.SetFloat("SFXVol", Mathf.Log10(vol) * 20);
		PlayerPrefs.SetFloat("sfxVol", vol);
	}
}
