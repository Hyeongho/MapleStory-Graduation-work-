using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public GameObject EnemyAtk;

	EnemyController enemy;

	private void Start()
	{
		enemy = this.gameObject.GetComponentInParent<EnemyController>();
	}

	public void StartAttack()
	{
		EnemyAtk.SetActive(true);
	}

	public void EndAttack()
	{
		EnemyAtk.SetActive(false);
	}
	public void StartSound()
	{
		enemy.audioSource.clip = enemy.clips[0];
		enemy.audioSource.Play();
	}

	public void MoveStart()
	{
		if (!enemy.isTargeting)
		{
			enemy.isMove = true;
		}
	}
}
