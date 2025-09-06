using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Keyof2Systen
{
    public class ToiDoorOpenClose : MonoBehaviour
    {
        public Animator openandclose;
        public bool open;
        public Transform Player;
        public GameObject ToiKeyOnPlayer;
        public AudioSource OpendoorSound;
        public AudioSource ClosedoorSound;

        [SerializeField] private Keysof2Inventory _keyof2Inventory;

        void Start()
        {
            open = false;
        }

        void OnMouseOver()
        {

            if (Player)
            {

                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 3)
                {
                    if (_keyof2Inventory.hasToiletKey == true)
                    {
                        if (open == false)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                ToiKeyOnPlayer.SetActive(false);
                                StartCoroutine(opening());
                                OpendoorSound.Play();

                            }
                        }
                        else
                        {
                            if (open == true)
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    StartCoroutine(closing());
                                    ClosedoorSound.Play();
                                }
                            }

                        }
                    }

                }


            }

        }


        IEnumerator opening()
        {
            print("you are opening the door");
            openandclose.Play("Opening");
            open = true;
            _keyof2Inventory.hasToiletKey = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the door");
            openandclose.Play("Closing");
            open = false;
            _keyof2Inventory.hasToiletKey = true;
            yield return new WaitForSeconds(.5f);
        }

    }
}