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

	}

	// Update is called once per frame
	void Update()
	{

	}

	void GenerateData()
	{
		talkData.Add(1000, new string[] { "안녕:0" });

		talkData.Add(2000, new string[] { "안녕:0" });

		talkData.Add(3000, new string[] { "안녕:0" });

		talkData.Add(5000, new string[] { "..." });

		//Quest Talk
		if (isPlayer.isKineis)
		{
			talkData.Add(10 + 1000, new string[] { "오랜만이네:0", "유나가 너 찾아.:0" });

			talkData.Add(11 + 2000, new string[] 
			{ 
				"안녕:0",
				"오랜만이네:0",
				"너도 소식 들었지?:0",
				"지금 하얀 마법사가 초능력자들을 모아서 조직을 만든 거 같아:0",
				"지금 여러 지역에서 초능력자들이 폭동을 일으키고 있어:0",
				"다른 초능력자들의 폭동을 진압해줘:0"
			});

			talkData.Add(20 + 2000, new string[]
			{
				"오랜만이네:0",
				"너도 소식 들었지?:0",
				"지금 하얀 마법사가 초능력자들을 모아서 조직을 만든 거 같아:0",
				"지금 여러 지역에서 초능력자들이 폭동을 일으키고 있어:0",
				"다른 초능력자들의 폭동을 진압해줘:0"
			});

			talkData.Add(21 + 2000, new string[]
			{
				"아직 진압이 덜 된거 같은데:0"
			});

			talkData.Add(22 + 2000, new string[]
			{
				"수고했어:0"
			});

			talkData.Add(30 + 2000, new string[]
			{
				"초능력자들을 제압하다가 발견한거야:0",
				"난 다른 지역을 더 조사해볼게:0",
				"이걸 제이에게 갖다줘:0"
			});

			talkData.Add(31 + 1000, new string[]
			{
				"이게 뭐야?:0"
			});

			talkData.Add(40 + 1000, new string[]
			{
				"이건 계획서 같은데?:0",
				"암호로 되어 있는데:0",
				"잠깐만 기달려봐:0",
				"...:0",
				"...:0",
				"다 해독했다:0",
				"유나한테는 연락 했으니까:0",
				"유나한테 가봐:0"
			});

			talkData.Add(41 + 2000, new string[]
			{
				"제이한테 연락은 받았어:0",
				"다른 곳도 이미 공격을 받은 거 같아:0",
				"그 곳에 있는 시민들을 구해줘:0",
				"나는 다른 곳으로 갈게:0"
			});

			talkData.Add(50 + 2000, new string[]
			{
				"다른 곳도 이미 공격을 받은 거 같아:0",
				"그 곳에 있는 시민들을 구해줘:0",
				"나는 다른 곳으로 갈게:0"
			});

			talkData.Add(51 + 2000, new string[]
			{
				"아직 시민이 남아 있어:0"
			});

			talkData.Add(51 + 5000, new string[]
			{
				"살려주세요"
			});

			talkData.Add(52 + 5000, new string[]
			{
				"구해 주셔서 감사합니다."
			});

			talkData.Add(53 + 2000, new string[]
			{
				"수고 했어:0",
				"다음에 다시 연락할게:0",
			});
		}

		else if (isPlayer.isYuna)
		{
			talkData.Add(10 + 1000, new string[] { "수련은 잘 되가?:0", "키네시스가 너 찾아.:0", "키네시스한테 가봐:0" });
			talkData.Add(11 + 3000, new string[] 
			{ 
				"안녕:0",
				"오랜만이네:0",
				"너도 소식 들었지?:0",
				"지금 하얀 마법사가 초능력자들을 모아서 조직을 만든 거 같아:0",
				"지금 여러 지역에서 초능력자들이 폭동을 일으키고 있어:0",
				"다른 초능력자들의 폭동을 진압해줘:0"
			});

			talkData.Add(20 + 3000, new string[]
			{
				"오랜만이네:0",
				"너도 소식 들었지?:0",
				"지금 하얀 마법사가 초능력자들을 모아서 조직을 만든 거 같아:0",
				"지금 여러 지역에서 초능력자들이 폭동을 일으키고 있어:0",
				"다른 초능력자들의 폭동을 진압해줘:0"
			});

			talkData.Add(21 + 3000, new string[]
			{
				"아직 진압이 덜 된거 같은데:0"
			});

			talkData.Add(22 + 3000, new string[]
			{
				"수고했어:0"
			});

			talkData.Add(30 + 3000, new string[]
			{
				"초능력자들을 제압하다가 발견한거야:0", 
				"난 다른 지역을 더 조사해볼게:0", 
				"이걸 제이에게 갖다줘:0"
			});

			talkData.Add(31 + 1000, new string[]
			{
				"이게 뭐야?:0"
			});

			talkData.Add(40 + 1000, new string[]
			{
				"이건 계획서 같은데?:0",
				"암호로 되어 있는데:0", 
				"잠깐만 기달려봐:0", 
				"...:0", 
				"...:0",
				"다 해독했다:0",
				"키네시스한테는 연락 했으니까:0",
				"키네시스한테 가봐:0"
			});

			talkData.Add(41 + 3000, new string[]
			{
				"제이한테 연락은 받았어:0",
				"다른 곳도 이미 공격을 받은 거 같아:0",
				"그 곳에 있는 시민들을 구해줘:0",
				"나는 다른 곳으로 갈게:0"
			});

			talkData.Add(50 + 3000, new string[]
			{
				"다른 곳도 이미 공격을 받은 거 같아:0", 
				"그 곳에 있는 시민들을 구해줘:0", 
				"나는 다른 곳으로 갈게:0"
			});

			talkData.Add(51 + 3000, new string[]
			{
				"아직 시민이 남아 있어:0"
			});

			talkData.Add(51 + 5000, new string[]
			{
				"살려주세요"
			});

			talkData.Add(52 + 5000, new string[]
			{
				"구해 주셔서 감사합니다."
			});

			talkData.Add(53 + 3000, new string[]
			{
				"수고 했어:0",
				"다음에 다시 연락할게:0",
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
