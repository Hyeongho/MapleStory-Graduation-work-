using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Meun;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Meun.activeSelf)
			{
                Meun.SetActive(false);
            }

			else
			{
                Meun.SetActive(true);
            }
        }
    }

    public void GameExit()
	{
        Application.Quit();
	}
}
