using System.Collections;
using FlashLightBindingDoor;
using Unity.VisualScripting;
using UnityEngine;

namespace CutScene1System
    {
    public class CutSceneTrigger : MonoBehaviour
    {
        public GameObject cutsceneFirstDoorObject;
        public Animator cutsceneFirstDoorAnim;

        public bool preRendered;
        public bool alreadyTag = false;
        public string cutsceneTriggerName;

        public playercontrol playerScript;
        public Camera playerCam;
        public Camera cutSceneCam;
        public float cutsceneTime;

        public GameObject FlashLightOnPlayer;


        [SerializeField] private FlashlightInventory _flaslightInventory;
        public bool DoCutOnce = false;

        [SerializeField] AudioSource AmbientFirstdoor;

        void Start()
        {
            cutsceneFirstDoorObject.SetActive(false);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerScript.enabled = false;
                if (preRendered == false)
                {
                    cutsceneFirstDoorObject.SetActive(true);


                    AmbientFirstdoor.Play();

                    
                    playerCam.enabled = false;
                    playerCam.GetComponent<AudioListener>().enabled = false;
                    cutSceneCam.GetComponent<AudioListener>().enabled = true;



                    cutsceneFirstDoorAnim.SetTrigger(cutsceneTriggerName);

                    alreadyTag = true;
                    StartCoroutine(cutsceneRoutine());
                }
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }

        void Update()
        {
            if (alreadyTag == true)
            {
                if (DoCutOnce == false)
                {
                    if (Input.GetKey(KeyCode.Return))
                    {
                        Debug.Log("skip");

                        cutsceneFirstDoorObject.SetActive(false);

                        cutsceneFirstDoorAnim.GetComponent<Animator>().enabled = false;

                        playerScript.enabled = true;
                        playerCam.enabled = true;
                        cutSceneCam.enabled = false;

                        playerCam.GetComponent<AudioListener>().enabled = true;
                        cutSceneCam.GetComponent<AudioListener>().enabled = false;
                        alreadyTag = false;

                        DoCutOnce = true;
                        Debug.Log("DoCutOnce is true!");
                    }
                }
            }
        }

        IEnumerator cutsceneRoutine()
        {
            yield return new WaitForSeconds(cutsceneTime);
            playerScript.enabled = true;

            cutsceneFirstDoorObject.SetActive(false);


            playerCam.enabled = true;
            playerCam.GetComponent<AudioListener>().enabled = true;
            cutSceneCam.GetComponent<AudioListener>().enabled = false;

            DoCutOnce = true;
            alreadyTag = false;

            if (_flaslightInventory.hasFlashLight == true)
            {
                FlashLightOnPlayer.SetActive(true);
            }

        }
    }
    }
