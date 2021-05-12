using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManger : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;

	private void Awake()
	{
        questList = new Dictionary<int, QuestData>();

        GenerataData();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerataData()
	{
        questList.Add(10, new QuestData("밖으로 나가기", new int[] {1, 2}));
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
