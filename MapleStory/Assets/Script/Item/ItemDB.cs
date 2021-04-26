using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    [SerializeField]
    private List<Consume> ConsumeData;
    [SerializeField]
    private List<Weapon> WeponData;
    [SerializeField]
    private List<Armor> ArmorData;
    [SerializeField]
    private GameObject ItemPrefab;

    public static ItemDB instance;

	private void Awake()
	{
        instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
