using UnityEngine;
using CutScene1System;

public class subAfterScene : MonoBehaviour
{
    [SerializeField] CutSceneTrigger _cutsceneTrigger;
    [SerializeField] bool DosubOnce = false;

    [SerializeField] GameObject Subtext;

    void Start()
    {
        Subtext.SetActive(false);
    }

    void Update()
    {
        if (_cutsceneTrigger.DoCutOnce == true)
        {
            if (DosubOnce == false)
            {
                Subtext.SetActive(true);
                DosubOnce = true;
            }
            Invoke(nameof(SubDelay), 4);
        }
    }

    void SubDelay()
    {
        Subtext.SetActive(false);
    }
}
