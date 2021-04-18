using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialJump : MonoBehaviour
{
	public bool tutorialJump;

	// Start is called before the first frame update
	void Start()
    {
		tutorialJump = false;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			tutorialJump = true;
		}
	}
}
