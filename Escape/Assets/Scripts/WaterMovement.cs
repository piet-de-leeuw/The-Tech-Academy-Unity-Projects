using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.position += new Vector3 (0f, Time.deltaTime * speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SceneManager.LoadScene("Game Over");
    }
}
