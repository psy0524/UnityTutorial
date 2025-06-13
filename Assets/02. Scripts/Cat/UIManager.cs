using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager;
        
        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;
        public Button startButton;
        public Button reStartButton;

        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;
        public GameObject videoPanel;

        private void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
            reStartButton.onClick.AddListener(OnRestartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)
            {
                Debug.Log("입력한 텍스트 없음");
            }
            else
            {
                playObj.SetActive(true);
                introUI.SetActive(false);
                playUI.SetActive(true);
                GameManager.isPlay = true;
                
                nameTextUI.text = inputField.text;
                soundManager.SetBGMSound("Play");
                Debug.Log($"{nameTextUI.text} 입력");
            }
        }
        public void OnRestartButton()
        {
            GameManager.ResetPlayUI();
            videoPanel.SetActive(false);
            playObj.SetActive(true);
            playUI.SetActive(true);
            soundManager.audioSource.Play();
        }
    }
}

