using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Item item;

    public Weapon weapon;
    public Consume consume;
    public Armor armor;

    public SpriteRenderer image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem(Item _item)
	{
		if ((int)_item.itemType == 0)
		{

		}

		else if ((int)_item.itemType == 1)
		{

		}

		else if ((int)_item.itemType == 2)
		{

		}
	}

    public void SetWeapon(Weapon _weapon)
	{
        weapon.objectName = _weapon.objectName;
        weapon.sprite = _weapon.sprite;
        weapon.lv = _weapon.lv;
        weapon.Atk = _weapon.Atk;
	}

    public void SetConsume(Consume _consume)
	{

	}

    public void SetArmor(Armor _armor)
	{

	}
}
