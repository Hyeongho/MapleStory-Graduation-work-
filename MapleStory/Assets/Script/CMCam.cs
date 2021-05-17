using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMCam : MonoBehaviour
{
    public static CMCam instance;

    new CinemachineVirtualCamera camera;

    CinemachineConfiner Range;

    GameObject Player;

    ReSpawn reSpawn;

	private void Awake()
	{
        camera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
        Range = this.gameObject.GetComponent<CinemachineConfiner>();
        
    }

	// Start is called before the first frame update
	void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        camera.Follow = Player.transform;
        camera.LookAt = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
