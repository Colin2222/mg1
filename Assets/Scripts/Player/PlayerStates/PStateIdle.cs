using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStateIdle : PState
{
	public PStateIdle(PlayerHub player, PlayerInputManager inputManager, PlayerAttributeSet attr, Rigidbody rigidbody){
		this.player = player;
		this.inputManager = inputManager;
		this.attrSet = attr;
		this.rigidbody = rigidbody;
	}
	
	public PStateIdle(PState prev){
		this.player = prev.player;
		this.inputManager = prev.inputManager;
		this.attrSet = prev.attrSet;
		this.rigidbody = prev.rigidbody;
	}
	
    public override PState Update(){
		return this;
	}
	
	public override PState FixedUpdate(){
		//handle gravity
		this.HandleGravity();
		
		PlayerAttributeSet attr = this.attrSet;
		Rigidbody rb = this.rigidbody;
		
		// apply ground drag force
		Vector3 forceVector = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
		rb.AddForce(forceVector * attr.groundDrag * -1.0f, ForceMode.Force);
		return this;
	}
	
    public override PState HitGround(float hitSpeed){
		return this;
	}
	
	public override PState Move(float horizontal, float vertical){
		if(Mathf.Abs(horizontal) > 0.0f || Mathf.Abs(vertical) > 0.0f){
			return new PStateMoving(this);
		}
		return this;
	}
	
	public override PState PressJump(){
		if(Physics.Raycast(rigidbody.transform.position, rigidbody.transform.TransformDirection(Vector3.down), attrSet.groundedRaycastDist , LayerMask.GetMask("PhysicsEnvironment"))){
			return new PStateJumping(this);
		}
		return this;
	}
	
	public override PState ReleaseJump(){
		return this;
	}
	
	public override PState LeaveGround(){
		return this;
	}
}
