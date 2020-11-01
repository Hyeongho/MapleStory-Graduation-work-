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

	// Start is called before the first frame update
	void Start()
    {
		anim = GameObject.Find("Attack").GetComponent<Animator>();
		Attack = GameObject.Find("Attack");

		playerAttack = GameObject.Find("Player").GetComponent<Player>().isAttack;

		EnemyHP = GameObject.Find("Enemy").GetComponent<Enemy>().EnemyHP;

		isDamge = false;
	}

    // Update is called once per frame
    void Update()
    {
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

			GameObject.Find("Enemy").GetComponent<Enemy>().EnemyHP = EnemyHP;
		}		
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Enemy"))
		{
			isDamge = true;
		}
	}
}
