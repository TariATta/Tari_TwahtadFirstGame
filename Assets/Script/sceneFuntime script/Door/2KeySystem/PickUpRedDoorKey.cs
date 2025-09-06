using UnityEngine;

namespace Keyof2Systen
{
    public class PickUpRedDoorKey : MonoBehaviour
    {
        public GameObject PickUpRedKeyText;
        public GameObject RedKeyOnPlayer;

        [SerializeField] private Keysof2Inventory _keyof2Inventory;

        void Start()
        {
            RedKeyOnPlayer.SetActive(false);
            PickUpRedKeyText.SetActive(false);
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PickUpRedKeyText.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    this.gameObject.SetActive(false);

                    RedKeyOnPlayer.SetActive(true);
                    PickUpRedKeyText.SetActive(false);

                    _keyof2Inventory.hasARedKey = true;
                    Debug.Log("Has Flashlight");
                }
            }
        }


        void OnTriggerExit(Collider other)
        {
            PickUpRedKeyText.SetActive(false);
        }

    }
}