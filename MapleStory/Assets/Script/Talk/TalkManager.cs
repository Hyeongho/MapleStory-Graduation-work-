using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    Player isPlayer;

    private void Awake()
	{
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
        talkData.Add(1, new string[] { "제이 입니다:0", "asdsadas:0" });


		//Quest Talk
		if (isPlayer.isKineis)
		{
            talkData.Add(1 + 10, new string[] { "유나가 너 찾아.:0" });
        }

		else if (isPlayer.isYuna)
		{
            talkData.Add(1 + 10, new string[] { "키네시스가 너 찾아.:0" });
        }               

        portraitData.Add(1, portraitArr[0]);
	}

    public string GetTalk(int id, int talkIndex)
	{
		if (!talkData.ContainsKey(id))
		{
			if (!talkData.ContainsKey(id - id % 10))
			{
                return GetTalk(id - id % 100, talkIndex);
            }

			else
			{
                return GetTalk(id - id % 10, talkIndex);
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
