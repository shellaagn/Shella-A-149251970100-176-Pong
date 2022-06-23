using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenAuthor()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickPlay()
    {
        Debug.Log("Created by Shella A-149251970100-176.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
