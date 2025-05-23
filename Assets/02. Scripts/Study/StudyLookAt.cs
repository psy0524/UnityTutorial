using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    public Transform targetTf;
    public Transform turretHead;

    public GameObject bulletPrefab;
    public Transform firePos;
    public float timer;
    public float cooldownTime;
    
    // 1번 실행 -> 무엇인가를 셋팅하는 기능
    void Start()
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
    }

    // 무엇인가 바라보는 기능
    void Update()
    {
        turretHead.LookAt(targetTf);

        timer += Time.deltaTime;
        if( timer >= cooldownTime)
        {
            timer = 0f;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
        
    }
}
