using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_AI : MonoBehaviour
{
    public GridManager _GridManager;
    public int Row;
    public int Column;
    public float PlayerHeight;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject target_voxel = _GridManager.GetVoxel_GridCoordinates(Row, Column);
            if(target_voxel!=null)
                this.transform.position = target_voxel.transform.position + new Vector3(0, PlayerHeight, 0);
        }
    }
}
