using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    public Image[] colImage;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        //colImage[0] = GameObject.Find("ColHP").GetComponent<Image>();
        //colImage[1] = GameObject.Find("ColMP").GetComponent<Image>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        colImage[0].fillAmount = player.curColHP / player.colHP;
        colImage[1].fillAmount = player.curColMP / player.colMP;
    }
}
