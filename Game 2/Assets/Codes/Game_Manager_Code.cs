using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_Manager_Code : MonoBehaviour
{
    GameObject Main_Circle;
    GameObject Rotate_Circle;
    GameObject Sub_Main_Circle_0;
    GameObject Sub_Main_Circle_1;
    public Animator animator;
    public TextMeshProUGUI Rotate_Circle_Level;
    public TextMeshProUGUI Dart_Number_0;
    public TextMeshProUGUI Dart_Number_1;
    public TextMeshProUGUI Dart_Number_2;
    public int Dart_Number;
    bool Control=true;
    void Start()
    {
        PlayerPrefs.SetInt("Level",int.Parse(SceneManager.GetActiveScene().name));

       Main_Circle = GameObject.FindGameObjectWithTag("Main_Circle_Tag");
       Rotate_Circle = GameObject.FindGameObjectWithTag("Rotate_Circle_Tag");
       Sub_Main_Circle_0 = GameObject.FindGameObjectWithTag("Sub_Main_Circle_0_Tag");
       Sub_Main_Circle_1 = GameObject.FindGameObjectWithTag("Sub_Main_Circle_1_Tag");


        Rotate_Circle_Level.text = SceneManager.GetActiveScene().name;
       switch (Dart_Number)
       {
            case < 2:
                Dart_Number_0.text = Dart_Number.ToString();
                Sub_Main_Circle_0.SetActive(false);
                Sub_Main_Circle_1.SetActive(false);
                Dart_Number_1.text = "";
                Dart_Number_2.text = "";
                break;
            case < 3:
                Dart_Number_0.text = Dart_Number.ToString();
                Dart_Number_1.text = (Dart_Number - 1).ToString();
                Dart_Number_2.text = "";
                Sub_Main_Circle_1.SetActive(false);
                break;
            default:
                Dart_Number_0.text = Dart_Number.ToString();
                Dart_Number_1.text = (Dart_Number - 1).ToString();
                Dart_Number_2.text = (Dart_Number - 2).ToString();
                break;
       }



    }

    public void Little_Circle_Text()
    {
        Dart_Number--;
        if (Dart_Number < 2)
        {
            Dart_Number_0.text = Dart_Number.ToString();
            Sub_Main_Circle_0.SetActive(false);
            Sub_Main_Circle_1.SetActive(false);
            Dart_Number_1.text = "";
            Dart_Number_2.text = "";
        }
        else if (Dart_Number < 3)
        {
            Dart_Number_0.text = Dart_Number.ToString();
            Dart_Number_1.text = (Dart_Number - 1).ToString();
            Sub_Main_Circle_1.SetActive(false);
            Dart_Number_2.text = "";
        }
        else
        {
            Dart_Number_0.text = Dart_Number.ToString();
            Dart_Number_1.text = (Dart_Number - 1).ToString();
            Dart_Number_2.text = (Dart_Number - 2).ToString();
        }

        if(Dart_Number==0)
        {
            StartCoroutine(NewLevel());
        }
    }

    IEnumerator NewLevel()
    {
        Main_Circle.GetComponent<Main_Circle_Code>().enabled = false;
        Rotate_Circle.GetComponent<Rotate_Code>().enabled = false;
        yield return new WaitForSeconds(1);
        if (Control)
        {
            animator.SetTrigger("New_Level");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
    }

    public void GameOver()
    {StartCoroutine(GameOver_Called());}

     IEnumerator GameOver_Called()
    {
       Main_Circle.GetComponent<Main_Circle_Code>().enabled = false;
       Rotate_Circle.GetComponent<Rotate_Code>().enabled = false;
       animator.SetTrigger("Game_Finished");
       Control = false;
       yield return new WaitForSeconds(1);
       SceneManager.LoadScene("Main Menu");
       
    }

}
