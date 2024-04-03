using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttributeSet
{
    public float moveForce;
	public float airMoveForce;
	public float maxRunSpeed;
	public float maxAirXZSpeed;
	public float groundDrag;
	public float jumpForce;
	public float groundedRaycastDist;
	public float gravity;
}
