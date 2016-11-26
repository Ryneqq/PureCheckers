using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public void Clicked(){
        Variables.Player1 = 12;
        Variables.Player2 = 12;
        Variables.Destroyed = true;
        Variables.Moved = true;
        Variables.TurnChange = false;
        Variables.AvJump = false;
        Variables.graveyardK = 2; // x
        Variables.graveyardJ = 0; // y 
        Variables.graveyardKBl = 1; // x
        Variables.graveyardJBl = 6; // y 
        Application.LoadLevel ("Gameplay");
	}
}
