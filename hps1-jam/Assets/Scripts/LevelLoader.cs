using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        RespawnPlayer();

        Debug.Log("Resetting level!");
    }

    void RespawnPlayer()
    {
        player.ResetPlayer();
        Respawn playerRespawn = player.GetComponent<Respawn>();
        if (playerRespawn)
        {
            playerRespawn.RespawnObject();
            Debug.Log("Respawning player!");
        }
    }
}
