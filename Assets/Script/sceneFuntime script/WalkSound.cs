using UnityEngine;

public class WalkSound : MonoBehaviour
{
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource runSound;

    void Start()
    {
        walkSound.Stop();
        runSound.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walkSound.Stop();
                runSound.Play();
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walkSound.Play();
                runSound.Stop();
            }
        }
        else
        {
            walkSound.Stop();
            runSound.Stop();
        }
    }
}
