using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadlv : MonoBehaviour
{

    public int score;
    public Text scoretext;
    public float time;
    public Text timetext;

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Recreation");
    }

    public void LoadLevelTwo()
    {
        
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
