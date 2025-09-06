using UnityEngine;

public class TextHintInroom : MonoBehaviour
{
    [SerializeField] GameObject hintTextroom;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintTextroom.SetActive(true);
        }

    }
    
    void OnTriggerExit(Collider other)
    {
        hintTextroom.SetActive(false);
    }
}
