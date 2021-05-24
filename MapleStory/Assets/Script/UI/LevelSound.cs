using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
   public void PlaySound()
	{
		this.gameObject.GetComponentInParent<AudioSource>().Play();
	}
}
