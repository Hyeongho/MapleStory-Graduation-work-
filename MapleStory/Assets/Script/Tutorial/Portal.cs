using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public GameObject Spawm;

	GameObject Player;

	bool isPortal;

    // Start is called before the first frame update
    void Start()
    {
		isPortal = false;

		Player = GameObject.FindWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.UpArrow) && isPortal)
		{
			Player.gameObject.transform.position = Spawm.transform.position;

			isPortal = false;
		}
	}

	private void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "Player")
		{
			isPortal = true;
		}
	}

	private void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			isPortal = false;
		}
	}
}
