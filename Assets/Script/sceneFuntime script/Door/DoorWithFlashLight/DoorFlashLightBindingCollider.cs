using UnityEngine;

namespace FlashLightBindingDoor
{
    public class DoorFlashLightBindingCollider : MonoBehaviour
    {

        public GameObject NoFlashLightText;
        public GameObject OpenDoorText;
        public Transform Player;

        [SerializeField] private FlashlightInventory _flashlightInventory;

        void Start()
        {
            NoFlashLightText.SetActive(false);
            OpenDoorText.SetActive(false);
        }
        void OnTriggerStay(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                if (_flashlightInventory.hasFlashLight == false)
                {
                    NoFlashLightText.SetActive(true);
                }
                if (_flashlightInventory.hasFlashLight == true)
                {
                    OpenDoorText.SetActive(true);
                }
                    
            }
        }

        //void OnMouseOver()
        //{
        //    if (Player)
        //    {
        //        float dist = Vector3.Distance(Player.position, transform.position);
        //        if (dist < 3)
        //            if (_flashlightInventory.hasFlashLight == true)
        //            {
        //                OpenDoorText.SetActive(true);
        //            }
        //        if (dist >= 3)
        //            if (_flashlightInventory.hasFlashLight == true)
        //            {
        //                OpenDoorText.SetActive(false);
        //            }
        //    }
        //}

        void OnTriggerExit(Collider other)
        {
            NoFlashLightText.SetActive(false);
            OpenDoorText.SetActive(false);
        }

        //void OnMouseExit()
        //{
        //    if (Player)
        //    {
        //        float dist = Vector3.Distance(Player.position, transform.position);
        //        if (dist >= 3)
        //            if (_flashlightInventory.hasFlashLight == true)
        //            {
        //                OpenDoorText.SetActive(false);
        //            }
        //    }
        //}

    }
}