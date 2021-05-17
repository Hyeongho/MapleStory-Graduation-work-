using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    float NewX;

    public float speed;

    bool isTargeting = false;

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

	public bool isDestroy;

	public Image hpBar;

	bool isDamage;

	Animator EnemyAni;

	// Start is called before the first frame update
	void Start()
    {
        NewX = Random.Range(2.0f, 20.0f);

		EnemyAni = this.gameObject.GetComponentInChildren<Animator>();

	}

    // Update is called once per frame
    void Update()
    {
		if (!isTargeting)
		{
			Move();
        }

		else
		{
			MoveToTarget();
		}
    }

    void Move()
	{
		if (NewX >= this.gameObject.transform.position.x)
		{
			this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
		}

		else
		{
			this.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
		}

        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(NewX, this.gameObject.transform.position.y, this.gameObject.transform.position.z), speed);

		EnemyAni.SetBool("isMove", true);

		if (NewX == this.gameObject.transform.position.x)
		{
            NewX = Random.Range(2.0f, 20.0f);
        }
    }

    void MoveToTarget()
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

			else if (distance <= 0.5f)
			{
				
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

	public void AttackStart()
	{

	}

	public void AttackEnd()
	{

	}
}
