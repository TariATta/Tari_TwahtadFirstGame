using System.Collections;
using System.Collections.Generic;
using Keyof2Systen;
using UnityEngine;
using UnityEngine.UI;

namespace KeypadSystem
{

    public class KeyPadInterract : MonoBehaviour
    {
        public AudioSource OpendoorSound;
        public AudioSource keypadSound;
        public AudioSource IncorrectSound;
        public AudioSource CorrectSound;
        public float minPitch = 0.8f;
        public float maxPitch = 1.2f;


        public GameObject safecode, numtext, incorrecttext, correcttext;
        public GameObject InterractKeyPadText;
        public GameObject KeyPadShow;
        public Text numTex;

        public playercontrol playerScript;
        public string codeString, correctCode;
        public int stringCharacters = 0;
        public bool interactable, safeactive;
        public Button but1, but2, but3, but4, but5, but6, but7, but8, but9, but0;
        int token = 0;

        public Animator openandclose;
        public bool open;
        public bool passWordCorrect = false;
        public Transform Player;

        [SerializeField] private KeypadInventory _keypadInventory;
        [SerializeField] private RedDoorOpenClose _ReddoorOpenClose;

        void Start()
        {
            if (keypadSound == null || OpendoorSound == null || IncorrectSound == null || CorrectSound == null)
            {
                keypadSound = GetComponent<AudioSource>();
                OpendoorSound = GetComponent<AudioSource>();
                IncorrectSound = GetComponent<AudioSource>();
                CorrectSound = GetComponent<AudioSource>();
            }
            open = false;
            KeyPadShow.SetActive(false);
            InterractKeyPadText.SetActive(false);

            keypadSound.pitch = Random.Range(minPitch, maxPitch);
        }

        void OnTriggerStay(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                if(passWordCorrect == false)
                {
                InterractKeyPadText.SetActive(true);

                    if (Input.GetKey(KeyCode.E))
                    {
                        playerScript.enabled = false;

                        KeyPadShow.SetActive(true);
                        InterractKeyPadText.SetActive(false);

                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;

                        Debug.Log("Keypad Enter");
                    }

                }

                if (Input.GetKey(KeyCode.Q))
                {
                    numtext.SetActive(true);
                    correcttext.SetActive(false);
                    incorrecttext.SetActive(false);
                    stringCharacters = 0;
                    codeString = "";
                    but1.interactable = true;
                    but2.interactable = true;
                    but3.interactable = true;
                    but4.interactable = true;
                    safeactive = false;
                    but5.interactable = true;
                    but6.interactable = true;
                    but7.interactable = true;
                    token = 0;
                    but8.interactable = true;
                    but9.interactable = true;
                    but0.interactable = true;
                    safecode.SetActive(false);

                    playerScript.enabled = true;
                    KeyPadShow.SetActive(false);

                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    _keypadInventory.hasKeypadOn = false;
                    Debug.Log("Keypad Exit");
                }

            }
        }

        void Update()
        {
            if (_ReddoorOpenClose.doOnceReddoor == false)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            if (_ReddoorOpenClose.doOnceReddoor == true)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            numTex.text = codeString;
            if (stringCharacters == 4)
            {
                if (codeString == correctCode)
                {
                    numtext.SetActive(false);
                    correcttext.SetActive(true);
                    but1.interactable = false;
                    but2.interactable = false;
                    but3.interactable = false;
                    but4.interactable = false;
                    but5.interactable = false;
                    but6.interactable = false;
                    but7.interactable = false;
                    but8.interactable = false;
                    but9.interactable = false;
                    but0.interactable = false;
                    _keypadInventory.hasKeypadOn = true;
                    if (token == 0)
                    {
                        CorrectSound.Play();
                        this.gameObject.GetComponent<BoxCollider>().enabled = false;
                        StartCoroutine(opening());
                        OpendoorSound.Play();
                        StartCoroutine(endSesh());
                        InterractKeyPadText.SetActive(false);

                        passWordCorrect = true;

                        token = 1;
                    }
                }
                else
                {
                    numtext.SetActive(false);
                    incorrecttext.SetActive(true);
                    but1.interactable = false;
                    but2.interactable = false;
                    but3.interactable = false;
                    but4.interactable = false;
                    but5.interactable = false;
                    but6.interactable = false;
                    but7.interactable = false;
                    but8.interactable = false;
                    but9.interactable = false;
                    but0.interactable = false;
                    if (token == 0)
                    {
                        IncorrectSound.Play();
                        StartCoroutine(endSesh());
                        token = 1;
                    }
                }
            }

        }

        void OnTriggerExit(Collider other)
        {
            InterractKeyPadText.SetActive(false);
        }


        IEnumerator endSesh()
        {
            yield return new WaitForSeconds(2.5f);
            numtext.SetActive(true);
            correcttext.SetActive(false);
            incorrecttext.SetActive(false);
            stringCharacters = 0;
            codeString = "";
            but1.interactable = true;
            but2.interactable = true;
            but3.interactable = true;
            but4.interactable = true;
            safeactive = false;
            but5.interactable = true;
            but6.interactable = true;
            but7.interactable = true;
            token = 0;
            but8.interactable = true;
            but9.interactable = true;
            but0.interactable = true;
            safecode.SetActive(false);

            playerScript.enabled = true;
            interactable = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        public void pressedOne()
        {
            codeString = codeString + "1";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedTwo()
        {
            codeString = codeString + "2";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedThree()
        {
            codeString = codeString + "3";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedFour()
        {
            codeString = codeString + "4";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedFive()
        {
            codeString = codeString + "5";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedSix()
        {
            codeString = codeString + "6";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedSeven()
        {
            codeString = codeString + "7";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedEight()
        {
            codeString = codeString + "8";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedNine()
        {
            codeString = codeString + "9";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }
        public void pressedZero()
        {
            codeString = codeString + "0";
            stringCharacters = stringCharacters + 1;
            keypadSound.Play();
        }


        IEnumerator opening()
        {
            print("you are opening the door");
            openandclose.Play("Opening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

    }
}
