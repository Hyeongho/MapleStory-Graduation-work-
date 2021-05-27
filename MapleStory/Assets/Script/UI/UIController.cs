using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    QuestManger questManger;

    private void Awake()
    {
        var obj = FindObjectsOfType<UIController>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    private GameObject tutorialText;

    public GameObject Clear;
    public Image Panel;

    AudioSource audioSource;

    bool isPlay;

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.Find("TutorialText");

        questManger = GameObject.Find("Quest Manager").GetComponent<QuestManger>();

        isPlay = false;

        Clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (SceneManager.GetActiveScene().buildIndex != 2)
		{
            Destroy(tutorialText);
        }

		if (questManger.questId == 60)
		{
            Clear.SetActive(true);

            audioSource = Clear.GetComponent<AudioSource>();

			if (!audioSource.isPlaying && !isPlay)
			{
                isPlay = true;

                iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 255.0f, "time", 2.0f, "easetype", iTween.EaseType.linear, "onupdate", "FadeUpdate", "oncomplete", "EndGame"));

                audioSource.Play();
            }                   
        }
    }

    void FadeUpdate(float alpha)
    {
        Panel.color = new Color(0.0f, 0.0f, 0.0f, alpha / 255.0f);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
