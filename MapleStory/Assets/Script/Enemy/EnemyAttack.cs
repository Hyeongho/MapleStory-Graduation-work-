using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public GameObject EnemyAtk;

    public void StartAttack()
	{
		EnemyAtk.SetActive(true);
	}

	public void EndAttack()
	{
		EnemyAtk.SetActive(false);
	}
}
