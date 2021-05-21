using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPScript : MonoBehaviour
{
    Image expImage;

    TextMeshProUGUI expText;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        expImage = GameObject.Find("EXP").GetComponent<Image>();
        expText = GameObject.Find("EXPText").GetComponent<TextMeshProUGUI>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        expImage.fillAmount = player.curEXP / player.EXP;

        float percentage = (player.curEXP / player.EXP) * 100;

        expText.text = player.curEXP + " [ " + string.Format("{0:0.##}", percentage) + "% ] ";
    }
}
