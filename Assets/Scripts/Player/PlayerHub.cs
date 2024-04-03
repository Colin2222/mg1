using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{
	public PlayerInputManager inputManager;
	public PlayerInteractor interactor;
	public PlayerStateManager stateManager;
	public PlayerAttributeManager attrManager;
	public PlayerPhysics physics;
	
	public Rigidbody rb;
	
    // Start is called before the first frame update
    void Start()
    {
        ScenePlayerManager pm = GameObject.FindWithTag("PlayerManager").GetComponent<ScenePlayerManager>();
		if(pm != null){
			pm.AddPlayer(this);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
