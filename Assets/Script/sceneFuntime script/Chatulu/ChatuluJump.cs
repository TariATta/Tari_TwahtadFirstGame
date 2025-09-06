using UnityEngine;

public class ChatuluJump : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject ChatuluJumpObj;
    public bool DoJump = false;


    void Start()
    {
        PickUpText.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if (DoJump == false)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    ChatuluJumpObj.SetActive(false); ;
                    PickUpText.SetActive(false);

                    DoJump = true;
                }
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}

