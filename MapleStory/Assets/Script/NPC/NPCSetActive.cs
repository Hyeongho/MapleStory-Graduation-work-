using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSetActive : MonoBehaviour
{
    Player isPlayer;

    public GameObject Kineisnpc;
    public GameObject Yunanpc;

    // Start is called before the first frame update
    void Start()
    {
        isPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		if (isPlayer.isKineis)
		{
            Kineisnpc.SetActive(false);
            Yunanpc.SetActive(true);
        }

		else
		{
            Kineisnpc.SetActive(true);
            Yunanpc.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
