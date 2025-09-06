using UnityEngine;
using UnityEngine.Video;

public class videoPickplayer : MonoBehaviour
{
    [SerializeField] VideoPlayer rickR;
    [SerializeField] AudioSource rickRsound;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
                rickR.Play();
                rickRsound.Play();
                
            
            
        }

    }

    void OnCollisionExit(Collision other)
    {
        rickR.Stop();
        rickRsound.Stop();
    }
}
