using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridMaker _GridMaker;
    public GridManager _GridManager;
    public AgentManager _AgentManager;


    private void Awake()
    {
        _GridMaker.Initialize_GridMaker();
        _GridManager.Initialize_GridManager();
        _AgentManager.Initialize_AgentManager(_GridManager);
    }
}
