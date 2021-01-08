using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMechanics : MonoBehaviour
{
    //основные параметры
    public float speedMove = 11f;  //скорость персонажа
    public float jumpPower = 7f;  //сила прыжка

    public float for_Bulls_speed = 11f;

    public float defolt_speedMove;


    //параметры геймплея для персонажа
    private float gravityForce;  //гравитация персонажа
    private Vector3 moveVector;  //направление перосажа


    //ссылки на компоненты
    private CharacterController ch_controller;
    public Animator ch_animator;  //аниматор

    public GameObject JumpShield;  //ссылки на защиту во время прыжка
    public GameObject AttackShield;  //ссылки на защиту во время атаки

    

    void Start()
    {
        speedMove = for_Bulls_speed;
        ch_controller = GetComponent<CharacterController>();
        defolt_speedMove = speedMove;
        JumpShield.SetActive(false);
        AttackShield.SetActive(false);
    }

    
    void FixedUpdate()
    {
        CharacterMove();
        GamingGravity();
       // Attack_Button();
    }
    
    //метод перемещения персонажа
    private void CharacterMove()
    {
        //перемещение по поверхности
        if (ch_controller.isGrounded) //запрет на упревление во время прыжка
        {
        ch_animator.ResetTrigger("Jump");
        ch_animator.SetBool("Down", false);
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;

        //анимация передвижения персонажа
        if(moveVector.x != 0 || moveVector.z != 0) ch_animator.SetBool("Run", true);
        else ch_animator.SetBool("Run", false);

        if(Vector3.Angle(Vector3.forward,moveVector)>1f|| Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        }
        else
        {
            if(gravityForce <- 3f) ch_animator.SetBool("Down", true);
        }
        
        moveVector.y = gravityForce;

        ch_controller.Move(moveVector * Time.deltaTime);  //метод передвижения по направлению
    }

    public void Attack_Button() //кнопка атаки
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ch_animator.SetBool("Attack", true);
            Invoke("Attack_Off", 0.7f);
        }
    }

    public void Attack_On() //включение атаки при нажатии на кнопку
    {
        ch_animator.SetBool("Attack", true);
        AttackShield.SetActive(true);
        Invoke("For_Attack", 0.5f);
    }

    public void Attack_Off()  //выключение атаки при отпускании кнопки
    {
        ch_animator.SetBool("Attack", false);
    }

    //метод гравитации
    public void GamingGravity()
    {
        if(!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
        if(Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded)
        {
            gravityForce = jumpPower;
            ch_animator.SetTrigger("Jump");
        }
    }
    public void JumpButton() //кнопка прыжка
    {
        if(!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
        if(ch_controller.isGrounded)
        {
            gravityForce = jumpPower;
            ch_animator.SetTrigger("Jump");
            JumpShield.SetActive(true);
            Invoke("for_Jump", 0.8f);
        }
    }

    void For_Attack() //выключение защиты для атаки
    {
        AttackShield.SetActive(false);
    }

    void for_Jump() //выключение защиты для прыжка
    {
        JumpShield.SetActive(false);
    }

}
