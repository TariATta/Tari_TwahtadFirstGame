using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChatuluSystem2
{
    public class Cutscene2Trigger : MonoBehaviour
    {
        public GameObject cutscene2Object;
        public Animator cutscene2Anim;
        public bool preRendered;
        public string cutsceneTriggerName;

        public playercontrol playerScript;
        public Camera playerCam;
        public Camera Cutscene2SceneCam;

        public float cutsceneTime;
        public GameObject ChatuluOnPlayer;

        public bool hasPutOnShelf = false;
        [SerializeField] private AudioSource musicFileScene2;
        [SerializeField] private AudioSource musicjumpScene2;
        public float fadeDuration = 4f;

        [SerializeField] private ChatuluInventory _chatuluInventory;


        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _chatuluInventory.hasChatulu == true)
            {
                playerScript.enabled = false;
                if (preRendered == false)
                {
                    if (hasPutOnShelf == false)
                    {
                        if (musicFileScene2 != null)
                        {
                            StartCoroutine(FadeIn(musicFileScene2, fadeDuration));
                        }
                        musicjumpScene2.PlayDelayed(14.3f);



                        cutscene2Object.SetActive(true);

                        playerCam.enabled = false;
                        playerCam.GetComponent<AudioListener>().enabled = false;
                        Cutscene2SceneCam.GetComponent<AudioListener>().enabled = true;

                        cutscene2Anim.SetTrigger(cutsceneTriggerName);
                        StartCoroutine(cutsceneRoutine());


                    }
                    
                }
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }

        IEnumerator FadeIn(AudioSource targetAudioSource, float duration)
    {
        targetAudioSource.volume = 0f; 
        targetAudioSource.Play();
        targetAudioSource.time = 12;

        float currentTime = 0;
        float startVolume = 0f;
        float targetVolume = 0.2f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            targetAudioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }

        targetAudioSource.volume = targetVolume;
    }

        IEnumerator cutsceneRoutine()
        {
            hasPutOnShelf = true;
            yield return new WaitForSeconds(cutsceneTime);
            SceneManager.LoadScene("mainmenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ChatuluOnPlayer.SetActive(false);
        }
    }
}
