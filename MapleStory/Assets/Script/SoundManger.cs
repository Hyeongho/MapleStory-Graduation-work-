using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManger : MonoBehaviour
{
    static public SoundManger instance;

    public AudioClip[] clips;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null)
        {
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "tutorial")
        {
            if (clips[0].name != audioSource.clip.name)
            {
                if (!audioSource.isPlaying)
                {
                    PlaySound(0);
                }

                else
                {
                    StopSound();
                }
            }
        }

        else if (SceneManager.GetActiveScene().name == "Agit")
        {

			if (clips[1].name != audioSource.clip.name)
			{
                StopSound();

                if (!audioSource.isPlaying)
                {
                    PlaySound(1);
                }

                else
                {
                    StopSound();
                }
            }
        }

		else if (SceneManager.GetActiveScene().name == "Feild1" || SceneManager.GetActiveScene().name == "Feild2")
		{
            if (clips[2].name != audioSource.clip.name)
            {
                StopSound();

                if (!audioSource.isPlaying)
                {
                    PlaySound(2);
                }

                else
                {
                    StopSound();
                }
            }
        }
    }

	public void PlaySound(int _playMusicTrack)
	{
        audioSource.clip = clips[_playMusicTrack];
        audioSource.Play();
	}

	public void StopSound()
	{
        audioSource.Stop();
    }
}
