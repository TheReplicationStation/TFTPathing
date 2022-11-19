using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public GameObject AgentPrefab;
    public int SpawnNumber;
    public void Initialize_AgentManager(GridManager gridManager)
    {
        int counter = SpawnNumber;
        for (int row = 0; row < gridManager.Dimension; row++)
        {
            for (int col = 0; col < gridManager.Dimension; col++)
            {
                GameObject new_agent = Instantiate(AgentPrefab);
                new_agent.GetComponent<Agent_AI>().InitializeAgent(gridManager, row, col);
                counter--;
                if (counter == 0)
                    return;
            }
        }
    }
}
