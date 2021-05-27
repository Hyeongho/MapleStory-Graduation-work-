using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	DataManager dataManager;
	DialogueManager dialogueManager;

	public bool isKineis = false;
	public bool isYuna = false;

	public float playerSpeed = 1.0f;

	public float HP;
	public float MP;

	public float curHP;
	public float curMP;

	public float ATK;

	public int Lv;

	public float EXP;
	public float curEXP;

	private bool isGrounded;
	private float jumpCount = 2.0f;

	bool isMove;

	Rigidbody rb;

	Vector3 Look;

	Animator attackAni;
	Animator PS2; //PsychicSmashing2
	Animator playerAni;

	Animator skillAni;
	GameObject Skill;

	GameObject BasicAttack;
	GameObject PsychicSmashing2;

	public bool isAttack;
	public bool isSkill;
	bool iskey;

	bool tagNpc;

	public GameObject hubDamageText;
	public Transform hubPos;

	public List<GameObject> enemyList = new List<GameObject>();

	public string currentMapName;
	public string pastMapName;

	GameObject scanObject;

	bool isHurt;

	bool isKnockBack;

	public float colHP;
	public float colMP;

	public float curColHP;
	public float curColMP;

	Animator levelUp;

	private void Awake()
	{
		HP = 100;

		MP = 100;

		curHP = HP;
		curMP = MP;

		EXP = 15;

		curEXP = 0;

		Lv = 1;

		colHP = 5.0f;
		colMP = 5.0f;

		curColHP = 0;
		curColMP = 0;

		DontDestroyOnLoad(this.gameObject);

		rb = GetComponent<Rigidbody>();

		if ((int)DataManager.instance.currentCharacter == 1)
		{
			isKineis = true;
		}

		else
		{
			isYuna = true;
		}

		dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
	}

	// Start is called before the first frame update
	void Start()
    {
		tagNpc = false;

		isGrounded = false;

		isHurt = false;

		isKnockBack = false;

		rb = GetComponent<Rigidbody>();
		jumpCount = 0.0f;

		if (isKineis)
		{
			attackAni = GameObject.Find("Attack").GetComponent<Animator>();
			BasicAttack = GameObject.Find("Attack");

			skillAni = GameObject.FindGameObjectWithTag("Skill").GetComponent<Animator>();
			Skill = GameObject.FindGameObjectWithTag("Skill");

			BasicAttack.SetActive(false);

			Skill.SetActive(false);
		}

		else if (isYuna)
		{
			attackAni = GameObject.FindGameObjectWithTag("Attack").GetComponent<Animator>();
			BasicAttack = GameObject.FindGameObjectWithTag("Attack");

			skillAni = GameObject.FindGameObjectWithTag("Skill").GetComponent<Animator>();
			Skill = GameObject.FindGameObjectWithTag("Skill");

			BasicAttack.SetActive(false);
			Skill.SetActive(false);
		}

		playerAni = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

		levelUp = GameObject.Find("Levelefc").GetComponent<Animator>();

		levelUp.gameObject.SetActive(false);

		isAttack = false;

		isSkill = false;

		isMove = true;
	}

    // Update is called once per frame
    void Update()
    {
		if (!dialogueManager.isAction)
		{
			if (isMove)
			{
				Move();
			}		

			Attack();
		}

		if (curColHP <= 0)
		{
			if (Input.GetKey(KeyCode.Delete))
			{
				curHP = curHP + (HP * 0.5f);

				curColHP = colHP;
			}
		}

		else
		{
			curColHP -= Time.deltaTime;
		}

		if (curColMP <= 0)
		{
			if (Input.GetKey(KeyCode.Insert))
			{
				curMP = curMP + (MP * 0.5f);

				curColMP = colMP;
			}
		}

		else
		{
			curColMP -= Time.deltaTime;
		}

		if (tagNpc)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Debug.Log(scanObject.name);

				dialogueManager.Action(scanObject);
			}
		}

		if (curEXP >= EXP)
		{
			Lv++;

			levelUp.gameObject.SetActive(true);

			HP = HP + 20;
			MP = MP + 20;

			curHP = HP;
			curMP = MP;

			ATK += 10;

			curEXP = 0;
			EXP = Mathf.Round(EXP + (EXP * 0.5f));

		}

		if (curHP > HP)
		{
			curHP = HP;
		}

		if (curMP > MP)
		{
			curMP = MP;
		}

		if (levelUp.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
		{
			levelUp.gameObject.SetActive(false);
		}
	}

	private void Move()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			playerAni.SetBool("isMove", true);

			Look = 0 * Vector3.forward + -1 * Vector3.right;

			transform.rotation = Quaternion.LookRotation(Look);

			transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);

		}

		else if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			playerAni.SetBool("isMove", false);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			playerAni.SetBool("isMove", true);

			Look = 0 * Vector3.forward + 1 * Vector3.right;

			transform.rotation = Quaternion.LookRotation(Look);

			transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
		}

		else if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			playerAni.SetBool("isMove", false);
		}

		if (isGrounded)
		{
			if (jumpCount > 0)
			{
				if (Input.GetKeyDown(KeyCode.LeftAlt))
				{
					if (jumpCount == 2)
					{
						playerAni.SetBool("isJump", true);
					}

					rb.AddForce(new Vector3(0, 2.5f, 0) * jumpCount, ForceMode.Impulse);
					jumpCount--;
				}

			}
		}
	}

	private void Attack()
	{
		if (isKineis)
		{
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{
				BasicAttack.SetActive(true);

				isMove = false;

				attackAni.SetBool("isAttack", true);

				isAttack = true;
			}

			else if (Input.GetKeyUp(KeyCode.LeftControl))
			{
				isAttack = false;
			}

			if (Input.GetKey(KeyCode.LeftShift))
			{
				isMove = false;

				isSkill = true;

				Skill.SetActive(true);
			}

			else if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				isAttack = false;
			}

			if (!isAttack)
			{
				if (attackAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
				{
					enemyList.Clear();

					BasicAttack.SetActive(false);

					isMove = true;
				}

				if (skillAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
				{
					//playerAni.SetBool("isSkill", false);

					Skill.SetActive(false);

					isSkill = false;

					isMove = true;
				}
			}
		}

		else if (isYuna)
		{
			if (Input.GetKeyDown(KeyCode.LeftControl) && !isSkill)
			{
				isMove = false;

				isAttack = true;

				BasicAttack.SetActive(true);
				playerAni.SetBool("isAttack", true);
			}

			if (curMP >= 10)
			{
				if (Input.GetKeyDown(KeyCode.LeftShift) && !isAttack)
				{
					curMP -= 10;

					isMove = false;

					isSkill = true;

					Skill.SetActive(true);
					playerAni.SetBool("isSkill", true);
				}
			}	

			if (attackAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
			{
				playerAni.SetBool("isAttack", false);

				BasicAttack.SetActive(false);

				isAttack = false;

				isMove = true;
			}

			if (skillAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
			{
				playerAni.SetBool("isSkill", false);

				Skill.SetActive(false);

				isSkill = false;

				isMove = true;
			}
		}
	
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Ground"))
		{
			playerAni.SetBool("isJump", false);

			isGrounded = true;
			jumpCount = 2.0f;
		}
	}

	IEnumerable AttackCoroutine()
	{
		Debug.Log("Start");

		yield return new WaitForSeconds(2.0f);
		
	}

	public void TakeDamage(int damage)
	{
		GameObject hubText = Instantiate(hubDamageText);
		hubText.transform.position = hubPos.position;
		hubText.GetComponent<DamageText>().damage = damage;
		Debug.Log(damage);
	}

	void Hurt(int _damage, Vector3 _pos)
	{
		if (!isHurt)
		{
			isHurt = true;

			curHP = curHP - _damage;

			TakeDamage(_damage);

			if (curHP <= 0)
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

		while (ctime < 0.2f)
		{
			if (transform.rotation.y == 90.0f)
			{
				transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime * dir);
			}

			else
			{
				transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime * -1.0f * dir);
			}

			ctime += Time.deltaTime;
			yield return null;
		}

		isKnockBack = false;
	}

	IEnumerator HurtRoutine()
	{
		yield return new WaitForSeconds(2.0f);

		isHurt = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("NPC"))
		{
			tagNpc = true;

			scanObject = other.gameObject;

			Debug.Log(other.gameObject.name);

			Debug.Log("tag");			
		}

		if (other.gameObject.CompareTag("EnemyAtk") && !other.GetComponentInParent<EnemyController>().isDie)
		{
			Hurt(other.GetComponentInParent<EnemyController>().damage, other.transform.position);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("NPC") && tagNpc)
		{
			scanObject = null;

			tagNpc = false;
		}
	}

}
