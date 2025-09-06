using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{   // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Funtime")
        {
            muSicBg.instance.GetComponent<AudioSource>().Pause();
        }
    }
}
