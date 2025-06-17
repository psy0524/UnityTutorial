using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform grabPos;
    private IDropItem currentItem;

    

    private void Update()
    {
        Move();
        Interaction();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized * Time.deltaTime;

        transform.position += dir * moveSpeed;
    }

    private void Interaction()
    {
        if (currentItem == null) { return; }
        if(Input.GetMouseButtonDown(0))
        {
            currentItem.Use();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop();
            currentItem = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item;

            item.Grab(grabPos);
        }
    }
}
