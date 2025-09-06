using System.Collections;
using System.Collections.Generic;
using Keyof2Systen;
using UnityEngine;
using UnityEngine.UI;

namespace KeypadSystem
{
    namespace Keyof2Systen
    {
        public class DoorKeyPadBinding : MonoBehaviour
        {
            public GameObject OpenDoorText;
            public GameObject DontKnowPassword;
            public Transform Player;
            public GameObject FlashLightCollider;


            [SerializeField] KeypadInventory _keypadInventory;
            [SerializeField] RedDoorOpenClose _redDoorOpenClose;

            void Start()
            {
                OpenDoorText.SetActive(false);
                DontKnowPassword.SetActive(false);
            }

            void OnTriggerStay(Collider other)
        {

                if (other.gameObject.tag == "Player")
                {
                    if (_redDoorOpenClose.doOnceReddoor == false)
                    {
                        FlashLightCollider.GetComponent<BoxCollider>().enabled = false;
                        DontKnowPassword.SetActive(true);
                    }

                    if (_redDoorOpenClose.doOnceReddoor == true)
                    {
                        FlashLightCollider.GetComponent<BoxCollider>().enabled = true;
                    }
            }
        }
            void OnMouseOver()
            {
                if (Player)
                {
                    if (_redDoorOpenClose.doOnceReddoor == true)
                    {
                        float dist = Vector3.Distance(Player.position, transform.position);
                        if (dist < 3)
                            if (_keypadInventory.hasKeypadOn == true)
                            {
                                OpenDoorText.SetActive(true);
                            }
                    }
                }
            }

            void OnTriggerExit(Collider other)
            {
                OpenDoorText.SetActive(false);
                DontKnowPassword.SetActive(false);
            }

            void OnMouseExit()
            {
                if (Player)
                {
                    float dist = Vector3.Distance(Player.position, transform.position);
                    if (dist >= 3)
                        if (_keypadInventory.hasKeypadOn == true)
                        {
                            OpenDoorText.SetActive(false);
                        }
                }
            }


        }
    }
}