using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : EnemyData
{
    float NewX;

    public float speed;

    bool isTargeting = false;

	Transform target;
	Vector3 targetPosition;

	GameObject Player;

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

	QuestManger questManger;

	bool isDie;

	bool isHurt;
	bool isKnockBack;

	// Start is called before the first frame update
	void Start()
    {
		isDie = false;

		NewX = Random.Range(2.0f, 20.0f);

		EnemyAni = this.gameObject.GetComponentInChildren<Animator>();

		target = GameObject.FindWithTag("Player").transform;

		Player = GameObject.FindWithTag("Player");

		questManger = GameObject.Find("Quest Manager").GetComponent<QuestManger>();
	}

    // Update is called once per frame
    void Update()
    {
		if (!isDie)
		{
			if (!isTargeting)
			{
				Move();
			}

			else
			{

			}
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

	void Hurt(float _damage, Vector3 _pos)
	{
		if (!isDie)
		{
			if (!isHurt)
			{
				isHurt = true;

				EnemyHP = EnemyHP - _damage;

				//TakeDamage((int)_damage);

				if (EnemyHP <= 0)
				{
					isDie = true;

					EnemyAni.SetBool("isDie", true);

					Player.GetComponent<Player>().curEXP += Exp;

					switch (questManger.questId)
					{
						case 10:
							break;
						case 20:
							if (questManger.questActionIndex == 1 && ID == 2)
							{
								questManger.count++;
							}
							break;

						default:
							break;
					}
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

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			targetPosition = new Vector3(target.position.x, this.gameObject.transform.position.y, target.position.z);

			this.transform.LookAt(targetPosition);

			EnemyAni.SetBool("isAttack", true);

			isTargeting = true;
		}

		if (other.gameObject.CompareTag("BasicAttackRange"))
		{
			Hurt(other.GetComponentInParent<Player>().ATK, other.transform.position);
		}

		else if (other.gameObject.CompareTag("SkillRange"))
		{
			Hurt(other.GetComponentInParent<Player>().ATK, other.transform.position);
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

	public void TakeDamage(int damage)
	{
		GameObject hubText = Instantiate(hubDamageText);
		hubText.transform.position = hubPos.position;
		hubText.GetComponent<DamageText>().damage = damage;
		Debug.Log(damage);
	}
}
