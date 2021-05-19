using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPMP : MonoBehaviour
{
	Image HP;
	Image MP;

	GameObject Player;

	public float hp;
	float mp;

	private float maxHP;
	private float maxMP;

	private void Awake()
	{
		hp = GameObject.FindWithTag("Player").GetComponent<Player>().HP;
		mp = GameObject.FindWithTag("Player").GetComponent<Player>().MP;

		HP = GameObject.Find("HP").GetComponent<Image>();
		MP = GameObject.Find("MP").GetComponent<Image>();

		Player = GameObject.FindWithTag("Player");

		maxHP = hp;
		maxMP = mp;
	}

	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		hp = GameObject.FindWithTag("Player").GetComponent<Player>().curHP;

		HP.fillAmount = hp / maxHP;
		MP.fillAmount = mp / maxMP;

		if (HP.fillAmount <= 0.0f)
		{
			Player.SetActive(false);
		}
	}
}
