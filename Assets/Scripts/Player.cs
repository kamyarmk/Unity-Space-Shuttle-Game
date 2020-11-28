using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public float bulletSpeed = 20.0f;
    public float LimitLeft = -4.0f;
    public float LimitRight = 4.0f;
    public GameObject ammoObject;
    List<GameObject> ammoObjectList;
    Vector3 movement;
    Vector3 ammoSpeed;
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ammoObjectList = new List<GameObject>();

        for(int i =0; i < 10; i++)
        {
            ammoObjectList.Add((GameObject)Instantiate(ammoObject, transform.position, Quaternion.identity));
        }
        foreach(GameObject Ammo in ammoObjectList)
        {
            Ammo.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.Normalize();
        rb2d.velocity = movement * speed;

        
        if (transform.position.x > LimitRight)
        {
            transform.position = new Vector3(LimitLeft, -4.3f, 0);
        }else if(transform.position.x < LimitLeft)
        {
            transform.position = new Vector3(LimitRight, -4.3f, 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
        }

        if (Input.GetKeyDown("space"))
        {
            ammoShoot();   
        }
        StartCoroutine("ammoController", 0.01f);
    }

    void ammoShoot()
    {
        foreach (GameObject ammoOBJ in ammoObjectList)
        {
            Debug.Log("Ammo " + ammoOBJ.activeSelf);
            if (!(ammoOBJ.activeSelf))
            {
                ammoOBJ.SetActive(true);
                Rigidbody2D ammo = ammoOBJ.GetComponent<Rigidbody2D>();
                ammoOBJ.transform.position = new Vector3(transform.position.x, -3.3f);
                ammo.velocity = ammoObject.transform.TransformDirection(new Vector3(0, bulletSpeed, 0));
                break;
            }
            else
            {
                
            }
        }
        return;
    }
    IEnumerator ammoController(float time = 0.1f)
    {
        foreach(GameObject ammoOBJ in ammoObjectList)
        {
            if (ammoOBJ.activeSelf)
            {
                if(ammoOBJ.transform.position.y > 5)
                {
                    ammoOBJ.SetActive(false);
                    ammoOBJ.transform.position = new Vector3(transform.position.x, -3.3f);
                }
            }
            else
            {
                Debug.Log("Ammo Controller" + ammoOBJ.activeSelf);
            }
        }
        yield return new WaitForSeconds(time);
    }
    
}
