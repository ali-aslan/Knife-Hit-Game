using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate_Code : MonoBehaviour
{
    // Start is called before the first frame update
    int Speed;
    void Start()
    {
        if (1 == int.Parse(SceneManager.GetActiveScene().name))
            Speed = 100;
        else if (2 == int.Parse(SceneManager.GetActiveScene().name))
            Speed = 150;
        else if (3 == int.Parse(SceneManager.GetActiveScene().name))
            Speed = 200;



    }
    
    
    void Update()
    {
        transform.Rotate(0, 0,Speed*Time.deltaTime);
    }
}
