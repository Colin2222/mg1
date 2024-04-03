using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStateJumping : PState
{	
	float horizontal;
	float vertical;

	public PStateJumping(PState prev){
		this.player = prev.player;
		this.inputManager = prev.inputManager;
		this.attrSet = prev.attrSet;
		this.rigidbody = prev.rigidbody;
	}
	
    public override PState Update(){
		return this;
	}
	
	public override PState FixedUpdate(){
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
		rigidbody.AddForce(new Vector3(0, attrSet.jumpForce, 0), ForceMode.Impulse);
		return new PStateSoaring(this);
	}
	
    public override PState HitGround(float hitSpeed){
		return this;
	}
	
	public override PState Move(float horizontal, float vertical){
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
