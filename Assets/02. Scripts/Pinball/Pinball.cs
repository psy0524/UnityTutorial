using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager; // ¿Ø¥œ∆º ªÛø°º≠ «“¥Á « ø‰

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged") == false)
        {
            int score = 0;
            switch (collision.gameObject.tag)
            {
                case "Score10":
                    score = 10;
                    break;
                case "Score20":
                    score = 20;
                    break;
            }

            pinballManager.totalScore += score;
            Debug.Log($"{score}¡° »πµÊ");
        }
        
        //if (collision.gameObject.CompareTag("Score10"))
        //{
        //    pinballManager.totalScore += 10;
        //    Debug.Log("10¡° »πµÊ");
        //}
        //else if (collision.gameObject.CompareTag("Score20"))
        //{
        //    pinballManager.totalScore += 20;
        //    Debug.Log("20¡° »πµÊ");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"∞‘¿” ¡æ∑· : √÷¡æ ¡°ºˆ {pinballManager.totalScore}");
        }
    }
}
