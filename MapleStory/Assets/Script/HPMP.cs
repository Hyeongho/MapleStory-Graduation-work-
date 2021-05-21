using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPMP : MonoBehaviour
{
	Image HP;
	Image MP;

	Player player;

	public float hp;
	float mp;

	private float maxHP;
	private float maxMP;

	TextMeshProUGUI hpText;
	TextMeshProUGUI mpText;

	private void Awake()
	{
		hp = GameObject.FindWithTag("Player").GetComponent<Player>().HP;
		mp = GameObject.FindWithTag("Player").GetComponent<Player>().MP;

		HP = GameObject.Find("HP").GetComponent<Image>();
		MP = GameObject.Find("MP").GetComponent<Image>();

		hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
		mpText = GameObject.Find("MPText").GetComponent<TextMeshProUGUI>();

		player = GameObject.FindWithTag("Player").GetComponent<Player>();

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

		HP.fillAmount = player.curHP / player.HP;
		MP.fillAmount = player.curMP / player.MP;

		hpText.text = player.curHP.ToString() + " / " + player.HP.ToString();
		mpText.text = player.curMP.ToString() + " / " + player.MP.ToString();

		if (HP.fillAmount <= 0.0f)
		{	
			player.gameObject.SetActive(false);
		}
	}
}
