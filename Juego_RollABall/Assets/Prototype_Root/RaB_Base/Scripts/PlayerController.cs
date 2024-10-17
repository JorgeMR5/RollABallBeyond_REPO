using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Public References")]
    public Rigidbody playerRb; //Variable para referenciar el Rigidbody del jugador, y as� modificarlo cuando quiera por c�digo

    [Header("Movement Variables")]
    public float speed;
    private float horInput; //Almac�n del vector X del input
    private float verInput; //Almac�n del vector y del input (se lo pasar� al eje z)

    [Header("Jump Variables")]
    public float jumpForce;
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Conectar las variables float al input de teclado
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Movement()
    {
        //Velocidad del rigidbody = Vector3 (movimiento en X, constante Y, movimiento en Z)
        playerRb.velocity = new Vector3(horInput * speed, playerRb.velocity.y, verInput * speed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                isGrounded = false;
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
