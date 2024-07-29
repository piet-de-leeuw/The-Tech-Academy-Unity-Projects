using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    [SerializeField] Vector2 forceUpDown = new Vector2(0, 10);
    [SerializeField] Vector2 forceLeftRight = new Vector2(10, 0);

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody2D.velocity = forceUpDown;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidbody2D.velocity = -forceUpDown;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidbody2D.velocity = forceLeftRight;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidbody2D.velocity = -forceLeftRight;
        }
    }
}
