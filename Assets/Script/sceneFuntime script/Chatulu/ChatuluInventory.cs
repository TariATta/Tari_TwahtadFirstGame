using UnityEngine;

namespace ChatuluSystem2
{
    public class ChatuluInventory : MonoBehaviour
    {
        public bool hasChatulu = false;

        public AudioSource pickUpChatuluSound;
        public GameObject YouGotChatulu;
        [SerializeField] ChatuluStatue _chtuluStatue;
        [SerializeField] bool DoOnceChatulu = false;
        [SerializeField] bool DoOnceChatulutext = false;
        public bool alredy_Have = false;


        void Start()
        {
            YouGotChatulu.SetActive(false);
            YouGotChatulu.SetActive(false);
            if (pickUpChatuluSound == null)
            {
                pickUpChatuluSound = GetComponent<AudioSource>();
            }
        }

        void Update()
        {
            if (hasChatulu == true)
            {
                if (DoOnceChatulu == false)
                {
                    YouGotChatulu.SetActive(true);
                    DoOnceChatulu = true;
                }

                if (DoOnceChatulu == true)
                {
                    if (DoOnceChatulutext == false)
                    {
                        alredy_Have = true;
                        pickUpChatuluSound.Play();
                        DoOnceChatulutext = true;
                    }
                    Invoke(nameof(YoouGotChatu), 3);
                }
            }
        }
        
        void YoouGotChatu()
        {
            YouGotChatulu.SetActive(false);
        }

    }
}
