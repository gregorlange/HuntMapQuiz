using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnClickLoadStillwater()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickLoadLawson()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClickLoadDeSalle()
    {
        SceneManager.LoadScene(3);
    }
}
