using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    public string pastPoint;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

		if ((startPoint == player.currentMapName) && (pastPoint == player.pastMapName))
		{
            player.transform.position = this.gameObject.transform.position;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
