using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bボタンを押したらスタート
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("GameDestroyCity");
        }
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}
