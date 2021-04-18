using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YunaAttack : MonoBehaviour
{
    GameObject Attack;

    Animator anim;

    bool playerAttack;

    bool isDamge;

    float EnemyHP;

    GameObject Player;

    GameObject Enemy;

    Player player;

	private void Awake()
	{
        Player = GameObject.FindWithTag("Player");

        Enemy = GameObject.FindGameObjectWithTag("Enemy");

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

	// Start is called before the first frame update
	void Start()
    {
        anim = GameObject.FindWithTag("Attack").GetComponent<Animator>();
        Attack = GameObject.FindWithTag("Attack");

        playerAttack = GameObject.FindWithTag("Player").GetComponent<Player>().isAttack;

        EnemyHP = GameObject.FindWithTag("Enemy").GetComponent<Enemy>().EnemyHP;

        isDamge = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetAttack();
    }

    void SetAttack()
    {
        if (!player.isAttack)
        {
            anim.SetBool("isAttack", true);
        }

        else
        {
            anim.SetBool("isAttack", false);
        }
    }

    void Damage()
    {
        if (isDamge)
        {
            EnemyHP -= 10.0f;

            for (int i = 0; i < GameObject.FindWithTag("Player").GetComponent<Player>().enemyList.Count; i++)
            {
                player.enemyList[i].GetComponent<Enemy>().EnemyHP -= 10;
                player.enemyList[i].GetComponent<Enemy>().TakeDamage(10);

                int reaction = Enemy.transform.position.x - Player.transform.position.x > 0 ? 1 : -1;
                Enemy.GetComponent<Rigidbody>().AddForce(new Vector3(reaction, 0, 0) * 5.0f, ForceMode.Impulse);
            }
        }

        //enemyList.Clear();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            player.enemyList.Add(col.gameObject);

            isDamge = true;
        }
    }
}
