using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    [SerializeField] private Vector2 playerCurrentPosition;
    public Vector2 currentCheckpointPosition;
    private TriggerEvent playerTriggerEvent;

    public PlayerData playerPositionData;

    private bool isDead = false;

    void Start()
    {
        playerTriggerEvent = GetComponent<TriggerEvent>();
        currentCheckpointPosition = new Vector2(-14f, -2f);

        if (playerPositionData == null)
        {
            playerPositionData = new PlayerData();
        }
    }

    void Update()
    {
        if (isDead)
        {
            Debug.Log("Player is dead, respawning...");
            Respawn();
            isDead = false;
        }
    }

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        Savepos(currentCheckpointPosition);
        Debug.Log($"New checkpoint position set to: {currentCheckpointPosition}");
    }

    public void OnTrap()
    {
        Debug.Log("Player hit a trap, setting isDead to true");
        isDead = true;
    }

    public void OnFinish()
    {
        playerPositionData.ResetData();
        Debug.Log("Game finished, resetting player data");
    }

    private void ChangePlayerPosition(Vector2 newPosition)
    {
        Debug.Log($"Changing player position to: {newPosition}");
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    private void Respawn()
    {
        Debug.Log($"Respawning player to checkpoint position: {currentCheckpointPosition}");
        ChangePlayerPosition(currentCheckpointPosition);
    }

    private void LoadPos()
    {
        playerCurrentPosition = playerPositionData.position;
        ChangePlayerPosition(playerCurrentPosition);
        Debug.Log($"Loaded player position: {playerCurrentPosition}");
    }

    private void Savepos(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
        Debug.Log($"Saved player position: {newPosition}");
    }
}

[System.Serializable]
public class PlayerData
{
    public Vector2 position;

    public void ResetData()
    {
        position = Vector2.zero;
        Debug.Log("Player data reset to default position");
    }
}
