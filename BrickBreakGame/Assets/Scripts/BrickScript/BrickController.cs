using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField]
    GameObject brickEffect;
    [SerializeField]
    GameObject[] pUp; //Özel Güçler
    GameManager gameManager;
    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        int luck = Random.Range(1, 101); //can düþmesi için
        int Power = Random.Range(0, pUp.Length);//güçler
        //Top Tuðlaya çarpýnca yok olur
        if (target.gameObject.tag=="Ball")
        {
            Destroy(gameObject);
            //%30 þansla can düþsün
            if (luck>50)
            {
                Instantiate(pUp[Power], transform.position, Quaternion.identity);
            }
            gameManager.Sounds();

            Instantiate(brickEffect,transform.position,Quaternion.identity);

            gameManager.UptadeScore(5); //mavi týðlaya çarpýnca skor 5 artar , GameManager scritptine bak
        }
    }
}
