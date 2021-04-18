using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
	TextMeshProUGUI Text;

	TutorialMove tutorialMove;
	TutorialJump tutorialJump;

	List<string> textList = new List<string>();

	// Start is called before the first frame update
	void Start()
    {
		Text = gameObject.GetComponent<TextMeshProUGUI>();
		tutorialMove = GameObject.Find("TutorialMove").GetComponent<TutorialMove>();
		tutorialJump = GameObject.Find("TutorialJump").GetComponent<TutorialJump>();
		textList.Clear();

		SetList();
	}

    // Update is called once per frame
    void Update()
    {
		Text.text = textList[0];

		if (tutorialMove.tutorialMove)
		{
			Text.text = textList[1];
		}

		if (tutorialJump.tutorialJump)
		{
			Text.text = textList[2];
		}

	}

	void SetList()
	{
		textList.Add("←, →를 누르면 이동합니다.");
		textList.Add("alt키를 누르면 점프를 합니다.");
		textList.Add("ctrl키를 누르면 공격을 합니다.");
	}
}
