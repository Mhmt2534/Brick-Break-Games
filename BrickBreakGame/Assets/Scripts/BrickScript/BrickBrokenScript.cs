using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBrokenScript : MonoBehaviour
{
    [SerializeField]
    private Sprite brickBroken;
    [SerializeField]
    GameObject brickBrokenEffect1,brickBrokenEffect2;
    [SerializeField]
    GameObject[] pUp; //Özel Güçler
    GameManager gameManager;
    int count;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void Start()
    {
         count = 0;
    }
   private void OnCollisionEnter2D(Collision2D target)
    {
        int luck = Random.Range(1, 101);
        int Power = Random.Range(0, pUp.Length);
        if (target.gameObject.tag=="Ball")
        {
            count++;
            if (count==1)
            {
                GetComponent<SpriteRenderer>().sprite=brickBroken;
                Instantiate(brickBrokenEffect1, transform.position, Quaternion.identity);
                gameManager.Sounds();
            }
            else if(count==2)
            {
                Destroy(gameObject);
                gameManager.Sounds();
                if (luck>50)
                {
                    Instantiate(pUp[Power], transform.position, Quaternion.identity);
                }
                Instantiate(brickBrokenEffect2,transform.position,Quaternion.identity);
                gameManager.UptadeScore(10); //Skor 10 artar
            }
        }
    }
}
