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
        MoveCube();
        OutOfBoundsDetection();
    }

    public string PrintingFromOutsite(int value)
    {
        string stringFromOutsite = "Hello from the other site " + value;
        Debug.LogWarning(stringFromOutsite);
        return stringFromOutsite;
    }

    private void OutOfBoundsDetection()
    {
        if (transform.position.y >= 5.5f)
        {
            Debug.Log("Out of bounts up");
        }
        else if (transform.position.y <= -5.5f)
        {
            Debug.Log("Out of bounts down");
        }
        else if (transform.position.x >= 9.5f)
        {
            Debug.Log("Out of bounts right");
        }
        else if (transform.position.x <= -9.5f)
        {
            Debug.Log("Out of bounts left");
        }
    }

    private void MoveCube()
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
