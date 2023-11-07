using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gameManager;//can i�in gammanagera eri�cez
    float speed = 500f;
    bool top = false;
    [SerializeField]
    Transform ballHolder;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager=Object.FindObjectOfType<GameManager>();//GameManager� �ekek
    }
    void Update()
    {
        if (gameManager.gameOver)
            return;//can 0 olunca return d�ncek ve alttakiler �al��maz

        if (top == false) //space bas�nca oyun ba�lar
        {
            transform.position = ballHolder.position;
        }
        if (Input.GetButtonDown("Jump") && top == false)
        {
            top = true;//bu if'e ve yukar�daki if'e s�rekli girmesin diye true yapacaz
            rb.AddForce(Vector2.up * speed); //space bas�nca y de bir kuvvet uygulancak
        }
    }
    private void OnTriggerEnter2D(Collider2D target) //2D i�in yapmay� unutma
    {
        if (target.tag=="Buttom")
        {
            rb.velocity = Vector2.zero; //h�z� 0 olcak
            gameManager.UptadeLives(-1);//top a��a deyince can 1 azal�r
            top = false;
        }
    }
}
