using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;

    public string pastMapName;

    Player player;

    bool isPortal;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        isPortal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isPortal)
        {
            player.pastMapName = player.currentMapName;

            player.currentMapName = transferMapName;

            SceneManager.LoadScene(transferMapName);

            isPortal = false;
        }
    }

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
            isPortal = true;
        }
	}

	private void OnTriggerExit(Collider col)
	{
        if (col.gameObject.tag == "Player")
        {
            isPortal = false;
        }
    }
}
