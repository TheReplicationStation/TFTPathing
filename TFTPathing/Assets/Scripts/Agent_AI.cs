using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_AI : MonoBehaviour
{
    private GridManager _GridManager;
    public int Row;
    public int Column;
    public int TargetRow;
    public int TargetColumn;
    public float PlayerHeight;

    public void InitializeAgent(GridManager gridmanager,int row,int col)
    {
        _GridManager = gridmanager;
        Row = row;
        Column = col;
        GameObject target_voxel = _GridManager.GetVoxel_GridCoordinates(Row, Column);
        this.transform.position = target_voxel.transform.position + new Vector3(0, PlayerHeight, 0);
        target_voxel.GetComponent<Hexagon_Voxel>().Occupied = true;
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

        this.transform.position = target_voxel.transform.position + new Vector3(0, PlayerHeight, 0);
        target_voxel.GetComponent<Hexagon_Voxel>().Occupied = true;
    }
}
