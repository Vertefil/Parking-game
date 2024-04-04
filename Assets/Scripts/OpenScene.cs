using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public void OpenNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
