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

	private void Awake()
	{
		Player = GameObject.FindWithTag("Player");

		rig = this.gameObject.GetComponent<Rigidbody>();

		EnemyHP = maxHp;
	}

	private void Start()
	{
		playerHP = GameObject.FindWithTag("Player").GetComponent<Player>().HP;

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

				velocity = 0.01f;

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

	private void OnTriggerEnter(Collider col)
	{
		if (!isDestroy)
		{
			if (col.gameObject.tag == "Player")
			{
				Player.GetComponent<Player>().HP -= 10;
				Player.GetComponent<Player>().TakeDamage(10);

				int reaction = Player.transform.position.x - this.gameObject.transform.position.x > 0 ? 1 : -1;
				Player.GetComponent<Rigidbody>().AddForce(new Vector3(reaction, 0.5f, 0) * 2.5f, ForceMode.Impulse);
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
