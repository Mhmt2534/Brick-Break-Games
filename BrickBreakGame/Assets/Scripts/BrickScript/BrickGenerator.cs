using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] bricks;

    float ustIncrease = 1.5f, yanIncrease = 1.5f; //saða  ve yukarý doðru artýrma miktarý
    float altBound = 1, ustBound = 4; //alt ve üst sýnýr
    float yandBound = 6.5f; //sað ve sol sýnýrlar

    private void Start()
    {
        //sað 6.5 sol -6.5   1.5 arttýr
        //alt 1 üst 4   1.5 arttýr
        int randomBricks;//radom tuðla
        
        for (float i = altBound; i <= ustBound; i+=ustIncrease) //Alt ve üst sýnýrlar
        {
             
            for (float j = -yandBound; j <=yandBound ; j+=yanIncrease) //sað ve sol sýnýrlar
            {
                randomBricks = Random.Range(0, 2);
                Vector2 dnm=new Vector2(j,i);//x için j ve j herseferinde 1.5 artar , y içinde i ve i 1.5 artar
                Instantiate(bricks[randomBricks], dnm, Quaternion.identity);//tuðla oluþtur
            }

        }


    }



}
