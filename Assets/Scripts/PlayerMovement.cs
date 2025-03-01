using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector3.up * speed);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(Vector3.down * speed);
    }
}
