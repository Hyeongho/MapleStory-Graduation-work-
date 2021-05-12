using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.Find("TutorialText");
    }

    // Update is called once per frame
    void Update()
    {
		if (SceneManager.GetActiveScene().buildIndex != 2)
		{
            Destroy(tutorialText);
        }
    }
}
