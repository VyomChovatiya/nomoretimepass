using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	public PlayerMovement movement;
	public Transform player;
	public ScoreScript scoreScript;

 	void OnCollisionEnter(UnityEngine.Collision collisionInfo){
    		if (collisionInfo.collider.tag == "Obstacle"F) {
    		movement.enabled = false;
    		scoreScript.StopScore();
    		FindObjectOfType<GameManager>().Endgame();
    	}
    }
}
