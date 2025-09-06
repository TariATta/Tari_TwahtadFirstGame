using System.Collections;
using UnityEngine;

namespace FlashLightBindingDoor
{

public class PickUpFlashLight : MonoBehaviour
{
    public GameObject PickUpFlashLightText;
    public GameObject FlashLightOnPlayer;
    


    [SerializeField] private FlashlightInventory _flashlightInventory;

    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
        PickUpFlashLightText.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpFlashLightText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                    this.gameObject.SetActive(false);

                    
                    FlashLightOnPlayer.SetActive(true);
                    PickUpFlashLightText.SetActive(false);

                    _flashlightInventory.hasFlashLight = true;
                    Debug.Log("Has Flashlight");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        PickUpFlashLightText.SetActive(false);
    }


}
}