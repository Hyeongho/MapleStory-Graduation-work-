﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    DialogueManager theDM;

    public TextMeshProUGUI TMPtext;

    public List<string> ListSentences;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
           // theDM.ShowDialogue(dialogue);
		}
	}
}
