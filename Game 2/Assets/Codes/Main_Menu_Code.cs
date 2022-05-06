using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Code : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
       //PlayerPrefs.DeleteAll();
    }
    public void GotoGame()
    {
        StartCoroutine(GotoGame_Animation());
    }

    IEnumerator GotoGame_Animation()
    {

        animator.SetTrigger("Play Trigger");
        yield return new WaitForSeconds(1);
        if(0==PlayerPrefs.GetInt("Level"))
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level")+1);
        else
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));

    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("hellow");
    }
}
