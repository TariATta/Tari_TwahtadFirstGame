using UnityEngine;

public class FlashLightOffInRoom : MonoBehaviour
{
    public GameObject RoomObject;
    public GameObject FlashlightLight;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlashlightLight.SetActive(false);
        }

    }

    void OnTriggerExit(Collider other)
    {
        FlashlightLight.SetActive(true);
    }
}
