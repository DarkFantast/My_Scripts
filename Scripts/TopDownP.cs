using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownP : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        Rotation();
    }

    //перемещение
    private void Movement()
    {
        //сохранение текущих координат
        Vector3 currentPosition = transform.position;

        //добавление к ним ввода осей
        currentPosition.x = Input.GetAxis("Horizontal") * speed;
        currentPosition.y = Input.GetAxis("Vertical") * speed;

        //изменяем позицию на новую
        transform.position += currentPosition;
    }

    //вращение
    private void Rotation()
    {
        //определение позиции курсора
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //вращение на курсора
        float angle = 0;
        Vector3 relative = transform.InverseTransformPoint(currentPosition);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);
    }
}
