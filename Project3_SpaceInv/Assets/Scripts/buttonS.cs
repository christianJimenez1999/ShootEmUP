using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonS : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene(sceneName: "MainGame");
    }
}
