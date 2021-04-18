using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
	nullChar, Kinesis, Yuna
}

public class DataManager : MonoBehaviour
{
	public static DataManager instance;

	public Character currentCharacter;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		else if (instance != null)
		{
			return;
		}

		DontDestroyOnLoad(gameObject);
	}
}
