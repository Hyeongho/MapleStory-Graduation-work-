using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicSmashing2 : MonoBehaviour
{
	GameObject Attack;

	Animator anim;

	Player player;

	GameObject Enemy;

	bool playerAttack;

	bool isDamge;

	float EnemyHP;

	private void Awake()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();

		Enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	// Start is called before the first frame update
	void Start()
    {
		Attack = GameObject.Find("PsychicSmashing2");

		anim = GameObject.Find("PsychicSmashing2").GetComponent<Animator>();

		playerAttack = GameObject.FindWithTag("Player").GetComponent<Player>().isAttack;

		EnemyHP = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().EnemyHP;

		isDamge = false;
	}

    // Update is called once per frame
    void Update()
    {
		SetAttack();
	}

	void SetAttack()
	{
		if (player.isAttack)
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

			for (int i = 0; i < GameObject.FindWithTag("Player").GetComponent<Player>().enemyList.Count; i++)
			{
				GameObject.FindWithTag("Player").GetComponent<Player>().enemyList[i].GetComponent<Enemy>().EnemyHP -= 10;
				GameObject.FindWithTag("Player").GetComponent<Player>().enemyList[i].GetComponent<Enemy>().TakeDamage(10);

				int reaction = Enemy.transform.position.x - player.transform.position.x > 0 ? 1 : -1;
				Enemy.GetComponent<Rigidbody>().AddForce(new Vector3(reaction, 0, 0) * 5.0f, ForceMode.Impulse);
			}

		}
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Enemy"))
		{
			GameObject.FindWithTag("Player").GetComponent<Player>().enemyList.Add(col.gameObject);

			isDamge = true;;
		}
	}
}
