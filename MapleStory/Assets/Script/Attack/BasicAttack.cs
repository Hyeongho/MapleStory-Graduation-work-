using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
	GameObject Attack;

	Animator anim;

	bool playerAttack;

	bool isDamge;

	float EnemyHP;

	public List<GameObject> enemyList = new List<GameObject>();

	// Start is called before the first frame update
	void Start()
    {
		anim = GameObject.FindWithTag("Attack").GetComponent<Animator>();
		Attack = GameObject.FindWithTag("Attack");

		playerAttack = GameObject.FindWithTag("Player").GetComponent<Player>().isAttack;

		EnemyHP = GameObject.FindWithTag("Enemy").GetComponent<Enemy>().EnemyHP;	

		isDamge = false;
	}

    // Update is called once per frame
    void Update()
    {
		Debug.Log(enemyList.Count);

		SetAttack();
	}

	void SetAttack()
	{
		if (!playerAttack)
		{
			anim.SetBool("isAttack", true);
		}

		else
		{
			anim.SetBool("isAttack", false);
		}
	}

	void Damage()
	{
		if (isDamge)
		{
			EnemyHP -= 10.0f;

			for (int i = 0; i < enemyList.Count; i++)
			{
				enemyList[i].GetComponent<Enemy>().EnemyHP -= 10;
				enemyList[i].GetComponent<Enemy>().TakeDamage(10);
			}
		}

		//enemyList.Clear();
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Enemy"))
		{
			enemyList.Add(col.gameObject);

			isDamge = true;
		}
	}
}
