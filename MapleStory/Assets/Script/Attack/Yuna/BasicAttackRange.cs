using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackRange : MonoBehaviour
{
    public GameObject BasicAttack;

	public AudioClip sound;

	AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void StartAttack()
	{
		BasicAttack.SetActive(true);
	}

	public void EndAttack()
	{
		BasicAttack.SetActive(false);
	}

	public void PlaySound()
	{
		audioSource.clip = sound;
		audioSource.Play();
	}
}
