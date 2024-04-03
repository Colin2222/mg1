using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
	public PlayerHub player;
	public PlayerStateManager stateManager;
	public PlayerInteractor interactor;
	
	// locking player input
	bool locked = false;
	
	// in ui
	//bool inUI = false;
	
	// joystick movement
	public float horizontal;
	public float vertical;
	
	// button pressing
    private bool jumpPressed = false;
    private bool jumpJustPressed = false;
	private bool menuUpPressed = false;
	private bool menuUpJustPressed = false;
	private bool menuDownPressed = false;
	private bool menuDownJustPressed = false;
	private bool menuRightPressed = false;
	private bool menuRightJustPressed = false;
	private bool menuLeftPressed = false;
	private bool menuLeftJustPressed = false;
	private bool menuPageRightPressed = false;
	private bool menuPageRightJustPressed = false;
	private bool menuPageLeftPressed = false;
	private bool menuPageLeftJustPressed = false;
	private bool interactPressed = false;
	private bool interactJustPressed = false;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if(!locked){
			stateManager.Move(horizontal, vertical);
		}
		
        jumpJustPressed = false;
		menuUpJustPressed = false;
		menuDownJustPressed = false;
		menuRightJustPressed = false;
		menuLeftJustPressed = false;
		menuPageRightJustPressed = false;
		menuPageLeftJustPressed = false;
		interactJustPressed = false;
    }
	
	public void LockPlayer(){
		locked = true;
	}
	
	public void UnlockPlayer(){
		locked = false;
	}
	
	// controller button methods
    private void OnMove(InputValue value){
        Vector2 vector = value.Get<Vector2>();

        horizontal = vector.x;
        vertical = vector.y;
    }
	
	private void OnJump(){
        jumpPressed = !jumpPressed;
        jumpJustPressed = jumpPressed;
		
		if(!locked){
			if(jumpPressed){
				stateManager.PressJump();
			} else{
				stateManager.ReleaseJump();
			}
		}
    }
	
	private void OnStartGame(){
		
	}
	
	private void OnMenuUp(){
		menuUpPressed = !menuUpPressed;
		menuUpJustPressed = menuUpPressed;
	}
	
	private void OnMenuDown(){
		menuDownPressed = !menuDownPressed;
		menuDownJustPressed = menuDownPressed;
	}
	
	private void OnMenuRight(){
		menuRightPressed = !menuRightPressed;
		menuRightJustPressed = menuRightPressed;
	}
	
	private void OnMenuLeft(){
		menuLeftPressed = !menuLeftPressed;
		menuLeftJustPressed = menuLeftPressed;
	}
	
	private void OnMenuPageRight(){
		menuPageRightPressed = !menuPageRightPressed;
		menuPageRightJustPressed = menuPageRightPressed;
	}
	
	private void OnMenuPageLeft(){
		menuPageLeftPressed = !menuPageLeftPressed;
		menuPageLeftJustPressed = menuPageLeftPressed;
	}
	
	private void OnInteract(){
		interactPressed = !interactPressed;
		interactJustPressed = interactPressed;
		
		if(!locked && interactJustPressed){
			interactor.Interact();
		}
	}
}
