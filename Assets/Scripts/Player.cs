using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 mousePos;
    private Vector2 moveDirection;
    private Vector2 pos;
    private Vector2 direction;
    private float angle;
    private void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Initialize();
    }

    
    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector2(transform.position.x, transform.position.y);
        moveDirection = Vector2.Lerp(pos, mousePos, 0.04f);
        Vector2 direction = mousePos - pos;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerRotation();
    }



    private void PlayerMovement()
    {
        rb.MovePosition(moveDirection + rb.velocity * Time.deltaTime);
    }

    private void PlayerRotation()
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    
}
