using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static MusicScript music;
	[SerializeField] AudioClip loop;
    AudioSource source;

    void Start()
    {
        if (music == null) music = this;
        else Destroy(gameObject);

        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        LoopSong();
    }

    async void LoopSong()
    {
        while (source.isPlaying)
            await Task.Yield();

        source.clip = loop;
        source.loop = true;
        source.Play();
    }
}
