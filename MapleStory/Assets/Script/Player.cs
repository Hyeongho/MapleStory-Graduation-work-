using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float playerSpeed = 1.0f;

	public float HP;
	public float MP;

	public float ATK;

	private bool isGrounded;
	private float jumpCount = 2.0f;

	bool isMove;

	Rigidbody rb;

	Vector3 Look;

	Animator attackAni;
	Animator PS2; //PsychicSmashing2
	Animator playerAni;

	GameObject BasicAttack;
	GameObject PsychicSmashing2;

	public bool isAttack;
	bool iskey;

	public GameObject hubDamageText;
	public Transform hubPos;

	public List<GameObject> enemyList = new List<GameObject>();

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Start is called before the first frame update
	void Start()
    {
		isGrounded = false;

		rb = GetComponent<Rigidbody>();
		jumpCount = 0.0f;

		attackAni = GameObject.Find("Attack").GetComponent<Animator>();
		BasicAttack = GameObject.Find("Attack");

		playerAni = this.gameObject.GetComponent<Animator>();

		PS2 = GameObject.Find("PsychicSmashing2").GetComponent<Animator>();
		PsychicSmashing2 = GameObject.Find("PsychicSmashing2");

		BasicAttack.SetActive(false);

		PsychicSmashing2.SetActive(false);

		isAttack = false;

		isMove = true;
	}

    // Update is called once per frame
    void Update()
    {
		if (isMove)
		{
			Move();
		}

		Attack();

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

	void Attack()
	{
		if (Input.GetKey(KeyCode.LeftControl))
		{
			isMove = false;

			isAttack = true;

			BasicAttack.SetActive(true);

		}

		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			isAttack = false;
		}

		if (Input.GetKey(KeyCode.LeftShift))
		{
			isMove = false;

			isAttack = true;

			PsychicSmashing2.SetActive(true);


		}

		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			isAttack = false;
		}

		if (!isAttack)
		{
			if (attackAni.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
			{
				enemyList.Clear();

				BasicAttack.SetActive(false);

				isMove = true;
			}

			if ((PS2.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f) && PS2.GetCurrentAnimatorStateInfo(0).IsName("PsychicSmashing2_hit"))
			{
				enemyList.Clear();

				PsychicSmashing2.SetActive(false);

				isMove = true;
			}
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ground")
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

}
