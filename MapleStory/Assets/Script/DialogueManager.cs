using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

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
    }

    public Image portraitImg;

    public TalkManager talkManager;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public GameObject talkPanel;
    public QuestManger questManger;
    public bool isAction;

    private int talkIndex;


    // Start is called before the first frame update
    void Start()
    {
        isAction = false;
        talkIndex = 0;

        Debug.Log(questManger.ChexkQuest());
    }

    public void Action(GameObject _scanObject)
	{
        scanObject = _scanObject;
        NPCManager npcData = scanObject.GetComponent<NPCManager>();

        Debug.Log(npcData.id);
        Debug.Log(npcData.isNpc);

        Talk(npcData.id, npcData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
	{
        int questTalkIndex = questManger.GetQuestTalkIndex(id);

        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        Debug.Log(id);

		if (talkData == null)
		{
            isAction = false;
            talkIndex = 0;
            questManger.ChexkQuest(id);
            return;
		}

		if (isNpc)
		{
            talkText.text = talkData.Split(':')[0];

            Debug.Log(int.Parse(talkData.Split(':')[1]));

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));

            portraitImg.color = new Color(1, 1, 1, 1);

        }

		else
		{
            talkText.text = talkData;

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
	}
}
