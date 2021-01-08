using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float move_speed;
    public float rotation_speed;
    public Transform enemy; 

    public GameObject condition_1;
    public GameObject condition_2;

    private Rigidbody rb;
    readonly Vector3 force = new Vector3 (0, 1500, 0);


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        condition_1.SetActive(true);
        condition_2.SetActive(false);
        player = GameObject.FindWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        var look_dir = player.position - enemy.position;
        look_dir.y = 0;
        enemy.rotation = Quaternion.Slerp(enemy.rotation,Quaternion.LookRotation(look_dir),rotation_speed * Time.deltaTime);
        enemy.position += enemy.forward * move_speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision otherObj)
    {
    if (otherObj.gameObject.tag == "Head") 
    {
        condition_1.SetActive(false);
        condition_2.SetActive(true);
        move_speed = 0f;
        rb.AddForce(force);
        rotation_speed = 0.3f;
        Destroy(gameObject, 1f);
    }
    }
}
