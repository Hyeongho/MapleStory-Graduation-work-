using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	private Vector3 velocity;

	private float TimeX;
	private float TimeY;
	private float TimeZ;

	GameObject Player;

	bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	// Start is called before the first frame update
	void Start()
    {
		Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, TimeX);

		float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, TimeY);

		float posZ = Mathf.SmoothDamp(transform.position.z, Player.transform.position.z, ref velocity.z, TimeZ);

		transform.position = new Vector3(posX, posY, transform.position.z);


		if (bounds)

		{

			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),

				Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),

				Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

		}
	}
}
