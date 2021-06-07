using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outro : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
