using System;
using System.Collections;
using UnityEngine;
namespace ChatuluSystem2{
    public class ChatuluShelfController : MonoBehaviour
    {
        private Animator chatuluAnim;
        private bool chatuluPlace = false;

        [Header("Cutscene Names")]
        [SerializeField] private string endCutscene = "TheEnd";

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showLockedUI = null;

        [SerializeField] private ChatuluInventory _chatuluInventory = null;

        [SerializeField] private int waitTimer = 1; //DoorCloseOpen
        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            chatuluAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseChatuluInteraction(){
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if(_chatuluInventory.hasChatulu){
                ChatuluPlace();
            }
            else{
                StartCoroutine(ShowLocked());
            }
        }

        void ChatuluPlace()
        {
            if(!chatuluPlace && !pauseInteraction){
                chatuluAnim.Play(endCutscene);
                chatuluPlace = true;
                StartCoroutine(PauseChatuluInteraction());
            }
        }


        IEnumerator ShowLocked(){
            showLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showLockedUI.SetActive(false);
        }
    }
}