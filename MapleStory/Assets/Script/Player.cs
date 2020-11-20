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

	private bool LeftRight;
	private bool isRight;
	private bool isLeft;

	private bool isGrounded;
	private float jumpCount = 2.0f;

	bool isMove;

	Rigidbody rb;

	Vector3 Look;

	Animator attackAni;
	Animator PS2; //PsychicSmashing2

	GameObject Attack;
	GameObject PsychicSmashing2;

	public bool isAttack;
	bool iskey;

	public GameObject hubDamageText;
	public Transform hubPos;

	// Start is called before the first frame update
	void Start()
    {
		isGrounded = false;

		LeftRight = false;

		isRight = false;
		isLeft = false;

		rb = GetComponent<Rigidbody>();
		jumpCount = 0.0f;

		attackAni = GameObject.Find("Attack").GetComponent<Animator>();
		Attack = GameObject.Find("Attack");

		PS2 = GameObject.Find("PsychicSmashing2").GetComponent<Animator>();
		PsychicSmashing2 = GameObject.Find("PsychicSmashing2");

		Attack.SetActive(false);

		PsychicSmashing2.SetActive(false);

		isAttack = false;

		isMove = true;
	}

    // Update is called once per frame
    void Update()
    {
		if (isMove)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{

				Look = 0 * Vector3.forward + -1 * Vector3.right;

				transform.rotation = Quaternion.LookRotation(Look);

				transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);

			}

			else if (Input.GetKey(KeyCode.RightArrow))
			{
				Look = 0 * Vector3.forward + 1 * Vector3.right;

				transform.rotation = Quaternion.LookRotation(Look);

				transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
			}

			if (isGrounded)
			{
				if (jumpCount > 0)
				{
					if (Input.GetKeyDown(KeyCode.LeftAlt))
					{
						rb.AddForce(new Vector3(0, 3, 0) * jumpCount, ForceMode.Impulse);
						jumpCount--;
					}

				}
			}
		}

		if (Input.GetKey(KeyCode.LeftControl))
		{
			isMove = false;

			isAttack = true;

			Attack.SetActive(true);

			//attackAni.SetBool("isAttack", true);

		}

		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			//attackAni.SetBool("isAttack", false);
			isAttack = false;

		}

		if (Input.GetKey(KeyCode.LeftShift))
		{
			isMove = false;

			isAttack = true;

			PsychicSmashing2.SetActive(true);

			//PS2.SetBool("IsAttack", true);

		}

		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			//PS2.SetBool("IsAttack", false);

			isAttack = false;
	
		}

		if (!isAttack)
		{
			if (attackAni.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
			{
				Attack.SetActive(false);

				isMove = true;
			}

			if (PS2.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
			{
				PsychicSmashing2.SetActive(false);

				isMove = true;
			}
		}

	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ground")
		{
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
