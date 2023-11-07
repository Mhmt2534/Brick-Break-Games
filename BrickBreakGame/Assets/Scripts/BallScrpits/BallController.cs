using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gameManager;//can için gammanagera eriþcez
    float speed = 500f;
    bool top = false;
    [SerializeField]
    Transform ballHolder;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager=Object.FindObjectOfType<GameManager>();//GameManagerý Çekek
    }
    void Update()
    {
        if (gameManager.gameOver)
            return;//can 0 olunca return döncek ve alttakiler çalýþmaz

        if (top == false) //space basýnca oyun baþlar
        {
            transform.position = ballHolder.position;
        }
        if (Input.GetButtonDown("Jump") && top == false)
        {
            top = true;//bu if'e ve yukarýdaki if'e sürekli girmesin diye true yapacaz
            rb.AddForce(Vector2.up * speed); //space basýnca y de bir kuvvet uygulancak
        }
    }
    private void OnTriggerEnter2D(Collider2D target) //2D için yapmayý unutma
    {
        if (target.tag=="Buttom")
        {
            rb.velocity = Vector2.zero; //hýzý 0 olcak
            gameManager.UptadeLives(-1);//top aþþa deyince can 1 azalýr
            top = false;
        }
    }
}
