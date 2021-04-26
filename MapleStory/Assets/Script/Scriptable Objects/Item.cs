using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon, 
    Consume, 
    Armor
}

public class Item : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public int quantity;
    public bool stackable;
    public ItemType itemType;

    public bool Use()
	{
        return false;
	}

}
