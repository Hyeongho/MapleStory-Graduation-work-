using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleText : MonoBehaviour
{
	TextMeshProUGUI titleText;

	float time;
	float fadeTime;

	Color alpha;

	GameObject Title;

	Animator titleAni;

	// Start is called before the first frame update
	void Start()
    {
		titleText = GameObject.Find("TitleText").GetComponent<TextMeshProUGUI>();
		Title = GameObject.Find("Title");
		titleAni = Title.GetComponent<Animator>();

		Title.SetActive(false);
		titleText.gameObject.SetActive(false);

		time = 0.0f;
		fadeTime = 2.0f;

		alpha = titleText.color;

		alpha.a = 0.0f;

		StartCoroutine(FadeIn());
    }

	IEnumerator FadeIn()
	{
		time = 0.0f;	

		yield return new WaitForSeconds(0.5f);

		titleText.gameObject.SetActive(true);

		while (alpha.a < 1.0f)
		{
			time += Time.deltaTime / fadeTime;
			alpha.a = Mathf.Lerp(0.0f, 1.0f, time);
			titleText.color = alpha;

			yield return null;
		}

		time = 0.0f;

		yield return new WaitForSeconds(1.0f);

		while (alpha.a > 0.0f)
		{
			time += Time.deltaTime / fadeTime;
			alpha.a = Mathf.Lerp(1.0f, 0.0f, time);
			titleText.color = alpha;

			yield return null;

		}

		titleText.gameObject.SetActive(false);

		Title.SetActive(true);

		yield return null;
	}
}
