using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChannel : MonoBehaviour
{
	public GameObject Fade;

	public GameObject ChaSeleect;

	public GameObject Croa;

	public GameObject gameStart;

	Image fadeImage;

	// Start is called before the first frame update
	void Start()
	{
		fadeImage = Fade.GetComponent<Image>();
	}

	// Update is called once per frame

	public void OnSelectChannel()
	{
		Fade.SetActive(true);

		fadeImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

		iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 255.0f, "time", 2.0f, "easetype", iTween.EaseType.linear, "onupdate", "FadeUpdate", "oncomplete", "ButonHide"));
	}

	void FadeUpdate(float alpha)
	{
		fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha / 255.0f);
	}

	void FadeIn()
	{
		iTween.ValueTo(gameObject, iTween.Hash("from", 255.0f, "to", 0.0f, "time", 2.0f,"delay", 1.0f, "easetype", iTween.EaseType.linear, "onupdate", "FadeUpdate", "oncomplete", "FadeActive"));
	}

	void ButonHide()
	{
		ChaSeleect.SetActive(true);
		Croa.SetActive(false);
		gameStart.SetActive(true);

		FadeIn();
	}

	void FadeActive()
	{
		Fade.SetActive(false);
	}
}
