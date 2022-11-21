using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_AI : MonoBehaviour
{
    private GridManager _GridManager;

    private int Row;
    private int Column;

    public int TargetRow;
    public int TargetColumn;
    public float Height;

    [Header("Agent Parameters")]
    public int Team;
    public int Range;
    public float MovementSpeed;

    public void InitializeAgent_GridCoordinates(int row,int col,int team,int range,int speed)
    {
        _GridManager = GameManager.Instance._GridManager;
        Row = row;
        Column = col;
        GameObject target_voxel = _GridManager.GetVoxel_GridCoordinates(Row, Column);
        this.transform.position = target_voxel.transform.position + new Vector3(0, Height, 0);
        target_voxel.GetComponent<Hexagon_Voxel>().Occupied = true;

        Team = team;
        Range = range;
        MovementSpeed = speed;
    }


    public void InitializeAgent_GameObject(GameObject target_voxel, int team, int range, int speed)
    {
        _GridManager = GameManager.Instance._GridManager;
        Row = target_voxel.GetComponent<Hexagon_Voxel>().Row;
        Column = target_voxel.GetComponent<Hexagon_Voxel>().Column;

        TargetRow = target_voxel.GetComponent<Hexagon_Voxel>().Row;
        TargetColumn = target_voxel.GetComponent<Hexagon_Voxel>().Column;

        this.transform.position = target_voxel.transform.position + new Vector3(0, Height, 0);
        target_voxel.GetComponent<Hexagon_Voxel>().Occupied = true;
        
        Team = team;
        Range = range;
        MovementSpeed = speed;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject target_voxel = _GridManager.GetVoxel_GridCoordinates(TargetRow, TargetColumn);
            if (target_voxel != null)
                if(target_voxel.GetComponent<Hexagon_Voxel>().Occupied ==false)
                    MoveAgent(target_voxel);
        }
    }

    public void MoveAgent(GameObject target_voxel)
    {
        GameObject current_voxel = _GridManager.GetVoxel_GridCoordinates(Row, Column);
        current_voxel.GetComponent<Hexagon_Voxel>().Occupied = false;

        this.transform.position = target_voxel.transform.position + new Vector3(0, Height, 0);
        target_voxel.GetComponent<Hexagon_Voxel>().Occupied = true;
    }
}
