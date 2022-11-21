using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInteraction : MonoBehaviour
{
    private GridManager _GridManager;
    private GameObject previous_voxel;
    public void Initialize_GridInteraction()
    {
        _GridManager = this.GetComponent<GridManager>();
    }

    private void Update()
    {
        //raycast from screen to mouse
        Ray camera_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 6;
        if (Physics.Raycast(camera_ray, out RaycastHit hit, Mathf.Infinity,layerMask))
        {
            if (previous_voxel != hit.collider.gameObject)
            {
                if(previous_voxel!=null)
                    _GridManager.ReturnColorVoxel_GameObject(previous_voxel);
                _GridManager.ColorVoxel_GameObject(hit.collider.gameObject);
                //Debug.Log(hit.transform.gameObject.name);
                previous_voxel = hit.collider.gameObject;
            }
        }

    }
}
