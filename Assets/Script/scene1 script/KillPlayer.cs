using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Yaaah");
            other.transform.eulerAngles = new Vector3(0, 0, 0);
            other.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
            
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);                //player.transform.position = respawnPoint.position;
        }
    }
}
