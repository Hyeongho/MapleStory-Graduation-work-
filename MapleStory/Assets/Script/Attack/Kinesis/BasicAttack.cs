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

	Player player;

	Enemy enemy;

	public AudioClip sound;

	AudioSource audioSource;

	private void Awake()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();

		enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
	}

	// Start is called before the first frame update
	void Start()
    {
		anim = GameObject.FindWithTag("Attack").GetComponent<Animator>();
		Attack = GameObject.FindWithTag("Attack");

		audioSource = GetComponent<AudioSource>();

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
			anim.SetBool("isAttack", true);

			Debug.Log("anim.SetBool(isAttack, true)");
		}

		else
		{
			anim.SetBool("isAttack", false);

			Debug.Log("anim.SetBool(isAttack, false)");
		}
	}

	void Damage()
	{
		if (isDamge)
		{
			EnemyHP -= 10.0f;

			for (int i = 0; i < player.enemyList.Count; i++)
			{
				player.enemyList[i].GetComponent<Enemy>().EnemyHP -= 10;
				player.enemyList[i].GetComponent<Enemy>().TakeDamage(10);

				int reaction = enemy.transform.position.x - player.transform.position.x > 0 ? 1 : -1;
				enemy.GetComponent<Rigidbody>().AddForce(new Vector3(reaction, 0, 0) * 5.0f, ForceMode.Impulse);
			}
		}

		//enemyList.Clear();
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Enemy"))
		{
			player.enemyList.Add(col.gameObject);

			isDamge = true;
		}
	}

	public void PlaySound()
	{
		audioSource.clip = sound;
		audioSource.Play();
	}
}
