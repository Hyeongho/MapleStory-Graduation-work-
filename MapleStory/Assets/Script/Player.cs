using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public static Player instance;

	DataManager dataManager;

	bool IsKinesis = false;
	bool IsYuna = false;

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

	public GameObject inventoryPanel;
	bool activelnventory = false;

	public List<GameObject> enemyList = new List<GameObject>();

	public string currentMapName;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		else if (instance != null)
		{
			return;
		}

		DontDestroyOnLoad(gameObject);

		rb = GetComponent<Rigidbody>();

		dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
	}

	// Start is called before the first frame update
	void Start()
    {
		isGrounded = false;

		rb = GetComponent<Rigidbody>();
		jumpCount = 0.0f;

		playerAni = this.gameObject.GetComponent<Animator>();

		if ((int)DataManager.instance.currentCharacter == 1)
		{
			attackAni = GameObject.Find("Attack").GetComponent<Animator>();
			BasicAttack = GameObject.Find("Attack");

			PS2 = GameObject.Find("PsychicSmashing2").GetComponent<Animator>();
			PsychicSmashing2 = GameObject.Find("PsychicSmashing2");

			BasicAttack.SetActive(false);

			PsychicSmashing2.SetActive(false);

			IsKinesis = true;
		}

		else if ((int)DataManager.instance.currentCharacter == 2)
		{
			IsYuna = true;
		}

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

		if (Input.GetKeyDown(KeyCode.I))
		{
			activelnventory = !activelnventory;
			inventoryPanel.SetActive(activelnventory);
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
		if (IsKinesis)
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

				if ((PS2.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) && PS2.GetCurrentAnimatorStateInfo(0).IsName("PsychicSmashing2_hit"))
				{
					enemyList.Clear();

					PsychicSmashing2.SetActive(false);

					isMove = true;
				}
			}
		}

		else if(IsYuna)
		{
			if (Input.GetKey(KeyCode.LeftControl))
			{
				isMove = false;

				isAttack = true;
			}

			else if (Input.GetKeyUp(KeyCode.LeftControl))
			{
				isMove = false;

				isAttack = true;
			}

<<<<<<< HEAD
			if (Input.GetKey(KeyCode.LeftShift))
=======
			if ((PS2.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f) && PS2.GetCurrentAnimatorStateInfo(0).IsName("PsychicSmashing2_hit"))
>>>>>>> parent of 096ce3f8 (210303)
			{
				isMove = false;

				isAttack = true;
			}

			else if (Input.GetKey(KeyCode.LeftShift))
			{
				isMove = false;

				isAttack = true;
			}

			if (!isAttack)
			{

			}
		}

		else
		{
			return;
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

}
