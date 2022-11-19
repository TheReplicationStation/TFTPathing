using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_AI : MonoBehaviour
{
    private GridManager _GridManager;
    public int Row;
    public int Column;
    public float PlayerHeight;

    public void InitializeAgent(GridManager gridmanager,int row,int col)
    {
        _GridManager = gridmanager;
        Row = row;
        Column = col;
        GameObject target_voxel = _GridManager.GetVoxel_GridCoordinates(Row, Column);
        this.transform.position = target_voxel.transform.position + new Vector3(0, PlayerHeight, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject target_voxel = _GridManager.GetVoxel_GridCoordinates(Row, Column);
            if (target_voxel != null)
                MoveAgent(target_voxel);
        }
    }

    public void MoveAgent(GameObject target_voxel)
    {
        this.transform.position = target_voxel.transform.position + new Vector3(0, PlayerHeight, 0);
    }
}
