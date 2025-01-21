using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelevisionButton : TelevisionItem
{
    [SerializeField] private Image background;
    [SerializeField] private Color disabledColor;
    [SerializeField] private Color highlightedDisabledColor;
    [SerializeField] private bool disabled = true;

    private void Start()
    {
        RemoveHighlighth(false);
    }

    public override void Action(RemoteCommand command)
    {
        if (!disabled)
        {
            Debug.Log("hola");
        }
    }

    public override void Highlight(bool active)
    {
        if (!active) background.color = highlightedDisabledColor;
        else background.color = Color.green;

        disabled = !active;
    }

    public override void RemoveHighlighth(bool active)
    {
        if (!active) background.color = disabledColor;
        else background.color = Color.white;

        disabled = !active;
    }
}
