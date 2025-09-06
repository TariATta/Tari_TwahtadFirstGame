using System.Collections;
using System.Collections.Generic;
using FlashLightBindingDoor;
using ChatuluSystem2;
using Keyof2Systen;
using KeypadSystem;
using UnityEngine;
using CutScene1System;
using UnityEngine.SceneManagement;
using BindwithWalking;


public class ObjectiveControl : MonoBehaviour
{
    [SerializeField] GameObject ObjRawImage;
    [SerializeField] GameObject PickFlashlightText;
    [SerializeField] GameObject GoOutsideText;
    [SerializeField] GameObject FindTheMissingStatue;
    [SerializeField] GameObject PutStatueBackShelf;

    [SerializeField] Keysof2Inventory _keyof2Inventory;
    [SerializeField] KeypadInventory _keypadInventory;
    [SerializeField] ChatuluInventory _chatuluInventory;
    [SerializeField] FlashlightInventory _flashLightInventory;
    
    [SerializeField] GameObject cutsceneFirstDoorObject;

    [SerializeField] BedSceneTrigger _bedsceneTrigger;
    [SerializeField] private CutSceneTrigger _cutSceneTrigger;
    [SerializeField] private Cutscene2Trigger _cutscene2Trigger;
    [SerializeField] private StartSceneTrig _startSceneTrig;

    [SerializeField] bool DoStartSceneOnce = false;
    [SerializeField] bool DoFlashLightOnce = false;
    [SerializeField] bool DoFirstDoorOnce = false;
    [SerializeField] bool DoPickStatueOnce = false;
    [SerializeField] bool DoPutOnShelfonce = false;
    [SerializeField] bool DobeOnBedOnce = false;

    void Start()
    {
        PickFlashlightText.SetActive(true);
        GoOutsideText.SetActive(false);
        FindTheMissingStatue.SetActive(false);
        PutStatueBackShelf.SetActive(false);
        ObjRawImage.SetActive(false);
    }

    void Awake()
    {
        //StartCoroutine(PickUpFlashlightDelay());
    }

    void Update()
    {
        if (_startSceneTrig.DoCutOnce == true)
        {
            if (DoStartSceneOnce == false)
            {
                ObjRawImage.SetActive(true);
                DoStartSceneOnce = true;
            }
        }

        if (_flashLightInventory.hasFlashLight == true)
        {
            if (DoFlashLightOnce == false)
            {
                PickFlashlightText.SetActive(false);
                GoOutsideText.SetActive(true);
                FindTheMissingStatue.SetActive(false);
                PutStatueBackShelf.SetActive(false);
                DoFlashLightOnce = true;
            }

        }
        if (_cutSceneTrigger.alreadyTag == true)
        {
            if (DoFirstDoorOnce == false)
            {
                Debug.Log("StopObjtive");
                ObjRawImage.SetActive(false);
                DoFirstDoorOnce = true;
            }
        }

        if (_cutSceneTrigger.alreadyTag == false)
        {
            if (DoFirstDoorOnce == true)
            {
                PickFlashlightText.SetActive(false);
                GoOutsideText.SetActive(false);
                FindTheMissingStatue.SetActive(true);
                PutStatueBackShelf.SetActive(false);
                Debug.Log("StartObjective");
                ObjRawImage.SetActive(true);
            }
        }

        if (_chatuluInventory.alredy_Have == true)
        {
            if (DoPickStatueOnce == false)
            {
                PickFlashlightText.SetActive(false);
                GoOutsideText.SetActive(false);
                FindTheMissingStatue.SetActive(false);
                PutStatueBackShelf.SetActive(true);
            }

        }

        if (_cutscene2Trigger.hasPutOnShelf == true)
        {
            if (DoPutOnShelfonce == false)
            {
                ObjRawImage.SetActive(false);
                DoPickStatueOnce = true;
            }
        }

        if (_bedsceneTrigger.Onbeded == true)
        {
            if (DobeOnBedOnce == false)
            {
                ObjRawImage.SetActive(false);
            }
        }
    }


    //IEnumerator PickUpFlashlightDelay()
    //{
        //yield return new WaitForSeconds(16);
        //ObjRawImage.SetActive(true);
    //}



}
