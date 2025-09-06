using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace BindwithWalking
{
    public class StartSceneTrig : MonoBehaviour
    {
        public Animator FirstSceneAnim;
        public bool preRendered;
        public string CutsceneName;

        public playercontrol playerScript;
        public Camera playerCam;
        public Camera startCutSceneCam;

        public GameObject CanvasstartCut;

        public float cutsceneTime;
        public bool DoCutOnce = false;

        [SerializeField] GameObject ObjRawImg;
        [SerializeField] GameObject PickFlashLight;


        void Start()
        {
            if (SceneManager.GetActiveScene().name == "Funtime")
            {
                if (DoCutOnce == false)
                {
                    Debug.Log("DoCutOnce is false");

                    playerScript.enabled = false;
                    if (preRendered == false)
                    {
                        playerCam.GetComponent<AudioListener>().enabled = false;
                        startCutSceneCam.GetComponent<AudioListener>().enabled = true;
                        playerCam.enabled = false;

                        CanvasstartCut.SetActive(true);

                        FirstSceneAnim.SetTrigger(CutsceneName);
                        StartCoroutine(cutsceneRoutine());
                    }

                }
            }
        }

        void Update()
        {
            if (DoCutOnce == false)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    Debug.Log("skip");

                    FirstSceneAnim.GetComponent<Animator>().enabled = false;

                    CanvasstartCut.SetActive(false);

                    playerScript.enabled = true;
                    playerCam.enabled = true;
                    startCutSceneCam.enabled = false;
                    playerCam.GetComponent<AudioListener>().enabled = true;
                    startCutSceneCam.GetComponent<AudioListener>().enabled = false;

                    DoCutOnce = true;
                    Debug.Log("DoCutOnce is true!");
                }
            }
        }


        IEnumerator cutsceneRoutine()
        {
            yield return new WaitForSeconds(cutsceneTime);

            playerScript.enabled = true;
            playerCam.enabled = true;
            startCutSceneCam.enabled = false;
            playerCam.GetComponent<AudioListener>().enabled = true;
            startCutSceneCam.GetComponent<AudioListener>().enabled = false;
            
            CanvasstartCut.SetActive(false);

            DoCutOnce = true;
            Debug.Log("DoCutOnce is true!");
        }
        

    }
}