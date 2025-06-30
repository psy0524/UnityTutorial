using System.Collections;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public enum InteractionType { Sign, Door, NPC };
    public InteractionType type;
    public FadeRoutine fade;
    public GameObject popUp;
    public GameObject map;
    public GameObject house;
    public SoundController soundController;

    public Vector3 inDoorPos;
    public Vector3 outDoorPos;
    public bool isHouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Interaction(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            popUp.SetActive(false);
        }
    }

    void Interaction(Transform player)
    {
        switch (type)
        {
            case InteractionType.Door:
                StartCoroutine(DoorRoutine(player));
                break;
            case InteractionType.NPC:
                popUp.SetActive(true);
                break;
            case InteractionType.Sign:
                popUp.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player)
    {
        soundController.EventSoundPlay("Door Open");
        yield return StartCoroutine(fade.Fade(2f, Color.black, true));


        map.SetActive(isHouse);
        house.SetActive(!isHouse);
        
        var pos = isHouse ? outDoorPos : inDoorPos;
        player.transform.position = pos;

        isHouse = !isHouse;
   
        yield return new WaitForSeconds(1f);
        soundController.EventSoundPlay("Door Close");
        yield return StartCoroutine(fade.Fade(2f, Color.black, false));
    }
}
