using UnityEngine;
using UnityEngine.SceneManagement;

public class muSicBg : MonoBehaviour
{
    public static muSicBg instance;
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (instance != null)
        { Destroy(gameObject); }

        else if (currentScene.name == "MyGameScene")
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Funtime")
        {
            Destroy(gameObject);
        }
    }
}

