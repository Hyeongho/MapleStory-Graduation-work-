using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMove : MonoBehaviour
{
	public bool tutorialMove;

    // Start is called before the first frame update
    void Start()
    {
		tutorialMove = false;
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			tutorialMove = true;
		}
	}
}
