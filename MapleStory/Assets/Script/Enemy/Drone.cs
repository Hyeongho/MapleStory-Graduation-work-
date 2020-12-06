using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
	Animator anim;

	bool isTargeting;
	bool isDestory;

	private void Awake()
	{
		anim = this.gameObject.GetComponent<Animator>();
	}

	// Start is called before the first frame update
	void Start()
    {
				
    }

    // Update is called once per frame
    void Update()
    {
		DroneAttacck();
		DroneDestory();
	}

	void DroneAttacck()
	{
		isTargeting = this.gameObject.GetComponent<Enemy>().isTargeting;

		if (isTargeting)
		{
			anim.SetBool("isTarget", true);
		}

		else
		{
			anim.SetBool("isTarget", false);
		}
	}

	void DroneDestory()
	{
		isDestory = this.gameObject.GetComponent<Enemy>().isDestroy;

		if (isDestory)
		{
			anim.SetBool("isDestory", true);
		}

		else
		{
			return;
		}

		if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f) && anim.GetCurrentAnimatorStateInfo(0).IsName("PA_DroneExplode_Clip"))
		{
			Destroy(this.gameObject);
		}
	}
}
