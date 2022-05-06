using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Little_Circle_Code : MonoBehaviour
{
    Rigidbody2D Physics;
    float Speed=10;
    bool Direction=true;
    public GameObject Game_Manager;
    void Start()
    {
        Physics = GetComponent<Rigidbody2D>();
        Game_Manager = GameObject.FindGameObjectWithTag("Game_Manager_Tag");
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Direction == true)
            Physics.MovePosition(Physics.position + Vector2.up * Time.fixedDeltaTime * Speed);
     
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rotate_Circle_Tag")
        {
            Direction = false;
            transform.SetParent(collision.transform);
        }
        if (collision.tag=="Dart_Tag")
        {
            Game_Manager.GetComponent<Game_Manager_Code>().GameOver();

        }
            
       
            
    }
}
