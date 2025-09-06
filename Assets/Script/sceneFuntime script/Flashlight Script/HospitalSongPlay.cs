using UnityEngine;

public class HospitalSongPlay : MonoBehaviour
{
    public GameObject RoomObject;
    public AudioSource HospitalSong;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HospitalSong.Play();
        }

    }

}
