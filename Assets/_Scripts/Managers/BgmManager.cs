using UnityEngine;

namespace _Scripts.Managers
{
    public class BgmManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audio;
        [SerializeField] private AudioClip _winBgm;
        [SerializeField] private AudioClip _loseBgm;

        private void PlayBgm(AudioClip clip)
        {
            _audio.clip = clip;
            _audio.Play();
        }

        public void PlayWinBgm()
        {
            PlayBgm(_winBgm);
        }

        public void PlayLoseBgm()
        {
            PlayBgm(_loseBgm);
        }
    }
}