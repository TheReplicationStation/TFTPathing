using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private int _ButtonSelected;
    
    public TMP_Dropdown TeamDropdown;
    public TMP_InputField AgentRange;
    public TMP_InputField AgentMovementSpeed;

    private void Start()
    {
        _ButtonSelected = -1;
    }

    public void SpawnAgent(GameObject voxel)
    {
        if (_ButtonSelected == 0) {
            int range;
            int speed;
            if (AgentRange.text == "")
                range = 1;
            else
                range = Int32.Parse(AgentRange.text);

            if (AgentMovementSpeed.text == "")
                speed = 1;
            else
                speed = Int32.Parse(AgentMovementSpeed.text);
            Debug.Log(TeamDropdown.value + " " +range +" "+speed);
            if(!voxel.GetComponent<Hexagon_Voxel>().Occupied)
                GameManager.Instance._AgentManager.CreateAgent_GameObject(voxel, TeamDropdown.value,range,speed);
        }
    }

    public void Select_Button(int button_pressed)
    {
        if (_ButtonSelected != -1)
            _ButtonSelected = -1;
        else
            _ButtonSelected = button_pressed;
    }
}
