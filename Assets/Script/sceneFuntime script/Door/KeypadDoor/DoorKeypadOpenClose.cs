using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace KeypadSystem
{
    public class DoorKeypadOpenClose : MonoBehaviour
    {
        public Animator openandclose;
        public bool open;
        public Transform Player;
        public AudioSource OpendoorSound;
        public AudioSource ClosedoorSound;

        [SerializeField] private KeypadInventory _keyPadInventory;

        void Start()
        {
            if (OpendoorSound == null || ClosedoorSound == null)
            {
                OpendoorSound = GetComponent<AudioSource>();
                ClosedoorSound = GetComponent<AudioSource>();
            }
        }
        void OnMouseOver()
        {
            {
                if (Player)
                {
                    float dist = Vector3.Distance(Player.position, transform.position);
                    if (dist < 3)
                    {
                        if (_keyPadInventory.hasKeypadOn == true)
                        {
                            if (open == false)
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
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

        }

        IEnumerator opening()
        {
            print("you are opening the door");
            openandclose.Play("Opening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the door");
            openandclose.Play("Closing");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}