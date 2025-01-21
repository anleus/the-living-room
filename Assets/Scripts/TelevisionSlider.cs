using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TelevisionSlider : TelevisionItem
{
    [SerializeField] private Image slider;
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI label;

    [SerializeField] private float value = 50;

    private void Start()
    {
        SetFillAmount();
    }

    public override void Highlight(bool active)
    {
        slider.color = Color.green;
        background.color = Color.green;
        label.color = Color.green;
    }

    public override void RemoveHighlighth(bool active)
    {
        slider.color = Color.white;
        background.color = Color.white;
        label.color = Color.white;
    }

    public override void Action(RemoteCommand command)
    {
        if (RemoteCommand.UP.Equals(command))
        {
            value += 5f;
            
        } 
        else if (RemoteCommand.DOWN.Equals(command))
        {
            value -= 5f;
        }
        SetFillAmount();
    }

    private void SetFillAmount()
    {
        float fillAmount = value / 100f;
        slider.fillAmount = fillAmount;
    }
}
