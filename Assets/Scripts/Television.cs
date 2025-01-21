using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Television : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private GameObject off;
    [SerializeField] private GameObject on;

    private int selectedIndex = 0;
    [SerializeReference] private List<TelevisionItem> tvItems;

    [SerializeField] private bool active = false;
    [SerializeField] private bool playActive = false;

    private void OnEnable()
    {
        RemoteController.OnSendCommandController += ProcessCommand;
        DiscPlayer.OnDiscIntroduced += DiscOnPlayer;
    }

    private void OnDisable()
    {
        RemoteController.OnSendCommandController -= ProcessCommand;
        DiscPlayer.OnDiscIntroduced -= DiscOnPlayer;
    }

    private void Start()
    {
        off.SetActive(true);
        on.SetActive(false);
        active = false;
    }

    private void ProcessCommand(RemoteCommand command)
    {
        switch (command)
        {
            case RemoteCommand.POWER:
                PowerCommand();
                break;
            case RemoteCommand.UP:
                UpCommand();
                break;
            case RemoteCommand.DOWN:
                DownCommand();
                break;
            case RemoteCommand.LEFT:
                LeftCommand();
                break;
            case RemoteCommand.RIGHT:
                RightCommand();
                break;
            case RemoteCommand.SELECT:
                SelectCommand();
                break;
        }
    }

    private void PowerCommand()
    {
        active = !active;
        off.SetActive(!active);
        on.SetActive(active);

        if (active)
        {
            selectedIndex = 0;
            HighlightLabel();
        }
    }

    private void UpCommand()
    {
        tvItems[selectedIndex].Action(RemoteCommand.UP);
    }

    private void DownCommand()
    {
        tvItems[selectedIndex].Action(RemoteCommand.DOWN);
    }

    private void LeftCommand()
    {
        if (active)
        {
            selectedIndex = Math.Max(selectedIndex - 1, 0);
            HighlightLabel();
        }
    }

    private void RightCommand()
    {
        if (active)
        {
            selectedIndex = Math.Min(selectedIndex + 1, tvItems.Count - 1);
            HighlightLabel();
        }
    }

    private void SelectCommand()
    {
        tvItems[selectedIndex].Action(RemoteCommand.SELECT);
    }

    private void HighlightLabel()
    {
        for (int i = 0; i < tvItems.Count; i++)
        {
            if (i == selectedIndex) tvItems[i].Highlight(playActive);
            else tvItems[i].RemoveHighlighth(playActive);
        }
    }

    private void DiscOnPlayer()
    {
        playActive = true;
        HighlightLabel();
    }
}
