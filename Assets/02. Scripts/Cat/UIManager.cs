using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;
        public Button startButton;

        public GameObject playObj;
        public GameObject introUI;

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
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
                
                Debug.Log($"{nameTextUI.text} 입력");
                nameTextUI.text = inputField.text;
            }
        }
    }
}

