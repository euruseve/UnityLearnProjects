using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem runParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    
    private AudioSource _playerAudio;
    private Rigidbody _playerRb;
    private Animator _playerAnimator;
    private bool _isOnGround = true; 
    private bool _gameOver; 

    public bool GameOver {
        get => _gameOver;
    }
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnimator.SetTrigger("Jump_trig");
            runParticle.Stop();
            _playerAudio.PlayOneShot(jumpSound, 0.4f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            runParticle.Play();
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            _playerAudio.PlayOneShot(crashSound, 0.4f);
            runParticle.Stop();
        }
    }
}
