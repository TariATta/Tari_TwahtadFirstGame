using UnityEngine;

namespace ChatuluSystem2
{
    public class PutdownChatulu : MonoBehaviour
    {
        ChatuluStatue chatuluStatue;
        public GameObject PutdownText;
        public GameObject ChatuluOnPlayer;
        public GameObject ChatuluOnShelf;
        public GameObject ChatuluOutside;

        void Awake()
        {
            chatuluStatue = ChatuluOutside.GetComponent<ChatuluStatue>();
        }
        void Start()
        {
            ChatuluOnShelf.SetActive(false);
            PutdownText.SetActive(false);
        }

        void OnTriggerStay(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                if (ChatuluOutside == false)
                {
                    if (ChatuluOnPlayer == true)
                    {
                        PutdownText.SetActive(true);

                        if (Input.GetKey(KeyCode.E))
                        {
                            ChatuluOnShelf.SetActive(true);

                            ChatuluOnPlayer.SetActive(false);
                            PutdownText.SetActive(false);
                        }
                    }

                    else if (ChatuluOnShelf == true)
                    {
                        PutdownText.SetActive(false);
                    }
                    else if (ChatuluOnPlayer == true && ChatuluOutside == false)
                    {
                        PutdownText.SetActive(false);
                    }
                }

            }
        }

        void OnTriggerExit(Collider other)
        {
            PutdownText.SetActive(false);
        }
    }
}