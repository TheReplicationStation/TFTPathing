using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public GameObject LevelPlaceholder;
    public List<GameObject> HexagonVoxels;
    public GameObject[,] HexagonGrid;

    public GameObject HexagonPrefab;
    public int Dimension;
    private int dimens;
    private float h_offset;
    private float v_offset;
    public float Prefab_Horizontal_Offset;
    public float Prefab_Vertical_Offset;

    public void Initialize_GridMaker()
    {
        dimens = Dimension;
        h_offset = Prefab_Horizontal_Offset;
        v_offset = Prefab_Vertical_Offset;
        HexagonVoxels = new List<GameObject>();
        HexagonGrid = new GameObject[Dimension, Dimension];
        CreateGrid();
    }

    private void Update()
    {
        if (dimens!= Dimension)
        {
            dimens = Dimension;
            foreach (var hex in HexagonVoxels)
                Destroy(hex);
            HexagonVoxels.Clear();
            CreateGrid();
        }
        else if (h_offset != Prefab_Horizontal_Offset)
        {
            h_offset = Prefab_Horizontal_Offset;
            foreach (var hex in HexagonVoxels)
                Destroy(hex);
            HexagonVoxels.Clear();
            CreateGrid();
        }
        else if (v_offset != Prefab_Vertical_Offset)
        {
            v_offset = Prefab_Vertical_Offset;
            foreach (var hex in HexagonVoxels)
                Destroy(hex);
            HexagonVoxels.Clear();
            CreateGrid();
        }
    }

    //apply loaded text file on grid
    private void CreateGrid()
    {
        //initialize vectors for level creation
        Vector3 start_position = Vector3.zero;
        Vector3 current_position = start_position;
        LevelPlaceholder.transform.position = current_position;
        int counter = 0;
        //create a square map
        for (int row = 0; row < Dimension; row++)
        {
            for (int col = 0; col < Dimension; col++)
            {
                //create new voxel
                GameObject new_voxel = Instantiate(HexagonPrefab, current_position, HexagonPrefab.transform.rotation, LevelPlaceholder.transform);
                new_voxel.GetComponent<Hexagon_Voxel>().Column = col;
                new_voxel.GetComponent<Hexagon_Voxel>().Row = row;
                HexagonVoxels.Add(new_voxel);
                HexagonGrid[row,col] = new_voxel;
                //change next voxel position
                current_position = new Vector3(current_position.x + Prefab_Horizontal_Offset, current_position.y, current_position.z);

                //voxel count
                counter++;
            }
            if(row%2==0)
                //change current poisition to place new voxel
                current_position = start_position + new Vector3(Prefab_Horizontal_Offset/2, 0, -(Prefab_Vertical_Offset/3)*(row+1));
            else
                current_position = start_position + new Vector3(0, 0, -(Prefab_Vertical_Offset / 3) * (row + 1));
        }
    }
}
