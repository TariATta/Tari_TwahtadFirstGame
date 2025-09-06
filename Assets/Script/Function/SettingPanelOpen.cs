using JetBrains.Annotations;
using UnityEngine;

public class SettingPanelOpen : MonoBehaviour
{
    public GameObject SettingPanelinGame;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OpenSettingPanel();
        }
    }
    

    public void CloseButton()
    {
        if(!SettingPanelinGame.activeInHierarchy)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }



    public void OpenSettingPanel()
    {
        Time.timeScale = 0f;
        SettingPanelinGame.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
