using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables publiques
    public float speed;

    //Variables relatives aux mouvements
    Rigidbody2D rb;
    Vector2 movement;

    //Variables relatives aux inputs
    float horizontal;
    float vertical;
    Vector2 movementInput;

    void Awake()
    {
        //Récupération du rigibody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Récupération des inputs
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //"Programmation" du déplacement voulu en fonction des inputs
        movement = new Vector2(horizontal, vertical).normalized * speed;
    }

    private void FixedUpdate()
    {
        //Déplacement de l'objet
        rb.MovePosition(rb.position + movement * Time.deltaTime);
    }
}
