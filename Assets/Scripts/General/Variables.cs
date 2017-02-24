using UnityEngine;
using System.Collections;

public struct Index{
	public int x, y;
}
public struct Coordinates{
	public float x, y;
}

public class Variables : MonoBehaviour {

	//public static GameObject[] CheckerList = new GameObject[24];
	public static float[] Vertical = new float[8] {-290.8f, -207.9f, -125.7f, -43.4f, 38.8f, 121.4f, 203.9f, 286.5f};
	public static float[] Horizontal = new float[8] {-289.4f, -206.8f, -125.0f, -42.0f, 40.3f, 123.3f, 204.3f, 287.3f};
	public static int[,] Board;
    public static float[] graveyardX = new float[4] { -540.0f, -450.0f, 450.0f, 540.0f };
    public static float[] graveyardY = new float[7] { 330.0f, 220.0f, 110.0f, 0.0f, -110.0f, -220.0f, -330.0f };
    //Białe bija czarne
    public static int graveyardK = 2; // x
    public static int graveyardJ = 0; // y 
    //Czarne
    public static int graveyardKBl = 1; // x
    public static int graveyardJBl = 6; // y 

    public static Index  BoardPosition;
	public static Coordinates BoardCoordinates;

	public static bool Destroyed = true;
	public static bool Moved = true;
	public static bool TurnChange = false;
	public static bool AvJump = false;
    public static bool WhiteDraw;
    public static bool BlackDraw;
    public static bool start = false;

	public static int Player1 = 12;
	public static int Player2 = 12;
	public static string Checker;
	public static string Turn;

    public static Index LastClicked;

	public static Index ReturnIndex(float Fx, float Fy){
			for (int i=0; i<8; i++) {
				if (Fx > Horizontal [i] - 5.0f && Fx < Horizontal[i] + 5.0f ){
					 BoardPosition.x = i;
				}
				if (Fy > Vertical [i] - 5.0f && Fy < Vertical[i] + 5.0f){ 
					 BoardPosition.y = i;
				}
			}
		return   BoardPosition;
	}
	public static Coordinates ReturnCoordinates(Index BPos){
		BoardCoordinates.x = Horizontal [BPos.x];
		BoardCoordinates.y = Vertical [BPos.y];
		return   BoardCoordinates;
	}
	public static void MarkedForDeath(Index StartP, Index FinalP){
		Index temp;
		if (Checker == "White" && Turn == "White") {
			temp.x = FinalP.x - StartP.x;
			temp.y = FinalP.y - StartP.y;
			if(temp.x == 2 && temp.y == 2){ // pojedyncze bicie w prawo
				Board[StartP.y+1, StartP.x+1] = 62;
			}
			if(temp.x == -2 && temp.y == 2){ // pojedyncze bicie w lewo
				Board[StartP.y+1, StartP.x-1] = 62;
			}
		}
		if (Checker == "Black" && Turn == "Black") {
			temp.x = FinalP.x - StartP.x;
			temp.y = FinalP.y - StartP.y;
			if(temp.x == 2 && temp.y == -2){ // w prawo
				Board[StartP.y-1, StartP.x+1] = 61;
			}
			if(temp.x == -2 && temp.y == -2){
				Board[StartP.y-1, StartP.x-1] = 61;
			}
		}
		if (Checker == "King" && Turn == "White") {
			temp.x = FinalP.x - StartP.x;
			temp.y = FinalP.y - StartP.y;
			if (temp.x == 2 && temp.y == 2) { // pojedyncze bicie w prawo
				Board [StartP.y + 1, StartP.x + 1] = 62;
			}
			if (temp.x == -2 && temp.y == 2) { // pojedyncze bicie w lewo
				Board [StartP.y + 1, StartP.x - 1] = 62;
			}
			if (temp.x == 2 && temp.y == -2) { // w prawo
				Board [StartP.y - 1, StartP.x + 1] = 62;
			}
			if (temp.x == -2 && temp.y == -2) {
				Board [StartP.y - 1, StartP.x - 1] = 62;
			}
		}
		if (Checker == "King" && Turn == "Black") {
			temp.x = FinalP.x - StartP.x;
			temp.y = FinalP.y - StartP.y;
			if (temp.x == 2 && temp.y == 2) { // pojedyncze bicie w prawo 
				Board [StartP.y + 1, StartP.x + 1] = 61;
			}
			if (temp.x == -2 && temp.y == 2) { // pojedyncze bicie w lewo
				Board [StartP.y + 1, StartP.x - 1] = 61;
			}
			if (temp.x == 2 && temp.y == -2) { // w prawo
				Board [StartP.y - 1, StartP.x + 1] = 61;
			}
			if (temp.x == -2 && temp.y == -2) {
				Board [StartP.y - 1, StartP.x - 1] = 61;
			}
		}
	}
}



















