using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField]
    GameObject brickEffect;
    [SerializeField]
    GameObject[] pUp; //�zel G��ler
    GameManager gameManager;
    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        int luck = Random.Range(1, 101); //can d��mesi i�in
        int Power = Random.Range(0, pUp.Length);//g��ler
        //Top Tu�laya �arp�nca yok olur
        if (target.gameObject.tag=="Ball")
        {
            Destroy(gameObject);
            //%30 �ansla can d��s�n
            if (luck>50)
            {
                Instantiate(pUp[Power], transform.position, Quaternion.identity);
            }
            gameManager.Sounds();

            Instantiate(brickEffect,transform.position,Quaternion.identity);

            gameManager.UptadeScore(5); //mavi t��laya �arp�nca skor 5 artar , GameManager scritptine bak
        }
    }
}
