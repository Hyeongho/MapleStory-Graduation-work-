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

	Rigidbody rb;

	Vector3 Look;

	Animator attackAni;

	GameObject Attack;

	bool isAttack;

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

		Attack.SetActive(false);

		isAttack = false;
	}

    // Update is called once per frame
    void Update()
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

		if (Input.GetKey(KeyCode.LeftControl))
		{
			Attack.SetActive(true);

			attackAni.SetBool("isAttack", true);

			isAttack = true;
		}

		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			attackAni.SetBool("isAttack", false);
			isAttack = false;
		}

		if (attackAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
		{
			Attack.SetActive(false);
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

}
