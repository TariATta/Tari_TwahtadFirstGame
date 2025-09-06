using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTHE3rdscene : MonoBehaviour
{
    [SerializeField] GameObject rawImageBlack;

    void Start()
    {
        rawImageBlack.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rawImageBlack.SetActive(true);
            SceneManager.LoadScene("Funtime");
        }
    }
}
