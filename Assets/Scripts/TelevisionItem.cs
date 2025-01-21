using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class TelevisionItem : MonoBehaviour
{
    public abstract void Highlight(bool active);
    public abstract void RemoveHighlighth(bool active);
    public abstract void Action(RemoteCommand command);
}
