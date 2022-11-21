using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public GameObject AgentPrefab;
    public int SpawnNumber;

    public void CreateAgent_GridCoordinates(int row,int col,int team,int range,int speed)
    {
        GameObject new_agent = Instantiate(AgentPrefab);
        if (team == 0)
            new_agent.GetComponent<MeshRenderer>().material.color = Color.red;
        else
            new_agent.GetComponent<MeshRenderer>().material.color = Color.blue;
        new_agent.GetComponent<Agent_AI>().InitializeAgent_GridCoordinates(row,col,team,range,speed);
    }

    public void CreateAgent_GameObject(GameObject voxel, int team, int range, int speed)
    {
        GameObject new_agent = Instantiate(AgentPrefab);
        if (team == 0)
            new_agent.GetComponent<MeshRenderer>().material.color = Color.red;
        else
            new_agent.GetComponent<MeshRenderer>().material.color = Color.blue;
        new_agent.GetComponent<Agent_AI>().InitializeAgent_GameObject(voxel, team, range, speed);
    }
}
