using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] bricks;

    float ustIncrease = 1.5f, yanIncrease = 1.5f; //sa�a  ve yukar� do�ru art�rma miktar�
    float altBound = 1, ustBound = 4; //alt ve �st s�n�r
    float yandBound = 6.5f; //sa� ve sol s�n�rlar

    private void Start()
    {
        //sa� 6.5 sol -6.5   1.5 artt�r
        //alt 1 �st 4   1.5 artt�r
        int randomBricks;//radom tu�la
        
        for (float i = altBound; i <= ustBound; i+=ustIncrease) //Alt ve �st s�n�rlar
        {
             
            for (float j = -yandBound; j <=yandBound ; j+=yanIncrease) //sa� ve sol s�n�rlar
            {
                randomBricks = Random.Range(0, 2);
                Vector2 dnm=new Vector2(j,i);//x i�in j ve j herseferinde 1.5 artar , y i�inde i ve i 1.5 artar
                Instantiate(bricks[randomBricks], dnm, Quaternion.identity);//tu�la olu�tur
            }

        }


    }



}
