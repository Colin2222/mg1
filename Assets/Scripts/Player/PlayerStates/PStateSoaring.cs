using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStateSoaring : PState
{	
	float horizontal;
	float vertical;

	public PStateSoaring(PState prev){
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
		
		// apply moving force for in the air (less than on ground?)
		rigidbody.AddForce(new Vector3(horizontal, 0.0f, vertical).normalized * attrSet.airMoveForce, ForceMode.Force);
		
		// apply ground drag
		Vector3 forceVector = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z);
		rigidbody.AddForce(forceVector * attrSet.groundDrag * -1.0f, ForceMode.Force);
		
		// clamp x-z plane movement to movement speed limits
		Vector3 xzVector = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z);
		if(xzVector.magnitude > attrSet.maxAirXZSpeed){
			xzVector = xzVector.normalized * attrSet.maxAirXZSpeed;
			rigidbody.velocity = new Vector3(xzVector.x, rigidbody.velocity.y, xzVector.z);
		}
		return this;
	}
	
    public override PState HitGround(float hitSpeed){
		return new PStateMoving(this);
	}
	
	public override PState Move(float horizontal, float vertical){
		this.horizontal = horizontal;
		this.vertical = vertical;
		
		return this;
	}
	
	public override PState PressJump(){
		return this;
	}
	
	public override PState ReleaseJump(){
		return this;
	}
	
	public override PState LeaveGround(){
		return this;
	}
}
