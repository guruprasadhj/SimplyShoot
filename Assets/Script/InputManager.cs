using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   PlayerInputControls playerControls;
   AnimatorManager animatorManager;
   public Vector2 movementInput;
   private float moveAmount;
   public float verticalInput;
   public float horizontalInput;
private void Awake(){ 
   animatorManager = GetComponent<AnimatorManager>();
}
   private void OnEnable()
   {
      if(playerControls == null)
      {
         playerControls = new PlayerInputControls();

         playerControls.PlayerMovement.Movement.performed += i  => movementInput = i.ReadValue<Vector2>();
      }
      playerControls.Enable();
   }
   private void OnDisable()
   {
      playerControls.Disable();
   }

   public void HandleAllInputs()
   {
      HandleMovementInput();
   }

   private void HandleMovementInput()
   {
      verticalInput = movementInput.y;
      horizontalInput = movementInput.x;
      moveAmount =Mathf.Clamp01(Mathf.Abs(verticalInput));
      print("dcugib"+moveAmount);
      print("verticalInput : "+Mathf.Abs(verticalInput));
      print("horizontalInput : "+horizontalInput);
      animatorManager.UpdateAnimatorValues(horizontalInput,verticalInput);
   }
}

