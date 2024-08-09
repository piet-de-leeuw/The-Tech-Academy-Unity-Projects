using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGameOver : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void Update()
    {
        if (transform.position.y >= 8.5f) { return; }
        transform.position += new Vector3(0f, Time.deltaTime * speed, 0f);
    }

}
