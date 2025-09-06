using UnityEngine;

public class ChatuluJumpShow : MonoBehaviour
{
    [SerializeField] ChatuluJump _chatuluJump;
    public GameObject JumpPic;
    public AudioSource JumpAudio;

    public bool JumpOnce = false;

    void Start()
    {
        JumpPic.SetActive(false);
    }
    void Update()
    {
        if (_chatuluJump.DoJump == true)
        {
            if (JumpOnce == false)
            {
                JumpPic.SetActive(true);

                JumpAudio.Play();

                JumpOnce = true;
            }
            Invoke(nameof(JumpPicScene), 2);

        }
    }
    
        void JumpPicScene()
    {
        JumpPic.SetActive(false);
    }
}
