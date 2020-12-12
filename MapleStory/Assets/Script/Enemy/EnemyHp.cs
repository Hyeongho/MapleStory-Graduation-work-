﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
	Transform cam;

	private void Awake()
	{
		cam = Camera.main.transform;
	}

    // Update is called once per frame
    void Update()
    {
		transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
    }
}
