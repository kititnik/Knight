using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour, IInteractable
{
    private int currentLevel;
    [SerializeField] private GameObject[] castleLevels;

    public void Invoke(GameObject player, GameObject interactionUI)
    {
        MoveToNextLevel();
    }

    public void MoveToNextLevel()
    {
        if(currentLevel >= castleLevels.Length) return;
        castleLevels[currentLevel].SetActive(false);
        currentLevel++;
        castleLevels[currentLevel].SetActive(true);
    }
}
