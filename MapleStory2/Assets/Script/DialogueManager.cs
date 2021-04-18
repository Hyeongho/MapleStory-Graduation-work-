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

    public TextMeshProUGUI text;
    public SpriteRenderer rendererSprite;
    public SpriteRenderer rendererDialogueWindow;

    public List<string> listSentences;
    public List<Sprite> listSprites;
    public List<Sprite> listDialogueWindows;

    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        text.text = "";

        listSentences = new List<string>();
        listSprites = new List<Sprite>();
        listDialogueWindows = new List<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			count++;

            text.text = "";

			if (count != listSentences.Count - 1)
			{
                StopAllCoroutines();

                ExitDialogue();
            }

			else
			{
                StopAllCoroutines();

                StartCoroutine("StartDialogueCoroutine");
            }
		}
    }

    public void ShowDialogue(Dialogue dialog)
    {
        this.gameObject.SetActive(true);

        for (int i = 0; i < dialog.sentences.Length; i++)
        {
            listSentences.Add(dialog.sentences[i]);
            listSprites.Add(dialog.sprites[i]);
            listDialogueWindows.Add(dialog.dialogueWindows[i]);
        }

        StartCoroutine("StartDialogueCoroutine");
    }

    public void ExitDialogue()
	{
        text.text = "";
        count = 0;

        listSentences.Clear();
        listSprites.Clear();
        listDialogueWindows.Clear();

        this.gameObject.SetActive(false);
    }

    IEnumerable StartDialogueCoroutine()
    {
		if (count > 0)
		{
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])
            {
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
                rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
            }

			else
			{
                if (listSprites[count] != listSprites[count - 1])
                {
                    rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
                }

				else
				{
                    yield return new WaitForSeconds(0.05f);
				}
            }       
        }

		else
		{
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
            rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
        }
		
        for (int i = 0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i];
            yield return new WaitForSeconds(0.01f);
        }
    }
}
