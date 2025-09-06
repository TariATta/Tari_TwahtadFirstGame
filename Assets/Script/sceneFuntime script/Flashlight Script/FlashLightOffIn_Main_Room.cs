using UnityEngine;
using ChatuluSystem2;
using System.Collections;

public class FlashLightOffIn_Main_Room : MonoBehaviour
{
    public GameObject RoomObject;
    public GameObject FlashlightLight;
    [SerializeField] ChatuluInventory _chatuluInventory;
    [SerializeField] Cutscene2Trigger _cutscene2Trigger;
    public AudioSource MusicBoxsong;
    public float fadeDuration = 5f;

    public bool preRendered;

    public bool hasFadeIn = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (_chatuluInventory.hasChatulu == true)
            {
                if (preRendered == false)
                {
                    FlashlightLight.SetActive(false);

                    if (MusicBoxsong != null)
                    {
                        if (_cutscene2Trigger.hasPutOnShelf == false)
                        {
                            MusicBoxsong.Play();
                        }
                    }
                }
            }
        }

    }


    void OnTriggerExit(Collider other)
    {
        MusicBoxsong.Stop();
    }


}
