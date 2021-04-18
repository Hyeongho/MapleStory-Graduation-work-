using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleOut : MonoBehaviour
{
	public void Title()
	{
		this.gameObject.SetActive(false);
		SceneManager.LoadScene(1);
	}
}
