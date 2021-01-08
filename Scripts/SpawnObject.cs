using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
public Vector3 center; // координаты центра
public Vector3 size; // координаты в которых будут появляться объекты

public GameObject First_Enemy; // первый враг
public GameObject Second_Enemy; //второй враг
public GameObject Third_Enemy; //третий враг

public GameObject Box_Shield; //коробка щита
public GameObject Box_Speed; //коробка скорости
public GameObject Box_X2; //коробка на двойной бонус

public float First_timeSpawnObj = 3; //время первого появления первого врага
public float Second_timeSpawnObj = 7; //время первого появления второго врага
public float Third_timeSpawnObj = 5; //время первого появления третьего врага

public float Box_timeShield = 12f;  //время первого появления коробки щита
public float Box_timeSpeed = 17f;  //время первого появления коробки скорости
public float Box_timeX2 = 15f;  //время первого появления коробки двойного бонуса


private void FixedUpdate()
{
    First_timeSpawnObj -= Time.deltaTime;
    if(First_timeSpawnObj <= 0)
    {
        Spawn_FirstEnemy();
        First_timeSpawnObj = Random.Range(0.5f, 1.5f);
    }

    Second_timeSpawnObj -= Time.deltaTime;
    if(Second_timeSpawnObj <= 0)
    {
        Spawn_SecondEnemy();
        Second_timeSpawnObj = Random.Range(3f, 5f);
    }

    Third_timeSpawnObj -= Time.deltaTime;
    if(Third_timeSpawnObj <= 0)
    {
        Spawn_ThirdEnemy();
        Third_timeSpawnObj = Random.Range(4f, 7f);
    }

    
    Box_timeShield -= Time.deltaTime;
    if(Box_timeShield <= 0)
    {
        Spawn_Box_Shield();
        Box_timeShield = Random.Range(10f, 17f);
    }

    Box_timeSpeed -= Time.deltaTime;
    if(Box_timeSpeed <= 0)
    {
        Spawn_Box_Speed();
        Box_timeSpeed = Random.Range(10f, 17f);
    }

    Box_timeX2 -= Time.deltaTime;
    if(Box_timeX2 <= 0)
    {
        Spawn_Box_X2();
        Box_timeX2 = Random.Range(15f, 22f);
    }
}

public void Spawn_FirstEnemy() //спавн первого врага
{
Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
Instantiate(First_Enemy, pos, Quaternion.identity); // осуществляем появление объекта в заданных случайных позициях в диапазоне заданных координат
}

public void Spawn_SecondEnemy()  //спавн второго врага
{
Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
Instantiate(Second_Enemy, pos, Quaternion.identity); // осуществляем появление объекта в заданных случайных позициях в диапазоне заданных координат
}

public void Spawn_ThirdEnemy()  //спавн третьего врага
{
Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
Instantiate(Third_Enemy, pos, Quaternion.identity); // осуществляем появление объекта в заданных случайных позициях в диапазоне заданных координат
}

void OnDrawGizmosSelectes()
{
Gizmos.color = new Color(1, 0, 0, 0.5f);
Gizmos.DrawCube(transform.localPosition + center, size);
}


public void Spawn_Box_Shield()  //спавн коробки со щитом
{
Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
Instantiate(Box_Shield, pos, Quaternion.identity);    
}

public void Spawn_Box_Speed()  //спавн коробки скорости
{
Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
Instantiate(Box_Speed, pos, Quaternion.identity);    
}
public void Spawn_Box_X2()  //спавн коробки с бафом
{
Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
Instantiate(Box_X2, pos, Quaternion.identity);    
}
}
