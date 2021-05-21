using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRange : MonoBehaviour
{
    public GameObject Skill;

    public AudioClip sound;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartAttack()
    {
        Skill.SetActive(true);
    }

    public void EndAttack()
    {
        Skill.SetActive(false);
    }

    public void PlaySound()
	{
        audioSource.clip = sound;
        audioSource.Play();
    }

}
