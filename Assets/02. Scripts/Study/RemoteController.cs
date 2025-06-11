using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;

    public Button[] buttonUI;

    public VideoClip[] clips;

    private VideoPlayer videoPlayer;

    public int currentClipIndex; // 현재 영상 인덱스

    public bool isOn = false;
    public bool isMute = false;

    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0]; // 디폴트 영상 설정
    }

    private void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    public void OnScreenPower()
    {
        // NOT을 활용하여 줄여서 적은 방법
        isOn = !isOn;
        videoScreen.SetActive(isOn); // GameObject 속성을 활용해서 적은 방법
        //videoScreen.SetActive(!videoScreen.activeSelf); // GameObject 속성을 활용해서 적은 방법
        
        
        // 길게 적은 방법
        
        //if (!isOn)
        //{
        //    videoScreen.SetActive(true);
        //    isOn = true;
        //}
        //else
        //{
        //    videoScreen.SetActive(false);
        //    isOn = false;
        //}
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);
        //videoScreen.GetComponent<VideoPlayer>().SetDirectAudioMute(0, isMute); // 영상의 소리 음소거
    }


    public void OnNextChannel() // 오른쪽 버튼
    {
        if(!isOn)
        {
            return;
        }
        
        currentClipIndex++;

        if(currentClipIndex >= clips.Length)
        {
            currentClipIndex = 0;
        }
        videoPlayer.clip = clips[currentClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel() // 왼쪽 버튼
    {
        if (!isOn)
        {
            return;
        }

        currentClipIndex--;

        if (currentClipIndex < 0)
        {
            currentClipIndex = clips.Length -1;
        }
        videoPlayer.clip = clips[currentClipIndex];
        videoPlayer.Play();
    }
}
