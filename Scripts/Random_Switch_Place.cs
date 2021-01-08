using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Random_Switch_Place : MonoBehaviour
{
    public GameObject Top_1;
    public GameObject Top_2;
    public GameObject Top_3;
    [SerializeField]
    private int Top_Int = 1;

    public GameObject Mid_1;
    public GameObject Mid_2;
    public GameObject Mid_3;
    public GameObject Mid_4;
    public GameObject Mid_5;
    [SerializeField]
    private int Mid_Int = 1;

    public GameObject Bot_1;
    public GameObject Bot_2;
    public GameObject Bot_3;
    [SerializeField]
    private int Bot_Int = 1;


    void Awake()
    {
        Top_Int = Random.Range(1, 4);
        Mid_Int = Random.Range(1, 6);
        Bot_Int = Random.Range(1, 4);

        Top_1.SetActive(false);
        Top_2.SetActive(false);
        Top_3.SetActive(false);

        Mid_1.SetActive(false);
        Mid_2.SetActive(false);
        Mid_3.SetActive(false);
        Mid_4.SetActive(false);
        Mid_5.SetActive(false);

        Bot_1.SetActive(false);
        Bot_2.SetActive(false);
        Bot_3.SetActive(false);
    }


    void Start()
    {
        Switch_Platform_Top();
        Switch_Platform_Mid();
        Switch_Platform_Bot();
    }

    
    void FixedUpdate()
    {
        Restart();
    }


    void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }


    void Switch_Platform_Top()
    {
        switch(Top_Int)
        {
            case 1:
            Top_1.SetActive(true);
            Top_2.SetActive(false);
            Top_3.SetActive(false);
            break;

            case 2:
            Top_1.SetActive(false);
            Top_2.SetActive(true);
            Top_3.SetActive(false);
            break;

            case 3:
            Top_1.SetActive(false);
            Top_2.SetActive(false);
            Top_3.SetActive(true);
            break;
        }
    }


    void Switch_Platform_Mid()
    {
        switch(Mid_Int)
        {
            case 1:
            Mid_1.SetActive(true);
            Mid_2.SetActive(false);
            Mid_3.SetActive(false);
            Mid_4.SetActive(false);
            Mid_5.SetActive(false);
            break;

            case 2:
            Mid_1.SetActive(false);
            Mid_2.SetActive(true);
            Mid_3.SetActive(false);
            Mid_4.SetActive(false);
            Mid_5.SetActive(false);
            break;

            case 3:
            Mid_1.SetActive(false);
            Mid_2.SetActive(false);
            Mid_3.SetActive(true);
            Mid_4.SetActive(false);
            Mid_5.SetActive(false);
            break;

            case 4:
            Mid_1.SetActive(false);
            Mid_2.SetActive(false);
            Mid_3.SetActive(false);
            Mid_4.SetActive(true);
            Mid_5.SetActive(false);
            break;

            case 5:
            Mid_1.SetActive(false);
            Mid_2.SetActive(false);
            Mid_3.SetActive(false);
            Mid_4.SetActive(false);
            Mid_5.SetActive(true);
            break;
        }
    }


    void Switch_Platform_Bot()
    {
        switch(Bot_Int)
        {
            case 1:
            Bot_1.SetActive(true);
            Bot_2.SetActive(false);
            Bot_3.SetActive(false);
            break;

            case 2:
            Bot_1.SetActive(false);
            Bot_2.SetActive(true);
            Bot_3.SetActive(false);
            break;

            case 3:
            Bot_1.SetActive(false);
            Bot_2.SetActive(false);
            Bot_3.SetActive(true);
            break;
        }
    }
}
