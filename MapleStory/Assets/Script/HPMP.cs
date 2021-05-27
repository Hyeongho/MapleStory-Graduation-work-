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

	TextMeshProUGUI hpText;
	TextMeshProUGUI mpText;

	private void Awake()
	{
		
	}

	// Start is called before the first frame update
	void Start()
    {
		HP = this.transform.Find("HP").GetComponent<Image>();
		MP = this.transform.Find("MP").GetComponent<Image>();

		hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
		mpText = GameObject.Find("MPText").GetComponent<TextMeshProUGUI>();

		player = GameObject.FindWithTag("Player").GetComponent<Player>();

	}

    // Update is called once per frame
    void Update()
    {
		HP.fillAmount = player.curHP / player.HP;
		MP.fillAmount = player.curMP / player.MP;

		Debug.Log(HP.fillAmount);

		hpText.text = player.curHP.ToString() + " / " + player.HP.ToString();
		mpText.text = player.curMP.ToString() + " / " + player.MP.ToString();

		//if (HP.fillAmount <= 0.0f)
		//{	
		//	player.gameObject.SetActive(false);
		//}
	}
}
