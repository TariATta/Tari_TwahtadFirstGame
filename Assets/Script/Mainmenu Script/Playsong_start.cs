using UnityEngine;

public class Playsong_start : MonoBehaviour
{
    [SerializeField] private AudioSource musicFile1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicFile1.Play();
    }
}
