using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Enemy : MonoBehaviour
{
    public float Speed = -3.0f;
    Vector3 Movement;
    Rigidbody2D Rb2d;

    // Start is called before the first frame update
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement.y = 2 - Time.fixedDeltaTime;

        Movement.Normalize();

        Rb2d.velocity = Movement * Speed;
    }
}
