using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //-7.6 ve 7.6 aras�
    float horizontal;
    [SerializeField]
    float speed = 20, Target = 7.6f;
    //target = s�n�r
    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (gameManager.gameOver)
            return;//can 0 olunca a��adakiler �al��maz
        //Hareket
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);
        //S�n�rland�rma
        float xPos = Mathf.Clamp(transform.position.x, -Target, Target);
        transform.position = new Vector2(xPos, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="LiveUp")
        {
            gameManager.UptadeLives(1);
            Destroy(other.gameObject);
            gameManager.PowerSound();
        }
        if (other.tag == "ScoreUp")
        {
            gameManager.UptadeScore(10);
            Destroy(other.gameObject);
            gameManager.PowerSound();
        }
    }
}
