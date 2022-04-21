using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCManager : MonoBehaviour
{
    [SerializeField] List<Transform> AITokens = new List<Transform>(); 

    [SerializeField] SpawnMap spawnMap;

    [PunRPC]
    void DestoryBridge(Vector3 worldPosition)
    {
        // Initlaize 2 temp int
        int x = -1, z = -1;

        // Get the grid position of that sent worldPosition from the PC player
        spawnMap.gridSystem.GetGridXZ(worldPosition, out x, out z);

        // If there is an occupyingItem
        if (spawnMap.gridSystem.occupyingItemArray[x, z] != null)
        {
            // Debug message
            Debug.Log($"I am destorying {spawnMap.gridSystem.occupyingItemArray[x, z].name} at {x}, {z}");

            // Destory that gameObject
            Destroy(spawnMap.gridSystem.occupyingItemArray[x, z].gameObject);

            // Reset the occupying item
            spawnMap.gridSystem.occupyingItemArray[x, z] = null;

            // Reset the value in that grid
            spawnMap.gridSystem.SetGridValue(x, z, 0);
        }
    }

    [PunRPC]
    void UpdatePosition(int tokenID, Vector3 worldPosition)
    {
        // Get the reference from the PC player through the tokenID sent
        Transform token = AITokens[tokenID];

        // Initialize 2 temp int
        int x = -1, z = -1;

        // Get the grid position of that sent worldPosition from the PC player
        spawnMap.gridSystem.GetGridXZ(worldPosition, out x, out z);

        // Move that token to that gird position
        token.position = spawnMap.gridSystem.GetWorldPosition(x, z);
    }
}
