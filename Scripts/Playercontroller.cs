using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{ 
    public Animator animator;
    private float gravity = 9.8f;
    private float jumpForce = 10;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        // Movement
        _moveVector = Vector3.zero;

        if (Input.GetKey (KeyCode.W)) 
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey (KeyCode.S))
        {

            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        
        }
        if (_moveVector != Vector3.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
            
        
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            animator.SetBool("isGrounded", false) ;
        }
                
    }
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down*_fallVelocity*Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true) ;
        }

    }
}
