using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class moveObject : MonoBehaviour
{
    public Vector3 movePosition;
    public float moveSeed;
    [SerializeField] [Range(0,1)] float moveProgress;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveProgress = Mathf.PingPong(Time.time * moveSeed,1);

        Vector3 offset = movePosition * moveProgress;
        transform.position = startPosition + offset;
    }
}
