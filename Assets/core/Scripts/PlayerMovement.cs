using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;    

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetAxisRaw("Horizontal") != 0){
            Move(new Vector3(Input.GetAxis("Horizontal"),0,0));
        }else if(Input.GetAxisRaw("Vertical") != 0) {
            Move(new Vector3(0,0,Input.GetAxis("Vertical")));
        }
        
        
    }


    void Move(Vector3 moveDirection){

        if (moveDirection != Vector3.zero) {
         var rotation = transform.rotation; 
         rotation.SetLookRotation(moveDirection); 
         transform.rotation = Quaternion.Slerp(transform.rotation,rotation,50f * Time.deltaTime);
        }

        controller.Move(moveDirection * 10f * Time.deltaTime);
    }


}
