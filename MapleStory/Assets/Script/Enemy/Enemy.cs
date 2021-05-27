using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public Transform target;
	public Vector3 targetPosition;

	public Vector3 direction;
	public float velocity;
	public float accelaration;

	private float playerHP;

	public float EnemyHP;
	public float maxHp;

	public GameObject hubDamageText;
	public Transform hubPos;

	public bool isTargeting;
	public bool isDestroy;

	GameObject Player;

	Rigidbody rig;

	public Image hpBar;

	bool isDamage;

	bool isHurt;
	bool isKnockBack;

	private void Awake()
	{
		Player = GameObject.FindWithTag("Player");

		rig = this.gameObject.GetComponent<Rigidbody>();

		EnemyHP = maxHp;
		isDamage = false;

		isHurt = false;
		isKnockBack = false;
	}

	private void Start()
	{
		playerHP = GameObject.FindWithTag("Player").GetComponent<Player>().curHP;

		isDestroy = false;
		isTargeting = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (EnemyHP <= 0.0f)
		{
			isDestroy = true;
		}

		if (!isDestroy)
		{
			MoveToTarget();
		}

		hpBar.fillAmount = EnemyHP / maxHp;
	}

	public void MoveToTarget()
	{
		if (GameObject.FindWithTag("Player").activeSelf)
		{
			target = GameObject.FindWithTag("Player").transform;

			targetPosition = new Vector3(target.position.x, this.gameObject.transform.position.y, target.position.z);

			direction = (target.position - transform.position).normalized;

			velocity = velocity * Time.deltaTime;

			float distance = Vector3.Distance(target.position, transform.position);

			if (distance <= 4.0f)
			{
				isTargeting = true;

				velocity = 0.001f;

				this.transform.LookAt(targetPosition);

				this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y, transform.position.z);
			}

			// 일정거리 밖에 있을 시, 속도 초기화 
			else
			{
				isTargeting = false;

				velocity = 0.0f;
			}
		}

		else
		{
			return;
		}
		
	}

	void Hurt(float _damage, Vector3 _pos)
	{
		if (!isHurt)
		{
			isHurt = true;

			EnemyHP = EnemyHP - _damage;

			TakeDamage((int)_damage);

			if (EnemyHP <= 0)
			{

			}

			else
			{
				float x = transform.position.x - _pos.x;

				if (x < 0)
				{
					x = 1;
				}

				else
				{
					x = -1;
				}

				StartCoroutine(KnockBack(x));
				StartCoroutine(HurtRoutine());
			}
		}
	}

	IEnumerator KnockBack(float dir)
	{
		isKnockBack = true;

		float ctime = 0.0f;

		int reaction = this.transform.position.x - Player.transform.position.x > 0 ? 1 : -1;

		while (ctime < 0.2f)
		{
			if (transform.rotation.y == 90.0f)
			{
				this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(reaction, 0.0f, 0) * 0.5f, ForceMode.Impulse);

				//transform.Translate(Vector3.forward * velocity * Time.deltaTime * dir);
			}

			else
			{
				this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(reaction, 0.0f, 0) * 0.5f, ForceMode.Impulse);

				//transform.Translate(Vector3.forward * velocity * Time.deltaTime * -1.0f * dir);
			}

			ctime += Time.deltaTime;
			yield return null;
		}

		isKnockBack = false;
	}

	IEnumerator HurtRoutine()
	{
		yield return new WaitForSeconds(0.2f);

		isHurt = false;
	}

	private void OnTriggerEnter(Collider col)
	{
		if (!isDestroy)
		{
			if (col.gameObject.tag == "Player")
			{
				Player.GetComponent<Player>().curHP -= 10;
				Player.GetComponent<Player>().TakeDamage(10);

				int reaction = Player.transform.position.x - this.gameObject.transform.position.x > 0 ? 1 : -1;
				Player.GetComponent<Rigidbody>().AddForce(new Vector3(reaction, 0.5f, 0) * 2.5f, ForceMode.Impulse);
			}

			if (col.gameObject.CompareTag("BasicAttackRange"))
			{
				Hurt(col.GetComponentInParent<Player>().ATK, col.transform.position);
			}

			else if (col.gameObject.CompareTag("SkillRange"))
			{
				Hurt(col.GetComponentInParent<Player>().ATK, col.transform.position);
			}
		}	
	}

	public void TakeDamage(int damage)
	{
		GameObject hubText = Instantiate(hubDamageText);
		hubText.transform.position = hubPos.position;
		hubText.GetComponent<DamageText>().damage = damage;
		Debug.Log(damage);
	}
}
