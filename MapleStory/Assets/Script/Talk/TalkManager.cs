using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalkManager : MonoBehaviour
{
	public static TalkManager instance;

	Dictionary<int, string[]> talkData;
	Dictionary<int, Sprite> portraitData;

	[SerializeField]

	public Sprite[] portraitArr;

	Player isPlayer;

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

		talkData = new Dictionary<int, string[]>();
		portraitData = new Dictionary<int, Sprite>();

		isPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		GenerateData();

	}

	// Start is called before the first frame update
	void Start()
	{
		//foreach (KeyValuePair<int, Sprite> data in portraitData)
		//{
		//	Debug.Log(data.Key + " " + data.Value);
		//}

	}

	// Update is called once per frame
	void Update()
	{

	}

	void GenerateData()
	{
		talkData.Add(1000, new string[] { "제이 입니다:0", "asdsadas:0" });

		talkData.Add(3000, new string[] { "안녕:0" });

		//Quest Talk
		if (isPlayer.isKineis)
		{
			talkData.Add(10 + 1000, new string[] { "유나가 너 찾아.:0" });
		}

		else if (isPlayer.isYuna)
		{
			talkData.Add(10 + 1000, new string[] { "수련은 잘 되가?:0", "키네시스가 너 찾아.:0", "키네시스한테 가봐:0"});
			talkData.Add(11 + 3000, new string[] { "안녕:0" });

			talkData.Add(20 + 3000, new string[] 
			{ 
				"오랜만이네:0",
				"너도 소식 들었지?:0",
				"지금 하얀 마법사가 초능력자들을 모아서 조직을 만든 거 같아:0",
				"지금 여러 지역에서 초능력자들이 폭동을 일으키고 있어:0", 
				"다른 초능력자들의 폭동을 진압해줘:0", 
			});

			talkData.Add(21 + 3000, new string[]
			{
				"아직 진압이 덜 된거 같은데:0"
			});

			talkData.Add(22 + 3000, new string[]
			{
				"수고했어:0"
			});
		}

		portraitData.Add(1000, portraitArr[0]);
		portraitData.Add(2000, portraitArr[1]);
		portraitData.Add(3000, portraitArr[2]);
	}

	public string GetTalk(int id, int talkIndex)
	{
		if (!talkData.ContainsKey(id))
		{
			if (!talkData.ContainsKey(id - id % 10))
			{
				if (talkIndex == talkData[id - id % 100].Length)
				{
					return null;
				}

				else
				{
					return talkData[id - id % 100][talkIndex];
				}
			}

			else
			{
				if (talkIndex == talkData[id - id % 10].Length)
				{
					return null;
				}

				else
				{
					return talkData[id - id % 10][talkIndex];
				}
			}

		}

		if (talkIndex == talkData[id].Length)
		{
			return null;
		}

		else
		{
			return talkData[id][talkIndex];
		}
	}

	public Sprite GetPortrait(int id, int portraitIndex)
	{
		return portraitData[id + portraitIndex];
	}
}
