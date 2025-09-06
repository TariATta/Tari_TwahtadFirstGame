using UnityEngine;

public class SecretTextTrigger : MonoBehaviour
{
    [SerializeField] GameObject SecretBathtubText;

    void Start()
    {
        SecretBathtubText.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SecretBathtubText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        SecretBathtubText.SetActive(false);
    }
}