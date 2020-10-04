using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float playerSpeed = 1.0f;

	public int HP;
	public int MP;

	public int ATK;

	private bool LeftRight;
	private bool isRight;
	private bool isLeft;

	public bool isGrounded;
	private float jumpCount = 2.0f;

	Rigidbody rb;

	Vector3 Look;

    // Start is called before the first frame update
    void Start()
    {
		isGrounded = false;

		LeftRight = false;

		isRight = false;
		isLeft = false;

		rb = GetComponent<Rigidbody>();
		jumpCount = 0.0f;
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

	void InputRight()
	{

	}
}
