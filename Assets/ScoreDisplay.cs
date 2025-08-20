using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Transform player;
    public Text scoretext;
    private float InitialX;


	void Start()
	{
        	InitialX = player.position.x; 
        }

    	void Update()
    	{
        	if (gameHasEnded) 
        	{  
			float score = player.position.x - InitialX;
			scoretext.text = score.ToString("0");
	        }
	        else{
	        	scoretext.text = "Game Over";
	        }
	    }
    
    // Call this when player collides
         public void StopScore()
    	{
    	    	gameHasEnded = true;
    	}
}
	
