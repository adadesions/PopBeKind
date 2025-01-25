using UnityEngine;

namespace _Scripts.Managers
{
    public class SfxManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _goodFeelingSfx;
        [SerializeField] private AudioClip _badFeelingSfx;
        [SerializeField] private AudioClip _popSfx;


        private void PlaySfx(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
        
        public void PlayGoodFeelingSfx()
        {
            PlaySfx(_goodFeelingSfx);
        }

        public void PlayBadFeelingSfx()
        {
            PlaySfx(_badFeelingSfx);
        }

        public void PlayPopSfx()
        {
            PlaySfx(_popSfx);
        }
    }
}