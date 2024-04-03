using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayerManager : MonoBehaviour
{
	public List<PlayerHub> players;
	
	void Awake(){
		players = new List<PlayerHub>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void AddPlayer(PlayerHub player){
		players.Add(player);
	}
}
