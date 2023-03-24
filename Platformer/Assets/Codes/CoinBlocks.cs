using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlocks : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public GameObject coinParticleEffect;
    public Transform coinSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            
        }
        
    }
        
    
}
