using UnityEngine;


namespace ChatuluSystem2{
    public class ChatuluStatue : MonoBehaviour
    {
        public GameObject PickUpText;
        public GameObject ChatuluOnPlayer;
        public GameObject ChatuluOutside;
        public GameObject EndProp;

        [SerializeField] private ChatuluInventory _chatuluInventory;


        void Start()
        {
            ChatuluOnPlayer.SetActive(false);
            PickUpText.SetActive(false);
            EndProp.SetActive(false);
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PickUpText.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    ChatuluOutside.SetActive(false);
                    _chatuluInventory.hasChatulu = true;
                    ChatuluOnPlayer.SetActive(true);
                    EndProp.SetActive(true);

                    PickUpText.SetActive(false);

                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            PickUpText.SetActive(false);
        }
    }
}