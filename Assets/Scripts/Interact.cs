using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject interactiveBtn;
    [SerializeField] private GameObject interactionUI;
    private IInteractable interactable;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        interactable = collider2D.GetComponent<IInteractable>();
        if(interactable == null) return;
        interactiveBtn.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.GetComponent<IInteractable>() == null) return;
        if(interactiveBtn!=null) interactiveBtn.SetActive(false);
        interactable = null;
    }

    public void Send()
    {
        if(interactable == null) return;
        interactiveBtn.SetActive(false);
        interactable.Invoke(gameObject, interactionUI);
    }
}
