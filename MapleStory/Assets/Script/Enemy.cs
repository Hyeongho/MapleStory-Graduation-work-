using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Transform target;
	public Vector3 direction;
	public float velocity;
	public float accelaration;

	private float playerHP;

	public float EnemyHP;

	public GameObject hubDamageText;
	public Transform hubPos;

	private void Start()
	{
		playerHP = GameObject.FindWithTag("Player").GetComponent<Player>().HP;
		EnemyHP = 100.0f;
	}

	// Update is called once per frame
	void Update()
	{
		MoveToTarget();

		if (EnemyHP <= 0.0f)
		{
			Destroy(this.gameObject);
		}
	}

	public void MoveToTarget()
	{
		if (GameObject.FindWithTag("Player").activeSelf)
		{
			target = GameObject.FindWithTag("Player").transform;

			direction = (target.position - transform.position).normalized;

			velocity = velocity * Time.deltaTime;

			float distance = Vector3.Distance(target.position, transform.position);

			if (distance <= 4.0f)
			{
				velocity = 0.01f;

				this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y, transform.position.z);
			}
			// 일정거리 밖에 있을 시, 속도 초기화 
			else
			{
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
		if (col.gameObject.tag == "Player")
		{

			GameObject.FindWithTag("Player").GetComponent<Player>().HP -= 10;
			GameObject.FindWithTag("Player").GetComponent<Player>().TakeDamage(10);
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
