using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioClip jumpClip;
        public AudioSource audioSource;
        public AudioClip bgmClip;

        private void Start()
        {
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip; // 오디오 소스에 사운드 파일 설정

            audioSource.playOnAwake = true; // 시작할 때 자동 재생
            audioSource.loop = true; // 오디오 반복

            audioSource.volume = 0.1f; // 오디오 음량

            audioSource.Play(); // 소스 시작

            //audioSource.Stop(); // 오디오 정지
            //audioSource.Pause(); // 일시정지
        }
        
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip); // 이벤트 사운드
        }
    }
}

