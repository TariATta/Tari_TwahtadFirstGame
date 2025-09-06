using UnityEngine;
using CutScene1System;

namespace BindwithWalking
{
    public class WalkSoundver2 : MonoBehaviour
    {
        public AudioSource footstepSound, sprintSound;


        [SerializeField] CutSceneTrigger _cutFirstDoorTrig;
        [SerializeField] private StartSceneTrig _startSceneTrig;

        void Start()
        {
            footstepSound.volume = 0.2f;
            sprintSound.volume = 0.3f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            if (_startSceneTrig.DoCutOnce == true)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    footstepSound.volume = 0.2f;
                    sprintSound.volume = 0.3f;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        sprintSound.enabled = true;
                        footstepSound.enabled = false;
                    }
                    else
                    {
                        footstepSound.enabled = true;
                        sprintSound.enabled = false;
                    }
                }
                else
                {
                    footstepSound.enabled = false;
                    sprintSound.enabled = false;
                    footstepSound.volume = 0.2f;
                    sprintSound.volume = 0.3f;
                }
            }
            //else if (_cutFirstDoorTrig.alreadyTag == false)
            //{
                //footstepSound.volume = 0.0f;
                //sprintSound.volume = 0.0f;
            //}
            else if (_startSceneTrig.DoCutOnce == false)
            {
                footstepSound.volume = 0.0f;
                sprintSound.volume = 0.0f;
            }

        }
    }
}