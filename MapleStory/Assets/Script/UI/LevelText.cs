using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    Player player;

    TextMeshProUGUI lvText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        lvText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        lvText.text = player.Lv.ToString();
    }
}
