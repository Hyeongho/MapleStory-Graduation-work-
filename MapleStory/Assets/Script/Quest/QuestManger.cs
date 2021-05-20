﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManger : MonoBehaviour
{
    public static QuestManger instance;

    public int questId;
    public int questActionIndex;

    Player isPlayer;

    EnemyController Enemy;

    Dictionary<int, QuestData> questList;

    bool isComplet;

    int completCount;
    public int count;

	private void Awake()
	{
        isComplet = true;

        count = 0;

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

        Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();

        GenerataData();
	}

	private void Start()
	{
		
	}

	void Update()
	{
		if (questId == 20 && questActionIndex == 1)
		{
            if (count >= 5)
            {
                isComplet = true;

                questActionIndex = 2;
            }

			else
			{
                questActionIndex = 1;
            }
        }     
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
            questList.Add(20, new QuestData("초능력자 진압", new int[] { 3000, 3000, 3000 }));
        }

        questList.Add(30, new QuestData("퀘스트 클리어", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
	{
        return questId + questActionIndex;
	}

    public string ChexkQuest(int id)
	{
        Debug.Log(id);
        Debug.Log(questList[questId].npcId[questActionIndex]);

        if (id == questList[questId].npcId[questActionIndex])
        {
            switch (questId)
            {
                case 10:
                    questActionIndex++;
                    isComplet = true;
                    break;

                case 20:
                    if (questActionIndex == 1)
                    {
                        if (count >= 5)
                        {
                            isComplet = true;
                        }

                        else
                        {
                            questActionIndex = 1;
                        }

                    }

					else
					{
                        questActionIndex++;

                    }
                    break;

                default:
                    questActionIndex++;
                    break;
            }
        }

        if (questActionIndex == questList[questId].npcId.Length)
		{
            isComplet = false;

            count = 0;

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
		switch (questId)
		{
			case 10:
				isComplet = true;
				break;

			case 20:
				if (questActionIndex == 1)
				{
					if (count >= 5)
					{
						isComplet = true;
					}

					else
					{
						questActionIndex = 1;
					}

				}
				break;
		}
	}

    void Complet()
	{
        switch (questId)
        {
            case 10:
                isComplet = true;
                break;

            case 20:
                if (questActionIndex == 1)
                {
                    if (count >= 5)
                    {                        
                        isComplet = true;
                    }

                    else
                    {
                        questActionIndex = 1;
                    }

                }
                break;
        }
    }
}
