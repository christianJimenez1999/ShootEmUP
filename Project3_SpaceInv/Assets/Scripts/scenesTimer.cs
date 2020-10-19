using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenesTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Invoke("backToStart", 5);   
    }


    void backToStart()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

}
