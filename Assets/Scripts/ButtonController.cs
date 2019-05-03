using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public ButtonScript buttonInAction;

    public void SetNewButton(ButtonScript button) {
        if (buttonInAction)
            buttonInAction.selected = false;

        buttonInAction = button;
    }
}
