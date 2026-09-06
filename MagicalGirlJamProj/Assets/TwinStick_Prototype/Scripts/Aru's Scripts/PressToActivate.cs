using UnityEngine;

public class PressToActivate : MonoBehaviour
{
    public Transform player;
    public Transform activationUI;
	GamblingScript gamblingScript;

	public bool playerInRange;

    [Header("Audio Clips")]
    public AudioClip[] clips;
    public float clipVolume = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamblingScript = GetComponent<GamblingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamblingScript.canPull)
        {
            if (!playerInRange)
            {
                playerInRange = true;

                if(clips.Length > 0 && transform.GetComponent<AudioSource>() != null)
                {
                    transform.GetComponent<AudioSource>().pitch = Random.Range(0.65f, 1.1f);
                    transform.GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0, clips.Length)], clipVolume);
                }
            }
			activationUI.gameObject.SetActive(true);
		}
		else
        {
            if (playerInRange)
				activationUI.gameObject.SetActive(false);

			playerInRange = false;
        }
    }
}
