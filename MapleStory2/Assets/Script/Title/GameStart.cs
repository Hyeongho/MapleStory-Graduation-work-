using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
	public GameObject Fade;
	Image fadeImage;

	// Start is called before the first frame update
	void Start()
	{
		fadeImage = Fade.GetComponent<Image>();
	}

	public void OnStart()
	{
		if (DataManager.instance.currentCharacter == Character.nullChar)
		{
			Debug.Log("캐릭터를 선택해 주세요");
		}

		else
		{
			OnSelectChannel();
		}
	}

	public void OnSelectChannel()
	{
		Fade.SetActive(true);

		fadeImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

		iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 255.0f, "time", 2.0f, "easetype", iTween.EaseType.linear, "onupdate", "FadeUpdate", "oncomplete", "NextScene"));
	}

	void FadeUpdate(float alpha)
	{
		fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha / 255.0f);
	}

	void NextScene()
	{
		SceneManager.LoadScene(2);
	}
}
