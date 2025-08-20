using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Transform player;
	public Text scoretext;
 // Update is called once per frame
    void Update()
    {
        scoretext.text = player.postion.x.ToString("0");
    }
}
