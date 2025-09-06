using UnityEngine;
using UnityEngine.InputSystem;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool bathDoor = false;
        [SerializeField] private bool bathKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (bathDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

        }
        public void ObjectInteraction()
        {
            if (bathDoor)
            {
                doorObject.PlayAnimation();
            }

            else if (bathKey)
            {
                _keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
            }
        }

    }
}