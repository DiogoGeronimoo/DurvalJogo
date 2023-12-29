using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int health = 3;
    public float speed;
    public float jumpForce;
    public GameObject Brow;
    public Transform firePoint;
    public bool isJumping;
    public bool doubleJump;
    

    private bool isFire;
    private Rigidbody2D rig;
    private Animator anim;
    private float moviment;
    private Vector3 respawnPoint; 

    public GameObject atkCollider;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //atkCollider.SetActive(false);
  //      GameControler.instance.UpdateLives(health);
        respawnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
     
    }

     void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // se nao precionar nada o valor e 0.se precionar Direita, valor e 1. Esquerda valor minimo -1.
        float moviment = Input.GetAxis("Horizontal");
        
        // adiciona velocidade ao corpo do personagem no eixo x e y
        rig.velocity = new Vector2(moviment * speed, rig.velocity.y);
        
        //andando pra direita
        if (moviment > 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        //andando pra esquerda
        else if (moviment < 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            } 
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (moviment == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("transition", 0);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if (doubleJump)
                {
                    anim.Play("Idle");
                    anim.Play("jump");
                   // anim.SetInteger("transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("colisao");
        if (col.gameObject.layer == 8)
        {
            isJumping = false;

        }
        
    }
}