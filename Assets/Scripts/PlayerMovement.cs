using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Ensure no gravity
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            move = 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            move = -1f;

        rb.velocity = new Vector2(0, move * speed); // Directly set velocity
    }
}
