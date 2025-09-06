using UnityEngine;

namespace FlashLightBindingDoor
{
    public class FlashlightInventory : MonoBehaviour
    {
        public GameObject YouGotAFlashLight;
        public bool hasFlashLight = false;
        public bool DoOnce = false;
        public bool DoSoundOnce = false;

        public AudioSource pickUpSound;

        void Start()
        {
            YouGotAFlashLight.SetActive(false);
            if (pickUpSound == null)
            {
                pickUpSound = GetComponent<AudioSource>();
            }
        }

        void Update()
        {
            
            if (hasFlashLight == true)
            {
                if (DoOnce == false)
                {
                    YouGotAFlashLight.SetActive(true);
                    DoOnce = true;
                }

                if (DoOnce == true)
                {
                    if (DoSoundOnce == false)
                    {
                        pickUpSound.Play();
                        DoSoundOnce = true;
                    }
                    Invoke(nameof(YouGotFlashlightKey), 3);
                }
            }
            
            
        }

        void YouGotFlashlightKey()
        {
            YouGotAFlashLight.SetActive(false);
        }


    }
}