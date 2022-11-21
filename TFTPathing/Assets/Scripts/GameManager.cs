using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridMaker _GridMaker;
    public GridManager _GridManager;
    public GridInteraction _GridInteraction;
    public AgentManager _AgentManager;
    public MenuManager _MenuManager;
    //make this an instance so it can exist in all scenes as one entity without confusion
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        _GridMaker.Initialize_GridMaker();
        _GridManager.Initialize_GridManager();
        _GridInteraction.Initialize_GridInteraction();
        //_MenuManager.Initialize_MenuManager();
    }
}
