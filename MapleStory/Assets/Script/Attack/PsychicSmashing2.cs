using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicSmashing2 : MonoBehaviour
{
	GameObject Attack;

	Animator anim;

	bool playerAttack;

	bool isDamge;

	float EnemyHP;

	// Start is called before the first frame update
	void Start()
    {
		Attack = GameObject.Find("PsychicSmashing2");

		anim = GameObject.Find("PsychicSmashing2").GetComponent<Animator>();

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
			anim.SetBool("IsAttack", true);
		}

		else
		{
			anim.SetBool("IsAttack", false);
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
