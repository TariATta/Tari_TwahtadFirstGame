using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void playGame()
    {
        Debug.Log("Hello!");
        SceneManager.LoadScene("Scene1");
    }
}
