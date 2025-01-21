using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cigarette : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool pressed;
    private bool disabledClose;

    private void OnEnable()
    {
        DiscPlayer.OnDiscIntroduced += DiscOnPlayer;
    }

    public void ActionAnimation(ActivateEventArgs args)
    {
        if (!pressed)
        {
            animator.SetTrigger("action");
            pressed = true;
        } 
    }

    private void DiscOnPlayer()
    {
        disabledClose = true;
    }

    private void Close()
    {
        if (!disabledClose)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
