using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
      CharacterController _controller;

      private float _verticalVelocitiy;

      private float _terminalVelocitiy = 53.0f;

      public float moveSpeed = 6.0f;

      public float gravity = -15.0f;

      public bool grounded = true;

      public float groundedOffset = -0.14f;

      public float groundedRadius = 0.28f;

     
     void Awake()
     {
         _controller = GetComponent<CharacterController>();
        
     }

     //Sum of all forces acting on the character
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          gameObject.GetComponent<Animator>().SetTrigger("isJumping");
          
        }

        Move();
        HandleGravitiy();
    }

   

    void HandleGravitiy(){

      if (grounded){

        if (_verticalVelocitiy < 0.0f){
          _verticalVelocitiy = 0.0f;
        }
      }

      if(_verticalVelocitiy < _terminalVelocitiy){
        _verticalVelocitiy += gravity * Time.deltaTime;
      }

    }

    void Move() {
      
     _controller.Move(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}
