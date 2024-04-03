using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
	public PlayerHub player;
	public Rigidbody rb;
	LayerMask physicsLayer;
	
	void Awake(){
		physicsLayer = LayerMask.NameToLayer("PhysicsEnvironment");
	}
	
    void OnCollisionEnter(Collision collision){
        LayerMask layer = collision.gameObject.layer;
        Vector3 otherPos = collision.transform.position;
		
		if(layer == physicsLayer){
			player.stateManager.HitGround(collision.relativeVelocity.y);
		}
    }
}
