using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    bool isInven = false;

    public GameObject Inven;

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
        Inven.SetActive(isInven);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.I))
		{
            isInven = !isInven;
            Inven.SetActive(isInven);
        }
    }
}
