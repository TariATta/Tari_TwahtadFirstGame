using UnityEngine;

namespace Keyof2Systen
{
    public class RedKeyBindingCollider : MonoBehaviour
    {
        public GameObject NoRedKeyText;
        public GameObject OpenDoorText;
        public Transform Player;

        [SerializeField] private Keysof2Inventory _keyof2Inventory;

        void Start()
        {
            NoRedKeyText.SetActive(false);
            OpenDoorText.SetActive(false);
        }
        void OnTriggerStay(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                if (_keyof2Inventory.hasARedKey == false)
                {
                    NoRedKeyText.SetActive(true);
                }
            }
        }

        void OnMouseOver()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 3)
                    if (_keyof2Inventory.hasARedKey == true)
                    {
                        OpenDoorText.SetActive(true);
                    }
                if (dist >= 3)
                    if (_keyof2Inventory.hasARedKey == true)
                    {
                        OpenDoorText.SetActive(false);
                    }
            }
        }

        void OnTriggerExit(Collider other)
        {
            NoRedKeyText.SetActive(false);
            OpenDoorText.SetActive(false);
        }

        void OnMouseExit()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist >= 3)
                    if (_keyof2Inventory.hasARedKey == true)
                    {
                        OpenDoorText.SetActive(false);
                    }
            }
        }
    }
}