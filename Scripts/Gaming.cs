using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gaming : MonoBehaviour
{
    //картинки стадий
    public GameObject Igm_En_t1;
    public GameObject Igm_En_t2;
    public GameObject Igm_En_t3;
    public GameObject Igm_En_t4b;
    public GameObject Igm_En_f1;
    public GameObject Igm_En_f2;
    public GameObject Igm_En_f3;
    public GameObject Igm_En_f4b;
    //картинки для ножей
    public GameObject True_igm_1;
    public GameObject True_igm_2;
    public GameObject True_igm_3;
    public GameObject True_igm_4;
    public GameObject True_igm_5;
    public GameObject True_igm_6;
    public GameObject True_igm_7;
    public GameObject False_igm_1;
    public GameObject False_igm_2;
    public GameObject False_igm_3;
    public GameObject False_igm_4;
    public GameObject False_igm_5;
    public GameObject False_igm_6;
    public GameObject False_igm_7;
    public int Knifes = 7;

    public GameObject Enemy;
    public GameObject loaded_Enemy;
    public int Enemy_Int = 1;
    public ParticleSystem boomParticle;

    private int ScInt = 0;
    private Text Score;

    private int Enem_1 = 1;
    private int Enem_2 = 1;
    private int Enem_3 = 1;
    public int Enem_Boss = 1;
    bool Enem_Rand = true;

    public Text Coine_app;
    private int Coi_Int;


    void Awake()
    {
        if(PlayerPrefs.HasKey("Coine_Save"))
        {
            Coi_Int = PlayerPrefs.GetInt("Coine_Save");
            Coine_app.text = (Coi_Int).ToString();
        }
        else
        {
            Coi_Int = 0;
            Coine_app.text = (Coi_Int).ToString();
        }
    }

    void Start()
    {
        Enemy_Int = 1;
        Enemy = GameObject.FindWithTag ("Enemy");
        Active_On_Start();

        //не пройденные враги
        Igm_En_t1.SetActive(true);
        Igm_En_t2.SetActive(true);
        Igm_En_t3.SetActive(true);
        Igm_En_t4b.SetActive(true);
        //пройденные враги
        Igm_En_f1.SetActive(false);
        Igm_En_f2.SetActive(false);
        Igm_En_f3.SetActive(false);
        Igm_En_f4b.SetActive(false);

        Score = GameObject.Find("ScoreInt").GetComponent<Text>();
        Score.text = (ScInt).ToString();

        Enem_1 = Random.Range(1, 5);
        Enem_2 = Random.Range(1, 5);
        Enem_3 = Random.Range(1, 5);
        Enem_Boss = Random.Range(1, 10);
        Enem_1_Function();
    }

    void Update()
    {
        After_Destroy_Enemy();

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Knifes = Knifes - 1;
            if(Time.timeScale == 1)
            {
                ScInt = ScInt + 1;
                Score.text = (ScInt).ToString();
                PlayerPrefs.SetInt("Score_Save", ScInt);
            }
        }

        Knifes_int();

        if(Time.timeScale == 0.9f)
        {
            Knifes = 7;
        }

        if(Enem_Rand == true)
        {
            Enem_1 = Random.Range(1, 5);
            Enem_2 = Random.Range(1, 5);
            Enem_3 = Random.Range(1, 5);
            Enem_Boss = Random.Range(1, 10);
            Enem_Rand = false;
        }
    }

    void After_Destroy_Enemy()
    {
        if(!GameObject.FindWithTag ("Enemy"))
        {
            boomParticle.Play();
            Enemy_Int = Enemy_Int + 1;
            Loading_Enemy();
        }
    }

    void Loading_Enemy()
    {
        if(Enemy_Int == 1)
        {
            Enem_1_Function();

            //не пройденные враги
            Igm_En_t1.SetActive(true);
            Igm_En_t2.SetActive(true);
            Igm_En_t3.SetActive(true);
            Igm_En_t4b.SetActive(true);
            //пройденные враги
            Igm_En_f1.SetActive(false);
            Igm_En_f2.SetActive(false);
            Igm_En_f3.SetActive(false);
            Igm_En_f4b.SetActive(false);
        }

        if(Enemy_Int == 2)
        {
            Enem_2_Function();

            //не пройденные враги
            Igm_En_t1.SetActive(false);
            Igm_En_t2.SetActive(true);
            Igm_En_t3.SetActive(true);
            Igm_En_t4b.SetActive(true);
            //пройденные враги
            Igm_En_f1.SetActive(true);
            Igm_En_f2.SetActive(false);
            Igm_En_f3.SetActive(false);
            Igm_En_f4b.SetActive(false);
        }

        if(Enemy_Int == 3)
        {
            Enem_3_Function();

            //не пройденные враги
            Igm_En_t1.SetActive(false);
            Igm_En_t2.SetActive(false);
            Igm_En_t3.SetActive(true);
            Igm_En_t4b.SetActive(true);
            //пройденные враги
            Igm_En_f1.SetActive(true);
            Igm_En_f2.SetActive(true);
            Igm_En_f3.SetActive(false);
            Igm_En_f4b.SetActive(false);

            Enem_Rand = true;
        }

        if(Enemy_Int == 4)
        {
            Boss_Function();

            //не пройденные враги
            Igm_En_t1.SetActive(false);
            Igm_En_t2.SetActive(false);
            Igm_En_t3.SetActive(false);
            Igm_En_t4b.SetActive(true);
            //пройденные враги
            Igm_En_f1.SetActive(true);
            Igm_En_f2.SetActive(true);
            Igm_En_f3.SetActive(true);
            Igm_En_f4b.SetActive(false);
        }

        if(Enemy_Int == 5)
        {
            //не пройденные враги
            Igm_En_t1.SetActive(false);
            Igm_En_t2.SetActive(false);
            Igm_En_t3.SetActive(false);
            Igm_En_t4b.SetActive(false);
            //пройденные враги
            Igm_En_f1.SetActive(true);
            Igm_En_f2.SetActive(true);
            Igm_En_f3.SetActive(true);
            Igm_En_f4b.SetActive(true);

            Enem_Rand = true;

            Enemy_Int = 0;
        }
    }

    void Active_On_Start()
    {
        //запас ножей
        True_igm_1.SetActive(true);
        True_igm_2.SetActive(true);
        True_igm_3.SetActive(true);
        True_igm_4.SetActive(true);
        True_igm_5.SetActive(true);
        True_igm_6.SetActive(true);
        True_igm_7.SetActive(true);
        //потраченные ножи
        False_igm_1.SetActive(false);
        False_igm_2.SetActive(false);
        False_igm_3.SetActive(false);
        False_igm_4.SetActive(false);
        False_igm_5.SetActive(false);
        False_igm_6.SetActive(false);
        False_igm_7.SetActive(false);
    }

    void Knifes_int()
    {
        if(Knifes == 7)
        {
            //запас ножей
            True_igm_1.SetActive(true);
            True_igm_2.SetActive(true);
            True_igm_3.SetActive(true);
            True_igm_4.SetActive(true);
            True_igm_5.SetActive(true);
            True_igm_6.SetActive(true);
            True_igm_7.SetActive(true);
            //потраченные ножи
            False_igm_1.SetActive(false);
            False_igm_2.SetActive(false);
            False_igm_3.SetActive(false);
            False_igm_4.SetActive(false);
            False_igm_5.SetActive(false);
            False_igm_6.SetActive(false);
            False_igm_7.SetActive(false);
        }

        if(Knifes == 6)
        {
            //запас ножей
            True_igm_1.SetActive(false);
            True_igm_2.SetActive(true);
            True_igm_3.SetActive(true);
            True_igm_4.SetActive(true);
            True_igm_5.SetActive(true);
            True_igm_6.SetActive(true);
            True_igm_7.SetActive(true);
            //потраченные ножи
            False_igm_1.SetActive(true);
            False_igm_2.SetActive(false);
            False_igm_3.SetActive(false);
            False_igm_4.SetActive(false);
            False_igm_5.SetActive(false);
            False_igm_6.SetActive(false);
            False_igm_7.SetActive(false);
        }

        if(Knifes == 5)
        {
            //запас ножей
            True_igm_1.SetActive(false);
            True_igm_2.SetActive(false);
            True_igm_3.SetActive(true);
            True_igm_4.SetActive(true);
            True_igm_5.SetActive(true);
            True_igm_6.SetActive(true);
            True_igm_7.SetActive(true);
            //потраченные ножи
            False_igm_1.SetActive(true);
            False_igm_2.SetActive(true);
            False_igm_3.SetActive(false);
            False_igm_4.SetActive(false);
            False_igm_5.SetActive(false);
            False_igm_6.SetActive(false);
            False_igm_7.SetActive(false);
        }

        if(Knifes == 4)
        {
            //запас ножей
            True_igm_1.SetActive(false);
            True_igm_2.SetActive(false);
            True_igm_3.SetActive(false);
            True_igm_4.SetActive(true);
            True_igm_5.SetActive(true);
            True_igm_6.SetActive(true);
            True_igm_7.SetActive(true);
            //потраченные ножи
            False_igm_1.SetActive(true);
            False_igm_2.SetActive(true);
            False_igm_3.SetActive(true);
            False_igm_4.SetActive(false);
            False_igm_5.SetActive(false);
            False_igm_6.SetActive(false);
            False_igm_7.SetActive(false);
        }

        if(Knifes == 3)
        {
            //запас ножей
            True_igm_1.SetActive(false);
            True_igm_2.SetActive(false);
            True_igm_3.SetActive(false);
            True_igm_4.SetActive(false);
            True_igm_5.SetActive(true);
            True_igm_6.SetActive(true);
            True_igm_7.SetActive(true);
            //потраченные ножи
            False_igm_1.SetActive(true);
            False_igm_2.SetActive(true);
            False_igm_3.SetActive(true);
            False_igm_4.SetActive(true);
            False_igm_5.SetActive(false);
            False_igm_6.SetActive(false);
            False_igm_7.SetActive(false);
        }

        if(Knifes == 2)
        {
            //запас ножей
            True_igm_1.SetActive(false);
            True_igm_2.SetActive(false);
            True_igm_3.SetActive(false);
            True_igm_4.SetActive(false);
            True_igm_5.SetActive(false);
            True_igm_6.SetActive(true);
            True_igm_7.SetActive(true);
            //потраченные ножи
            False_igm_1.SetActive(true);
            False_igm_2.SetActive(true);
            False_igm_3.SetActive(true);
            False_igm_4.SetActive(true);
            False_igm_5.SetActive(true);
            False_igm_6.SetActive(false);
            False_igm_7.SetActive(false);
        }

        if(Knifes == 1)
        {
            //запас ножей
            True_igm_1.SetActive(false);
            True_igm_2.SetActive(false);
            True_igm_3.SetActive(false);
            True_igm_4.SetActive(false);
            True_igm_5.SetActive(false);
            True_igm_6.SetActive(false);
            True_igm_7.SetActive(true);
            //потраченные ножи
            False_igm_1.SetActive(true);
            False_igm_2.SetActive(true);
            False_igm_3.SetActive(true);
            False_igm_4.SetActive(true);
            False_igm_5.SetActive(true);
            False_igm_6.SetActive(true);
            False_igm_7.SetActive(false);
        }

        if(Knifes == 0)
        {
            //запас ножей
            True_igm_1.SetActive(false);
            True_igm_2.SetActive(false);
            True_igm_3.SetActive(false);
            True_igm_4.SetActive(false);
            True_igm_5.SetActive(false);
            True_igm_6.SetActive(false);
            True_igm_7.SetActive(false);
            //потраченные ножи
            False_igm_1.SetActive(true);
            False_igm_2.SetActive(true);
            False_igm_3.SetActive(true);
            False_igm_4.SetActive(true);
            False_igm_5.SetActive(true);
            False_igm_6.SetActive(true);
            False_igm_7.SetActive(true);

            Invoke("After_Zero", 0.5f);
        }
    }

    void After_Zero()
    {
        Knifes = 7;
    }

    void Boss_Function()
    {
        if(Enem_Boss == 1)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_1");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 2)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_2");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 3)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_3");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 4)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_4");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 5)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_5");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 6)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_6");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 7)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_7");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 8)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_8");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 9)
        {
            loaded_Enemy = Resources.Load<GameObject>("Boss_9");
            Instantiate(loaded_Enemy);
        }

        if(Enem_Boss == 0 || Enem_Boss == 10)
        {
            Enem_Rand = true;
        }
    }

    void Enem_1_Function()
    {
        if(Enem_1 == 1)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_1_1");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 2)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_2_1");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 3)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_3_1");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 4)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_4_1");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 0 || Enem_1 == 5)
        {
            Enem_Rand = true;
        }
    }

    void Enem_2_Function()
    {
        if(Enem_1 == 1)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_1_2");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 2)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_2_2");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 3)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_3_2");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 4)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_4_2");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 0 || Enem_1 == 5)
        {
            Enem_Rand = true;
        }
    }

    void Enem_3_Function()
    {
        if(Enem_1 == 1)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_1_3");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 2)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_2_3");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 3)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_3_3");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 4)
        {
            loaded_Enemy = Resources.Load<GameObject>("Board_4_3");
            Instantiate(loaded_Enemy);
        }

        if(Enem_1 == 0 || Enem_1 == 5)
        {
            Enem_Rand = true;
        }
    }
}
