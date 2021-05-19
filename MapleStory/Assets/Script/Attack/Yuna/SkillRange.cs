using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRange : MonoBehaviour
{
    public GameObject Skill;

    public void StartAttack()
    {
        Skill.SetActive(true);
    }

    public void EndAttack()
    {
        Skill.SetActive(false);
    }

}
