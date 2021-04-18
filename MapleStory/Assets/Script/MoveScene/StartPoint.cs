using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

		if (startPoint == player.currentMapName)
		{
            player.transform.position = this.gameObject.transform.position;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
