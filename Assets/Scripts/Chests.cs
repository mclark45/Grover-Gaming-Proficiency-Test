using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chests : MonoBehaviour
{
    public Button[] _chests;

    public void Click(Button button)
    {
        button.interactable = false;
    }

    public void DisableChest()
    {
       foreach (Button button in _chests)
            button.interactable = false;
    }
}
