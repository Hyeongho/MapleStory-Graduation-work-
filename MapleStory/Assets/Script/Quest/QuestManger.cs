using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManger : MonoBehaviour
{
    public static QuestManger instance;

    public int questId;
    public int questActionIndex;

    Player isPlayer;

    Dictionary<int, QuestData> questList;

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

        questList = new Dictionary<int, QuestData>();

        isPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        GenerataData();
	}

    void GenerataData()
	{
		if (isPlayer.isKineis)
		{
            questList.Add(10, new QuestData("키네시스", new int[] { 1000, 2000 }));
        }

		else if (isPlayer.isYuna)
		{
            questList.Add(10, new QuestData("유나", new int[] { 1000, 3000 }));
        }

        questList.Add(20, new QuestData("퀘스트 클리어", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
	{
        return questId + questActionIndex;
	}

    public string ChexkQuest(int id)
	{
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        ControlQuest();

        if (questActionIndex == questList[questId].npcId.Length)
		{
            NextQuest();
        }

        return questList[questId].questName;
        
	}

    public string ChexkQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
	{
        questId += 10;

        questActionIndex = 0;

    }

    void ControlQuest()
	{

	}
}
