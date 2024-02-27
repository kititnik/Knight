using UnityEngine;

public class UIHandler
{
    private GameObject _actionButton;

    public UIHandler(GameObject actionButton)
    {
        _actionButton = actionButton;
    }

    public void OnEnterActionZone()
    {
        _actionButton.SetActive(true);
    }

    public void OnExitActionZone()
    {
        _actionButton.SetActive(false);
    }
}
