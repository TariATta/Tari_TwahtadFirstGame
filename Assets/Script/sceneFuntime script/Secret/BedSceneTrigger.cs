using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedSceneTrigger : MonoBehaviour
{
        public GameObject cutscenebedObject;
        public Animator cutsceneBedAnim;
        public bool preRenndered;
        public string bedcutsceneTriggerName;

        public playercontrol playerScript;
        public Camera playerCam;
        public Camera CutsceneCam;
        public GameObject Sleeptext;

        public float cutsceneTime;

        public bool tagged = false;
        public bool Onbeded = false;
        [SerializeField] private AudioSource musicFileScene2;
        [SerializeField] private AudioSource addEffect;

        [SerializeField] GameObject flashLightOnplayer;
        [SerializeField] GameObject toiKeyOnplayer;
        [SerializeField] GameObject redKeyOnplayer;
        [SerializeField] GameObject chatuluOnplayer;
        [SerializeField] GameObject keypadOnplayer;


    void Start()
    {
        Sleeptext.SetActive(false);
    }


    public void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
        {
            Sleeptext.SetActive(true);
            tagged = true;
        }
        }


    void OnTriggerExit(Collider other)
    {
        Sleeptext.SetActive(false);
        tagged = false;
    }

    void Update()
    {
        if(tagged == true){
            if (preRenndered == false)
            {


                if (Input.GetKey(KeyCode.E))
                {
                    cutscenebedObject.SetActive(true);

                    playerScript.enabled = false;
                    Sleeptext.SetActive(false);

                    flashLightOnplayer.SetActive(false);
                    toiKeyOnplayer.SetActive(false);
                    redKeyOnplayer.SetActive(false);
                    chatuluOnplayer.SetActive(false);
                    keypadOnplayer.SetActive(false);
                    

                    Onbeded = true;

                    playerCam.enabled = false;
                    playerCam.GetComponent<AudioListener>().enabled = false;
                    CutsceneCam.GetComponent<AudioListener>().enabled = true;

                    musicFileScene2.PlayDelayed(19);
                    addEffect.PlayDelayed(4);

                    cutsceneBedAnim.SetTrigger(bedcutsceneTriggerName);
                    StartCoroutine(cutsceneRoutine());

                }

                
            }
        }
    }
    IEnumerator cutsceneRoutine()
        {
            yield return new WaitForSeconds(cutsceneTime);
            
            playerCam.GetComponent<AudioListener>().enabled = true;
            CutsceneCam.GetComponent<AudioListener>().enabled = false;
            SceneManager.LoadScene("mainmenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

