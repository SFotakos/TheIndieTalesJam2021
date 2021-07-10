using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 300f;
    float horizontalInput;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            if (Mathf.Abs(mousePos2D.magnitude - transform.position.magnitude) < 3f)
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalInput * playerSpeed * Time.fixedDeltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Table"))
        {
            if (collision.gameObject.name.IndexOf("Left", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Debug.Log("Enable Push Left");
            } else
            {
                Debug.Log("Enable Push Right");
            }
        }
    }
}
