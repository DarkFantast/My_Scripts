using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForKnife : MonoBehaviour
{
    public GameObject Knifes;
    public int k_numb = 1;

    void Awake()
    {
        if(PlayerPrefs.HasKey("KnifeObject"))
        {
            k_numb = PlayerPrefs.GetInt("KnifeObject");
        }
        else
        {
            k_numb = 1;
        }
    }

    void Start()
    {
        Spawn_Knife();
    }

    void Spawn_Knife()
    {
        if(k_numb == 1)
        {
            Knifes = Resources.Load<GameObject>("Knife_1");
            Instantiate(Knifes);
        }

        if(k_numb == 2)
        {
            Knifes = Resources.Load<GameObject>("Knife_2");
            Instantiate(Knifes);
        }

        if(k_numb == 3)
        {
            Knifes = Resources.Load<GameObject>("Knife_3");
            Instantiate(Knifes);
        }

        if(k_numb == 4)
        {
            Knifes = Resources.Load<GameObject>("Knife_4");
            Instantiate(Knifes);
        }

        if(k_numb == 5)
        {
            Knifes = Resources.Load<GameObject>("Knife_5");
            Instantiate(Knifes);
        }

        if(k_numb == 6)
        {
            Knifes = Resources.Load<GameObject>("Knife_6");
            Instantiate(Knifes);
        }

        if(k_numb == 7)
        {
            Knifes = Resources.Load<GameObject>("Knife_7");
            Instantiate(Knifes);
        }

        if(k_numb == 8)
        {
            Knifes = Resources.Load<GameObject>("Knife_8");
            Instantiate(Knifes);
        }

        if(k_numb == 9)
        {
            Knifes = Resources.Load<GameObject>("Knife_9");
            Instantiate(Knifes);
        }

        if(k_numb == 10)
        {
            Knifes = Resources.Load<GameObject>("Knife_10");
            Instantiate(Knifes);
        }

        if(k_numb == 11)
        {
            Knifes = Resources.Load<GameObject>("Knife_11");
            Instantiate(Knifes);
        }

        if(k_numb == 12)
        {
            Knifes = Resources.Load<GameObject>("Knife_12");
            Instantiate(Knifes);
        }

        if(k_numb == 13)
        {
            Knifes = Resources.Load<GameObject>("Knife_13");
            Instantiate(Knifes);
        }

        if(k_numb == 14)
        {
            Knifes = Resources.Load<GameObject>("Knife_14");
            Instantiate(Knifes);
        }

        if(k_numb == 15)
        {
            Knifes = Resources.Load<GameObject>("Knife_15");
            Instantiate(Knifes);
        }

        if(k_numb == 16)
        {
            Knifes = Resources.Load<GameObject>("Knife_16");
            Instantiate(Knifes);
        }

        if(k_numb == 17)
        {
            Knifes = Resources.Load<GameObject>("Knife_17");
            Instantiate(Knifes);
        }

        if(k_numb == 18)
        {
            Knifes = Resources.Load<GameObject>("Knife_18");
            Instantiate(Knifes);
        }

        if(k_numb == 19)
        {
            Knifes = Resources.Load<GameObject>("Knife_19");
            Instantiate(Knifes);
        }

        if(k_numb == 20)
        {
            Knifes = Resources.Load<GameObject>("Knife_20");
            Instantiate(Knifes);
        }
    }
}
