using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Cube cube;
    [SerializeField] int stringValue = 12;

    // Start is called before the first frame update
    void Start()
    {
        cube = FindObjectOfType<Cube>();
        Debug.Log(cube.PrintingFromOutsite(stringValue));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
