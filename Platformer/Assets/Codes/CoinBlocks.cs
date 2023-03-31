using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlocks : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public GameObject coin;
    public GameObject coinParticleEffect;
    public Transform coinSpawnPoint;

    public AudioSource _audioSource;
    public AudioClip hitBlock;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            // _audioSource.PlayOneShot(hitBlock);
            AudioSource.PlayClipAtPoint(hitBlock, gameObject.transform.position);
            Instantiate(coin, coinSpawnPoint.position, Quaternion.identity);
            Instantiate(coinParticleEffect, coinSpawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
            
    }
        
}
        
    

