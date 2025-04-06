using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void ScrStart()
    {
        SceneManager.LoadScene("Test");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
