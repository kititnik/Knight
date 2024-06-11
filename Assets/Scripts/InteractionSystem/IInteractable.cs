using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Invoke(GameObject player, GameObject interactionUI);
}
