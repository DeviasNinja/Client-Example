using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public bool hovered;
    public bool selected;
    public float speed = 5f;

    public Transform trigger;
    public Transform[] trans;

    public ButtonController bc;
	
	// Update is called once per frame
	void Update () {
        if (hovered || selected) {
            if (trans[0].position != trans[1].position)
                trans[0].position = Vector3.Lerp(trans[0].position, trans[1].position, Time.deltaTime * speed);

            if (trigger.eulerAngles != new Vector3(0, 0, 90))
                trigger.eulerAngles = Vector3.Lerp(trigger.eulerAngles, new Vector3(10, 0, 90), Time.deltaTime * speed);
        } else if (!hovered && !selected) {
            if (trans[0].position != trans[2].position)
                trans[0].position = Vector3.Lerp(trans[0].position, trans[2].position, Time.deltaTime * speed);

            if (trigger.eulerAngles != Vector3.zero)
                trigger.eulerAngles = Vector3.Lerp(trigger.eulerAngles, new Vector3(10, 0, 0), Time.deltaTime * speed);
        }

        if (selected && trans[3].position != trans[4].position)
            trans[3].position = Vector3.Lerp(trans[3].position, trans[4].position, Time.deltaTime * speed);
        else if (!selected && trans[0].position != trans[2].position)
            trans[3].position = Vector3.Lerp(trans[3].position, trans[5].position, Time.deltaTime * speed);
    }

    public void Hover(bool exit) {
        if (!exit)
            hovered = true;
        else
            hovered = false;
    }

    public void Select() {
        selected = !selected;

        if (selected)
            bc.SetNewButton(this);
    }

}
