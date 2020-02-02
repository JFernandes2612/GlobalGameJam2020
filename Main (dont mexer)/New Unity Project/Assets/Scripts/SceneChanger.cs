using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }

    public void Tutorial1()
    {
        SceneManager.LoadScene("Tutorial 1");
    }

    public void Tutorial2()
    {
        SceneManager.LoadScene("Tutorial 2");
    }

    public void Tutorial3()
    {
        SceneManager.LoadScene("Tutorial 3");
    }

    public void Tutorial4()
    {
        SceneManager.LoadScene("Tutorial 4");
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
