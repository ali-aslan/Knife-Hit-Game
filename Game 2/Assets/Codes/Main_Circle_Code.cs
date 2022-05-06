using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Circle_Code : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Little_Circle;
    GameObject Game_Manager;
    void Start()
    {
        Game_Manager = GameObject.FindGameObjectWithTag("Game_Manager_Tag");
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetButtonDown("Fire1")) 
    {
    Create_Little_Circle();
    }

    void Create_Little_Circle()
    {
    Instantiate(Little_Circle, transform.position, transform.rotation);
            Game_Manager.GetComponent<Game_Manager_Code>().Little_Circle_Text();
    }

    }
}
