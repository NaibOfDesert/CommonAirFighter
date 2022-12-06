using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Transform parent;
    [SerializeField] int value = 10;
    
    ScoreBoard scoreBoard;
    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(explosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        scoreBoard.IncreaseScore(value);
        Destroy(gameObject); 
    }


}
