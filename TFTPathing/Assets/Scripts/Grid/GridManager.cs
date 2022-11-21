using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int Column;
    public int Row;
    public List<GameObject> HexagonVoxels;
    public GameObject[,] HexagonGrid;
    public int Dimension;

    public void Initialize_GridManager()
    {
        HexagonGrid = this.GetComponent<GridMaker>().HexagonGrid;
        HexagonVoxels = this.GetComponent<GridMaker>().HexagonVoxels;
        Dimension = this.GetComponent<GridMaker>().Dimension;
    }

    void Update()
    {
        bool within_bounds = this.GetComponent<GridMaker>().Dimension > Row && this.GetComponent<GridMaker>().Dimension > Column;
        within_bounds = within_bounds && Row>=0 && Column>=0;
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && within_bounds)
            ColorVoxel_GridCoordinates(Row,Column);

        if (Input.GetKeyDown(KeyCode.Backspace))
            ClearGridColors();
    }

    public void ColorVoxel_GridCoordinates(int row,int col)
    {
        Color blue_color;
        ColorUtility.TryParseHtmlString("#00FFDA67", out blue_color);
        HexagonGrid[row, col].GetComponent<MeshRenderer>().material.color = blue_color;
    }

    public void ColorVoxel_GameObject(GameObject Voxel)
    {
        Color blue_color;
        ColorUtility.TryParseHtmlString("#00FFDA67", out blue_color);
        Voxel.GetComponent<MeshRenderer>().material.color = blue_color;
    }
    public void ReturnColorVoxel_GameObject(GameObject Voxel)
    {
        Voxel.GetComponent<MeshRenderer>().material.color = Color.white;
    }


    public void ClearGridColors()
    {
        foreach (var vox in HexagonGrid)
            vox.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public GameObject GetVoxel_GridCoordinates(int row, int col)
    {
        bool within_bounds = this.GetComponent<GridMaker>().Dimension > row && this.GetComponent<GridMaker>().Dimension > col;
        within_bounds = within_bounds && row >= 0 && col >= 0;
        if (within_bounds)
            return HexagonGrid[row, col];
        return null;
    }
}
