using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerHub player;
    PState currentState;
	
	public Type GetStateType(){
		return currentState.GetType();
	}
	
	void Awake(){
		currentState = new PStateIdle(player, player.inputManager, player.attrManager.attrSet, player.GetComponent<Rigidbody>());
	}
	
	void Update(){
		currentState = currentState.Update();
	}
	
	void FixedUpdate(){		
		currentState = currentState.FixedUpdate();
	}
	
	public void Move(float horizontal, float vertical){
		currentState = currentState.Move(horizontal, vertical);
	}
	
	public void HitGround(float hitSpeed){
		currentState = currentState.HitGround(hitSpeed);
	}
	
	public void LeaveGround(){
		currentState = currentState.LeaveGround();
	}
	
	public void PressJump(){
		currentState = currentState.PressJump();
	}
	
	public void ReleaseJump(){
		currentState = currentState.ReleaseJump();
	}
}
