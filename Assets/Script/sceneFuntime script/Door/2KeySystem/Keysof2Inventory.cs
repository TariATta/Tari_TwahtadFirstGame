using System.Collections;
using UnityEngine;

namespace Keyof2Systen
{
    public class Keysof2Inventory : MonoBehaviour
    {
        public bool hasToiletKey = false;
        public bool hasARedKey = false;
        public GameObject YouGotToiletKey;
        public GameObject YouGotARedKey;

        public AudioSource KeySoundfx;
        public AudioSource PickupSound;

        public bool DoOnce1 = false;
        public bool DoOnce1Sound = false;
        public bool DoOnce2 = false;
        public bool DoOnce2Sound = false;

        void Start()
        {
            YouGotToiletKey.SetActive(false);
            YouGotARedKey.SetActive(false);
            if (KeySoundfx == null)
            {
                KeySoundfx = GetComponent<AudioSource>();
            }

            if (PickupSound == null)
            {
                PickupSound = GetComponent<AudioSource>();
            }
        }

        void Update()
        {
            if (hasToiletKey == true)
            {
                if (DoOnce1 == false)
                {
                    YouGotToiletKey.SetActive(true);
                    DoOnce1 = true;
                }

                if (DoOnce1 == true)
                {
                    if (DoOnce1Sound == false)
                    {
                        PickupSound.Play();
                        KeySoundfx.Play();
                        DoOnce1Sound = true;
                    }
                    Invoke(nameof(YouGotToiKey), 3);
                }
            }
            if (hasARedKey == true)
            {
                if (DoOnce2 == false)
                {
                    YouGotARedKey.SetActive(true);
                    DoOnce2 = true;
                }

                if (DoOnce2 == true)
                {
                    if (DoOnce2Sound == false)
                    {
                        PickupSound.Play();
                        KeySoundfx.Play();
                        DoOnce2Sound = true;
                    }
                    Invoke(nameof(YouGotRedKey), 3);
                }
            }
        }

        void YouGotToiKey()
        {
            YouGotToiletKey.SetActive(false);
        }

        void YouGotRedKey()
        {
            YouGotARedKey.SetActive(false);
        }
    }

}