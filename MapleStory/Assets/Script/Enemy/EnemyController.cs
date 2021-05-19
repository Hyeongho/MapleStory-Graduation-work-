using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    float NewX;

    public float speed;

    bool isTargeting = false;

	Transform target;
	Vector3 targetPosition;

	public Vector3 direction;
	public float velocity;
	public float accelaration;

	public float EnemyHP;
	public float maxHp;

	public GameObject hubDamageText;
	public Transform hubPos;

	public bool isDestroy;

	public Image hpBar;

	Animator EnemyAni;

	public int damage = 10;

	public GameObject EnemyAtk;

	// Start is called before the first frame update
	void Start()
    {
        NewX = Random.Range(2.0f, 20.0f);

		EnemyAni = this.gameObject.GetComponentInChildren<Animator>();

		target = GameObject.FindWithTag("Player").transform;

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

        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, 
			new Vector3(NewX, this.gameObject.transform.position.y, this.gameObject.transform.position.z), speed);

		EnemyAni.SetBool("isMove", true);

		if (NewX == this.gameObject.transform.position.x)
		{
            NewX = Random.Range(2.0f, 20.0f);
        }
    }

    void MoveToTarget()
	{
		if (target.gameObject.activeSelf)
		{
			//targetPosition = new Vector3(target.position.x, this.gameObject.transform.position.y, target.position.z);

			//this.transform.LookAt(targetPosition);

			//this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
			//	new Vector3(target.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), speed);

		}

		else
		{
			return;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			targetPosition = new Vector3(target.position.x, this.gameObject.transform.position.y, target.position.z);

			this.transform.LookAt(targetPosition);

			EnemyAni.SetBool("isAttack", true);

			isTargeting = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			EnemyAni.SetBool("isAttack", false);

			isTargeting = false;
		}
	}
}
