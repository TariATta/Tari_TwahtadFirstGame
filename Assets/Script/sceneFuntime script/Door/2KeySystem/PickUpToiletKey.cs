using System.Collections;
using UnityEngine;

namespace Keyof2Systen
{
    public class PickUpToiletKey : MonoBehaviour
    {
        public GameObject PickUpToiKeyText;
        public GameObject ToiKeyOnPlayer;

        [SerializeField] private Keysof2Inventory _keyof2Inventory;

        void Start()
        {
            ToiKeyOnPlayer.SetActive(false);
            PickUpToiKeyText.SetActive(false);
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PickUpToiKeyText.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    this.gameObject.SetActive(false);

                    ToiKeyOnPlayer.SetActive(true);
                    PickUpToiKeyText.SetActive(false);

                    _keyof2Inventory.hasToiletKey = true;
                    Debug.Log("Has Flashlight");
                }
            }
        }


        void OnTriggerExit(Collider other)
        {
            PickUpToiKeyText.SetActive(false);
        }

    }
}