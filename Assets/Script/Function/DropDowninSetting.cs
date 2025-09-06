using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicSystemLol
{
    [RequireComponent(typeof(AudioSource))]
    public class DropDowninSetting : MonoBehaviour
    {

        [SerializeField] private AudioSource musicFile1;
        [SerializeField] private AudioSource musicFile2;
        [SerializeField] private AudioSource musicFile3;
        [SerializeField] private AudioSource musicFile4;



        public void PauseAllMusic()
        {
            musicFile1.Pause();
            musicFile2.Pause();
            musicFile3.Pause();
            musicFile4.Pause();
        }


        public void Dropdownmusic(int index)
        {
            switch (index)
            {
                case 0:
                    PauseAllMusic();
                    musicFile1.Play(); break;
                case 1:
                    PauseAllMusic();
                    musicFile2.Play(); break;
                case 2:
                    PauseAllMusic();
                    musicFile3.Play(); break;
                case 3:
                    PauseAllMusic();
                    musicFile4.Play(); break;



            }
        }
    }
}
