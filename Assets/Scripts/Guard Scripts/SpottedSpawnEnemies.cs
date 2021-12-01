using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottedSpawnEnemies : MonoBehaviour
{
    
    Guard guardSpotsPlayer;
    [SerializeField] GameObject[] enemyPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(guardSpotsPlayer.CanSeePlayer())
        {
            guardSpotsPlayer.spotLight.color = Color.red;
        }
    }
}
