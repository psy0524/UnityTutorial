using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    public Transform targetTf;
    public Transform turretHead;

    public GameObject bulletPrefab;
    public Transform firePos;
    public float timer;
    public float cooldownTime;
    
    // 1�� ���� -> �����ΰ��� �����ϴ� ���
    void Start()
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
    }

    // �����ΰ� �ٶ󺸴� ���
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
