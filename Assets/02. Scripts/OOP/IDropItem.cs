using System.Collections;
using UnityEngine;


public interface IDropItem 
{
    void Grab(Transform transform);
    void Use();
    void Drop();
}
