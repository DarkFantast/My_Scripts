using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayBulls : MonoBehaviour
{
    public GameObject But_Bull_Pal_2;
    public GameObject But_Bull_Next_2;
    public GameObject But_Bull_Pal_3;
    public GameObject But_Bull_Next_3;
    public GameObject But_Bull_Pal_4;
    public GameObject But_Bull_Next_4;
    public GameObject But_Bull_Pal_5;
    public GameObject But_Bull_Next_5;

    public GameObject Map_pay_2;
    public GameObject Map_pay_3;
    public GameObject Map_2_Next;
    public GameObject Map_3_Next;

    private int Bull_2 = 1;
    private int Bull_3 = 1;
    private int Bull_4 = 1;
    private int Bull_5 = 1;

    private int Map_2 = 1;
    private int Map_3 = 1;

    private int Coin;


    void Start()
    {
        if(PlayerPrefs.HasKey("Score_Coin"))
        {
            Coin = PlayerPrefs.GetInt("Score_Coin");
        }
        if(PlayerPrefs.HasKey("Condition_Bull_2"))
        {
            Bull_2 = PlayerPrefs.GetInt("Condition_Bull_2");
        }
        if(PlayerPrefs.HasKey("Condition_Bull_3"))
        {
            Bull_3 = PlayerPrefs.GetInt("Condition_Bull_3");
        }
        if(PlayerPrefs.HasKey("Condition_Bull_4"))
        {
            Bull_4 = PlayerPrefs.GetInt("Condition_Bull_4");
        }
        if(PlayerPrefs.HasKey("Condition_Bull_5"))
        {
            Bull_5 = PlayerPrefs.GetInt("Condition_Bull_5");
        }

        Coin_int_1();
        Coin_int_2();

        Map_int_1();
        Map_int_2();

        if(PlayerPrefs.HasKey("Condition_Map_2"))
        {
            Map_2 = PlayerPrefs.GetInt("Condition_Map_2");
        }
        if(PlayerPrefs.HasKey("Condition_Map_3"))
        {
            Map_3 = PlayerPrefs.GetInt("Condition_Map_3");
        }
    }


    void FixedUpdate()
    {
        Coin_int_1();
        Coin_int_2();

        Map_int_1();
        Map_int_2();
    }

    void Coin_int_1()
    {
        if(Bull_2 == 1)
        {
            But_Bull_Pal_2.SetActive(true);
            But_Bull_Next_2.SetActive(false);
        }
        if(Bull_3 == 1)
        {
            But_Bull_Pal_3.SetActive(true);
            But_Bull_Next_3.SetActive(false);
        }
        if(Bull_4 == 1)
        {
            But_Bull_Pal_4.SetActive(true);
            But_Bull_Next_4.SetActive(false);
        }
        if(Bull_5 == 1)
        {
            But_Bull_Pal_5.SetActive(true);
            But_Bull_Next_5.SetActive(false);
        }
    }

    void Coin_int_2()
    {
        if(Bull_2 == 2)
        {
            But_Bull_Pal_2.SetActive(false);
            But_Bull_Next_2.SetActive(true);
        }
        if(Bull_3 == 2)
        {
            But_Bull_Pal_3.SetActive(false);
            But_Bull_Next_3.SetActive(true);
        }
        if(Bull_4 == 2)
        {
            But_Bull_Pal_4.SetActive(false);
            But_Bull_Next_4.SetActive(true);
        }
        if(Bull_5 == 2)
        {
            But_Bull_Pal_5.SetActive(false);
            But_Bull_Next_5.SetActive(true);
        }
    }

    void Map_int_1()
    {
        if(Map_2 == 1)
        {
            Map_pay_2.SetActive(true);
            Map_2_Next.SetActive(false);
        }
        if(Map_3 == 1)
        {
            Map_pay_3.SetActive(true);
            Map_3_Next.SetActive(false);
        }
    }

    void Map_int_2()
    {
        if(Map_2 == 2)
        {
            Map_pay_2.SetActive(false);
            Map_2_Next.SetActive(true);
        }
        if(Map_3 == 2)
        {
            Map_pay_3.SetActive(false);
            Map_3_Next.SetActive(true);
        }
    }

    public void PayButton_2()
    {
        if(Coin >= 500)
        {
            Coin = Coin - 500;
            Bull_2 = 2;
            PlayerPrefs.SetInt("Score_Coin", Coin);
            PlayerPrefs.SetInt("Condition_Bull_2", Bull_2);
        }
    }

    public void PayButton_3()
    {
        if(Coin >= 3000)
        {
            Coin = Coin - 3000;
            Bull_3 = 2;
            PlayerPrefs.SetInt("Score_Coin", Coin);
            PlayerPrefs.SetInt("Condition_Bull_3", Bull_3);
        }
    }

    public void PayButton_4()
    {
        if(Coin >= 12000)
        {
            Coin = Coin - 12000;
            Bull_4 = 2;
            PlayerPrefs.SetInt("Score_Coin", Coin);
            PlayerPrefs.SetInt("Condition_Bull_4", Bull_4);
        }
    }

    public void PayButton_5()
    {
        if(Coin >= 20000)
        {
            Coin = Coin - 20000;
            Bull_5 = 2;
            PlayerPrefs.SetInt("Score_Coin", Coin);
            PlayerPrefs.SetInt("Condition_Bull_5", Bull_5);
        }
    }


    public void Pay_Map_2()
    {
        if(Coin >= 7000)
        {
            Coin = Coin - 7000;
            Map_2 = 2;
            PlayerPrefs.SetInt("Score_Coin", Coin);
            PlayerPrefs.SetInt("Condition_Map_2", Map_2);
        }
    }

    public void Pay_Map_3()
    {
        if(Coin >= 4000)
        {
            Coin = Coin - 4000;
            Map_3 = 2;
            PlayerPrefs.SetInt("Score_Coin", Coin);
            PlayerPrefs.SetInt("Condition_Map_3", Map_3);
        }
    }
}
