using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Transform target;
	public Vector3 direction;
	public float velocity;
	public float accelaration;


	// Update is called once per frame
	void Update()
	{
		MoveToTarget();
	}

	public void MoveToTarget()
	{
		target = GameObject.Find("Player").transform;

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
}
