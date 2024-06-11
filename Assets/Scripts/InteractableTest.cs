using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour, IInteractable
{
    public void Invoke(GameObject player, GameObject interactionUI)
    {
        Debug.Log("Interaction with " + gameObject.name);
    }
}
