using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel; // 페이드 이미지

    public float fadeTime = 3f; // 원하는 페이드 시간

    private float percent = 0f;

    private float timer = 0f; // 사용될 타이머

    public bool isFadeIn = false;

    public void OnFade(float fadeTime, Color color)
    {
        StartCoroutine(Fade(fadeTime, color));
    }
    
    IEnumerator Fade(float fadeTime, Color color)
    {
        
        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime; // 페이드 퍼센트
            //float value = isFadeIn ? percent : 1 - percent;

            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;
        }
        
    }
}
