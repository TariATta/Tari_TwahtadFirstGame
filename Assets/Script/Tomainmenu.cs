using UnityEngine;
using UnityEngine.SceneManagement;

public class Tomainmenu : MonoBehaviour
{
  public void playGame()
    {
        Debug.Log("BYE");
        SceneManager.LoadScene("mainmenu");
    }
}

