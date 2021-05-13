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
        talkData.Add(2000, new string[] { "안녕:0" });

        talkData.Add(3000, new string[] { "안녕:0" });

        //Quest Talk
        if (isPlayer.isKineis)
		{
            talkData.Add(10 + 1000, new string[] { "유나가 너 찾아.:0" });
        }

		else if (isPlayer.isYuna)
		{
            talkData.Add(10 + 1000, new string[] { "키네시스가 너 찾아.:0" });
        }

        talkData.Add(11 + 2000, new string[] { "asd 너 찾아.:0" });

        talkData.Add(11 + 3000, new string[] { "azxc 너 찾아.:0" });

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
        Debug.Log(id);

        Debug.Log(portraitIndex);

        Debug.Log(id + portraitIndex);

        return portraitData[id + portraitIndex];
	}
}
