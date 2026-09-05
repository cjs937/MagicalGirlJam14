using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManagementScript : MonoBehaviour
{
    public AudioMixer mix;
    [SerializeField] Slider musicSlider, sfxSlider;

    void Start()
    {
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVol", 0.5f);
            UpdateMusicVolume(musicSlider.value);
        }
        else
			UpdateMusicVolume(PlayerPrefs.GetFloat("musicVol", 0.5f));

		if (sfxSlider != null)
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVol", 0.5f);
            UpdateSFXVolume(sfxSlider.value);
        }
		else
			UpdateSFXVolume(PlayerPrefs.GetFloat("sfxVol", 0.5f));
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
