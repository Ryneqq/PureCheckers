using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Turns : MonoBehaviour {

	private CreateKing CK;
    private Button temp;
    public Button BW;
    public Button WW;
    public Canvas GameCanvas;
    private GameObject Bimage;
    private GameObject Wimage;
    private bool WhiteWon = false;
	private bool BlackWon = false;

    // White i Black Wins Nie uwzgledniaja króli!!!!!!!! 

    void Start () {
		/*
		Variables.Turn = "White";
		Variables.Checker = "White";//*/
		Variables.Turn = "Black";
		Variables.Checker = "Black";
		CK = GameObject.Find("Main Camera").GetComponent<CreateKing>();
        Bimage = GameObject.Find("Black");
        Wimage = GameObject.Find("White");
        Wimage.SetActive(false);
    }

	void Update () {
		if (Variables.TurnChange && Variables.Turn == "White") {
            Wimage.SetActive(false); Bimage.SetActive(true);
            WhiteWins ();
			CK.CheckforKing(); // sprawdzmy czy moze nie zespawnowac króla
			Variables.AvJump = false; 		// **
			Variables.Turn = "Black"; 		// ** Zmiana rundy
			Variables.Checker = "Black";	// **
			Variables.TurnChange = false;	// **
			Jump(); // sprawdzamy czy w nowej rundzie dostępne są bicia
		}
		if (Variables.TurnChange && Variables.Turn == "Black") {
            Wimage.SetActive(true); Bimage.SetActive(false);
            BlackWins();
			CK.CheckforKing();
			Variables.AvJump = false;
			Variables.Turn = "White";
			Variables.Checker = "White";
			Variables.TurnChange = false;
			Jump();
		}
	}

    public void WonMethod(string Who)
    {
        if (Who == "White")
        {
            GameObject[] CheckerList = GameObject.FindGameObjectsWithTag("ButtonTag"); // w taki sposob się dostaje do obiektów
            foreach (GameObject Checker in CheckerList)
            {
                Checker.GetComponent<Button>().enabled = false;
            }
            GameObject[] SDList = GameObject.FindGameObjectsWithTag("SurrDraw"); // w taki sposob się dostaje do obiektów
            foreach (GameObject SD in SDList)
            {
                SD.GetComponent<Button>().enabled = false;
            }
            temp = (Button)Instantiate(WW, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(GameCanvas.transform, false);
        }
        if (Who == "Black")
        {
            GameObject[] CheckerList = GameObject.FindGameObjectsWithTag("ButtonTag"); // w taki sposob się dostaje do obiektów
            foreach (GameObject Checker in CheckerList)
            {
                Checker.GetComponent<Button>().enabled = false;
            }
            GameObject[] SDList = GameObject.FindGameObjectsWithTag("SurrDraw"); // w taki sposob się dostaje do obiektów
            foreach (GameObject SD in SDList)
            {
                SD.GetComponent<Button>().enabled = false;
            }
            temp = (Button)Instantiate(BW, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(GameCanvas.transform, false);
        }

    }

	private void BlackWins()
    {        // Nie uwzgledniaja króli!!!!!!!!
        bool Won = true;
		if (Variables.Player1 <= 0) {
			BlackWon = true;
		} else if (!BlackWon) {
			int x,y;
			for (int i=0; i<8; i++){
				for(int j=0; j<8; j++){
					if (!Won)
						break;
					if (i < 7 && j < 7 && Variables.Board [i, j] == 1) {
						y = i + 1;
						x = j + 1; // ruch w prawo
						if (Variables.Board [y, x] == 0) {// czy wystepuje normalny ruch
							Won = false;
						}
					}
					if (i < 7 && j > 0 && Variables.Board [i, j] == 1) {
						y = i + 1;
						x = j - 1; // ruch w prawo
						if (Variables.Board [y, x] == 0) {// czy wystepuje normalny ruch
							Won = false;
						}
					}
					if (i < 6 && j < 6 && Variables.Board [i, j] == 1) {
						y = i + 1;
						x = j + 1; // ruch w prawo
						if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) {// czy na drodze jest czarny pionek 
							++x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Won = false;
							}
						}
					}
					if (i < 6 && j > 1 &&Variables.Board [i, j] == 1) {
						y = i + 1;
						x = j - 1; // ruch w lewo
						if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy na drodze jest czarny pionek
							--x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Won = false;
							}
						}
					}
                    // ***************************** Krole *****************************

                    if (i < 7 && j < 7 && Variables.Board[i, j] == 11)
                    {
                        y = i + 1;
                        x = j + 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    if (i < 7 && j > 0 && Variables.Board[i, j] == 11)
                    {
                        y = i + 1;
                        x = j - 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    if (i > 0 && j > 0 && Variables.Board[i, j] == 11)
                    {
                        y = i - 1;
                        x = j - 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    if (i > 0 && j < 7 && Variables.Board[i, j] == 11)
                    {
                        y = i - 1;
                        x = j + 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    // ******* Bicie *******
                    if (i < 6 && j < 6 && Variables.Board[i, j] == 11)
                    {
                        y = i + 1;
                        x = j + 1; // ruch w prawo
                        if (Variables.Board[y, x] == 2 || Variables.Board[y, x] == 12)
                        {// czy na drodze jest czarny pionek 
                            ++x;
                            ++y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                    if (i < 6 && j > 1 && Variables.Board[i, j] == 11)
                    {
                        y = i + 1;
                        x = j - 1; // ruch w lewo
                        if (Variables.Board[y, x] == 2 || Variables.Board[y, x] == 12)
                        { // czy na drodze jest czarny pionek
                            --x;
                            ++y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                    if (i > 1 && j > 1 && Variables.Board[i, j] == 11)
                    {
                        y = i - 1;
                        x = j - 1; // ruch w prawo
                        if (Variables.Board[y, x] == 2 || Variables.Board[y, x] == 12)
                        {// czy na drodze jest czarny pionek 
                            --x;
                            --y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                    if (i > 1 && j < 6 && Variables.Board[i, j] == 11)
                    {
                        y = i - 1;
                        x = j + 1; // ruch w lewo
                        if (Variables.Board[y, x] == 2 || Variables.Board[y, x] == 12)
                        { // czy na drodze jest czarny pionek
                            ++x;
                            --y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                }
				if(!Won)
					break;
			}
			if (Won)
				BlackWon = true;
		}
		if (BlackWon) {
            Debug.Log("Czarne wygrały!!!");
            WonMethod("Black");
        }
	}

	private void WhiteWins(){
		bool Won = true;
		if (Variables.Player2 <= 0) {
			WhiteWon = true;
		} else if (!WhiteWon) {
			int x,y;
			for (int i=0; i<8; i++){
				for(int j=0; j<8; j++){
					if (!Won)
						break;
					if (i > 0 && j > 0 && Variables.Board [i, j] == 2) {
						y = i - 1;
						x = j - 1; // ruch w prawo
						if (Variables.Board [y, x] == 0) {// czy wystepuje normalny ruch
							Won = false;
						}
					}
					if (i > 0 && j < 7 && Variables.Board [i, j] == 2) {
						y = i - 1;
						x = j + 1; // ruch w prawo
						if (Variables.Board [y, x] == 0) {// czy wystepuje normalny ruch
							Won = false;
						}
					}
					if (i > 1 && j > 1 && Variables.Board [i, j] == 2) {
						y = i - 1;
						x = j - 1; // ruch w prawo
						if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) {// czy na drodze jest czarny pionek 
							--x;
							--y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Won = false;
							}
						}
					}
					if (i > 1 && j < 6 && Variables.Board [i, j] == 2) {
						y = i - 1;
						x = j + 1; // ruch w lewo
						if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy na drodze jest czarny pionek
							++x;
							--y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Won = false;
							}
						}
					}
                    // ***************************** Krole *****************************

                    if (i < 7 && j < 7 && Variables.Board[i, j] == 12)
                    {
                        y = i + 1;
                        x = j + 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    if (i < 7 && j > 0 && Variables.Board[i, j] == 12)
                    {
                        y = i + 1;
                        x = j - 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    if (i > 0 && j > 0 && Variables.Board[i, j] == 12)
                    {
                        y = i - 1;
                        x = j - 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    if (i > 0 && j < 7 && Variables.Board[i, j] == 12)
                    {
                        y = i - 1;
                        x = j + 1; // ruch w prawo
                        if (Variables.Board[y, x] == 0)
                        {// czy wystepuje normalny ruch
                            Won = false;
                        }
                    }
                    // ******* Bicie *******
                    if (i < 6 && j < 6 && Variables.Board[i, j] == 12)
                    {
                        y = i + 1;
                        x = j + 1; // ruch w prawo
                        if (Variables.Board[y, x] == 1 || Variables.Board[y, x] == 11)
                        {// czy na drodze jest czarny pionek 
                            ++x;
                            ++y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                    if (i < 6 && j > 1 && Variables.Board[i, j] == 12)
                    {
                        y = i + 1;
                        x = j - 1; // ruch w lewo
                        if (Variables.Board[y, x] == 1 || Variables.Board[y, x] == 11)
                        { // czy na drodze jest czarny pionek
                            --x;
                            ++y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                    if (i > 1 && j > 1 && Variables.Board[i, j] == 12)
                    {
                        y = i - 1;
                        x = j - 1; // ruch w prawo
                        if (Variables.Board[y, x] == 1 || Variables.Board[y, x] == 11)
                        {// czy na drodze jest czarny pionek 
                            --x;
                            --y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                    if (i > 1 && j < 6 && Variables.Board[i, j] == 12)
                    {
                        y = i - 1;
                        x = j + 1; // ruch w lewo
                        if (Variables.Board[y, x] == 1 || Variables.Board[y, x] == 11)
                        { // czy na drodze jest czarny pionek
                            ++x;
                            --y;
                            if (Variables.Board[y, x] == 0)
                            { // czy mozna go zbic
                                Won = false;
                            }
                        }
                    }
                }
				if(!Won)
					break;
			}
			if (Won)
				WhiteWon = true;
		}
		if (WhiteWon) {
			Debug.Log("Białe wygrały!!!");
            WonMethod("White");
        }
    }
	
	private void Jump(){
		if (Variables.Turn == "White") {
			int x = 0, y = 0;

			for (int i = 5; i >= 0; i--) { // nie ma sensu przeszukiwac 7 i 6 bo tam jest niemozliwe bicie
				for (int j = 5; j >= 0; j--) {
					if (Variables.Board [i, j] == 1) {
						y = i + 1;
						x = j + 1; // ruch w prawo
						if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) {// czy na drodze jest czarny pionek 
							++x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board [y - 2, x - 2] = 31;
								Debug.Log ("Rozpoznalem bicie bialych w prawo");
							}
						}
					}
				}
			}
			for (int i = 5; i >= 0; i--) { // nie ma sensu przeszukiwac 7 i 6 bo tam jest niemozliwe bicie
				for (int j = 2; j < 8; j++) { // natomiast bicie w ta strone jest niemozliwe
					if (Variables.Board [i, j] == 1) {
						y = i + 1;
						x = j - 1; // ruch w lewo
						if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy na drodze jest czarny pionek
							--x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board [y - 2, x + 2] = 31;
								Debug.Log ("Rozpoznalem bicie bialych w lewo");
							}
						}
					}
				}
			}
			for (int i = 5; i >= 0; i--) { // nie ma sensu przeszukiwac 7 i 6 bo tam jest niemozliwe bicie
				for (int j = 5; j >= 0; j--) {
					if (Variables.Board [i, j] == 11) {
						y = i + 1;
						x = j + 1; // ruch w prawo
						if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) {// czy na drodze jest czarny pionek 
							++x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board [y - 2, x - 2] = 311;
								Debug.Log ("Rozpoznalem bicie białego krola w przod w prawo");
							}
						}
					}
				}
			}
			for (int i = 5; i >= 0; i--) { // nie ma sensu przeszukiwac 7 i 6 bo tam jest niemozliwe bicie
				for (int j = 2; j < 8; j++) { // natomiast bicie w ta strone jest niemozliwe
					if (Variables.Board [i, j] == 11) {
						y = i + 1;
						x = j - 1; // ruch w lewo
						if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy na drodze jest czarny pionek
							--x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board [y - 2, x + 2] = 311;
								Debug.Log ("Rozpoznalem bicie białego krola w przod w lewo");
							}
						}
					}
				}
			}
			for (int i = 2; i < 8; i++) { // x = j , y = i pamietaj!
				for (int j = 2; j < 8; j++) {
					if(Variables.Board[i,j] == 11){
						y=i-1; x=j-1; // ruch w prawo
						if(Variables.Board[y,x] == 2 || Variables.Board[y,x] == 12)// czy na drodze jest biały pionek
						{ 
							--x; --y;
							if(Variables.Board[y,x] == 0) // czy mozna go zbic
							{
								Variables.AvJump = true;
								Variables.Board[y+2,x+2] = 311;
								Debug.Log("Rozpoznalem bicie białego króla w tył w lewo");
							}
						}
					}
				}
			}
			for (int i = 2; i < 8; i++) { // nie ma sensu przeszukiwac 0 i 1 bo tam jest niemozliwe bicie
				for (int j = 5; j >= 0; j--) { // natomiast bicie w ta strone jest niemozliwe
					if(Variables.Board[i,j] == 11){
						y=i-1; x=j+1; // ruch w lewo
						if(Variables.Board[y,x] == 2 || Variables.Board[y,x] == 12){ // czy na drodze jest czarny pionek
							++x; --y;
							if(Variables.Board[y,x] == 0){ // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board[y+2,x-2] = 311;
								Debug.Log("Rozpoznalem bicie białego króla w tył w prawo");
							}
						}
					}
				}
			}
		}
		if (Variables.Turn == "Black") {
			int x = 0, y = 0;

			for (int i = 2; i < 8; i++) { // x = j , y = i pamietaj!
				for (int j = 2; j < 8; j++) {
					if(Variables.Board[i,j] == 2){
						y=i-1; x=j-1; // ruch w prawo
						if(Variables.Board[y,x] == 1 || Variables.Board[y,x] == 11)// czy na drodze jest biały pionek
						{ 
							--x; --y;
							if(Variables.Board[y,x] == 0) // czy mozna go zbic
							{
								Variables.AvJump = true;
								Variables.Board[y+2,x+2] = 32;
								Debug.Log("Rozpoznalem bicie czarnych w lewo");
							}
						}
					}
				}
			}
			for (int i = 2; i < 8; i++) { // nie ma sensu przeszukiwac 0 i 1 bo tam jest niemozliwe bicie
				for (int j = 5; j >= 0; j--) { // natomiast bicie w ta strone jest niemozliwe
					if(Variables.Board[i,j] == 2){
						y=i-1; x=j+1; // ruch w lewo
						if(Variables.Board[y,x] == 1 || Variables.Board[y,x] == 11){ // czy na drodze jest czarny pionek
							++x; --y;
							if(Variables.Board[y,x] == 0){ // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board[y+2,x-2] = 32;
								Debug.Log("Rozpoznalem bicie czarnych w prawo");
							}
						}
					}
				}
			}
			for (int i = 2; i < 8; i++) { // x = j , y = i pamietaj!
				for (int j = 2; j < 8; j++) {
					if(Variables.Board[i,j] == 12){
						y=i-1; x=j-1; // ruch w prawo
						if(Variables.Board[y,x] == 1 || Variables.Board[y,x] == 11)// czy na drodze jest biały pionek
						{ 
							--x; --y;
							if(Variables.Board[y,x] == 0) // czy mozna go zbic
							{
								Variables.AvJump = true;
								Variables.Board[y+2,x+2] = 312;
								Debug.Log("Rozpoznalem bicie czarnego króla w tył w lewo");
							}
						}
					}
				}
			}
			for (int i = 2; i < 8; i++) { // nie ma sensu przeszukiwac 0 i 1 bo tam jest niemozliwe bicie
				for (int j = 5; j >= 0; j--) { // natomiast bicie w ta strone jest niemozliwe
					if(Variables.Board[i,j] == 12){
						y=i-1; x=j+1; // ruch w lewo
						if(Variables.Board[y,x] == 1 || Variables.Board[y,x] == 11){ // czy na drodze jest czarny pionek
							++x; --y;
							if(Variables.Board[y,x] == 0){ // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board[y+2,x-2] = 312;
								Debug.Log("Rozpoznalem bicie czarnego króla w tył w prawo");
							}
						}
					}
				}
			}
			for (int i = 5; i >= 0; i--) { // nie ma sensu przeszukiwac 7 i 6 bo tam jest niemozliwe bicie
				for (int j = 5; j >= 0; j--) {
					if (Variables.Board [i, j] == 12) {
						y = i + 1;
						x = j + 1; // ruch w prawo
						if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) {// czy na drodze jest czarny pionek 
							++x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board [y - 2, x - 2] = 312;
								Debug.Log ("Rozpoznalem bicie czarnego króla w przod w prawo");
							}
						}
					}
				}
			}
			for (int i = 5; i >= 0; i--) { // nie ma sensu przeszukiwac 7 i 6 bo tam jest niemozliwe bicie
				for (int j = 2; j < 8; j++) { // natomiast bicie w ta strone jest niemozliwe
					if (Variables.Board [i, j] == 12) {
						y = i + 1;
						x = j - 1; // ruch w lewo
						if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy na drodze jest czarny pionek
							--x;
							++y;
							if (Variables.Board [y, x] == 0) { // czy mozna go zbic
								Variables.AvJump = true;
								Variables.Board [y - 2, x + 2] = 312;
								Debug.Log ("Rozpoznalem bicie czarnego króla w przod w lewo");
							}
						}
					}
				}
			}
		}
	}
}
