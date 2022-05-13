using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class ButtonUI : MonoBehaviour
{
    public void HandleButtonClick()
    {
        EventManager.Instance.Raise(new ButtonClickedEvent());
    }
}
