using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUp : MonoBehaviour
{
    float speed = 2;
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
