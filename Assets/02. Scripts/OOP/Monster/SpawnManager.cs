using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //이미 정해진 개수가 있는 경우
    [SerializeField] private GameObject[] monsters;
    [SerializeField] private GameObject[] items;

    // n초마다 몬스터를 랜덤으로 생성하는 기능

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            var randomIndex = Random.Range(0, monsters.Length);
            var randomX = Random.Range(-8, 9);
            var randomY = Random.Range(-3, 5);

            var createPos = new Vector3(randomX, randomY, 0);

            Instantiate(monsters[randomIndex], createPos, Quaternion.identity);
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceY(3f, ForceMode2D.Impulse);
        itemRb.AddForceX(Random.Range(-3f, 3f), ForceMode2D.Impulse);
        itemRb.AddTorque(Random.Range(-5f,5f), ForceMode2D.Impulse);
    }
}
