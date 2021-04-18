using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlectChar : MonoBehaviour
{
	public Character character;

    public void SlectCharacter()
	{
		DataManager.instance.currentCharacter = character;
	}
}
