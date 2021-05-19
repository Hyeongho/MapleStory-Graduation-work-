using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackRange : MonoBehaviour
{
    public GameObject BasicAttack;

	public void StartAttack()
	{
		BasicAttack.SetActive(true);
	}

	public void EndAttack()
	{
		BasicAttack.SetActive(false);
	}
}
