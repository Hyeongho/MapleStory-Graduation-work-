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
        //if (instance == null)
        //{
        //    instance = this;
        //}

        //else if (instance != null)
        //{
        //    return;
        //}

        //DontDestroyOnLoad(gameObject);

        camera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
        Range = this.gameObject.GetComponent<CinemachineConfiner>();

        Range.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Range").GetComponent<PolygonCollider2D>();
        
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
