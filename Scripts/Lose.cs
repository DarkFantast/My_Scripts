using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject Lose_Panel;
    public GameObject Buttons_Panel;
    public int hp_point = 1;
    public Score Undead_sc;

    void Start()
    {
        Time.timeScale = 1;
        Lose_Panel.SetActive(false);
        Buttons_Panel.SetActive(true);
    }

    void OnCollisionEnter(Collision otherObj)
    {
    if (otherObj.gameObject.tag == "Enemy") 
    {
        hp_point = hp_point - 1;
        if(hp_point == 0)
        {
        Time.timeScale = 0.05f;
        Sheild_undead_on();
        Lose_Panel.SetActive(true);
        Buttons_Panel.SetActive(false);
        }
        if(hp_point == 1)
        {
            Sheild_undead_on();
            Invoke("Sheild_undead_off", 8f);
        }
    }
    }

    void Sheild_undead_on()
    {
        Undead_sc.Shield_Buff.SetActive(true);
    }

    void Sheild_undead_off()
    {
        Undead_sc.Shield_Buff.SetActive(false);
    }
}
