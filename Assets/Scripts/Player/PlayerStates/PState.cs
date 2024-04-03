using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PState
{
	public PlayerHub player;
	public PlayerInputManager inputManager;
	public PlayerAttributeSet attrSet;
	public Rigidbody rigidbody;
	public float timeSinceLastGroundHit;
	public float lastGroundHitSpeed;
	
	public abstract PState Update();
	public abstract PState FixedUpdate();
	public abstract PState Move(float horizontal, float vertical);
	public abstract PState HitGround(float hitSpeed);
	public abstract PState LeaveGround();
	public abstract PState PressJump();
	public abstract PState ReleaseJump();
	
	protected void HandleGravity(){
		rigidbody.AddForce(attrSet.gravity * Vector3.down, ForceMode.Acceleration);
	}
}
