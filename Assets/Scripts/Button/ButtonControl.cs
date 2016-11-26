using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {
	private CreateButton CB;
	private float positionX;
	private float positionY;
	private Index BoardPresence, CheckIndex, StartIndex;
	private int WhichOne; 
	private bool KingJumpin = false, NormalJumpin = false;


public void Clicked(){

		Variables.Moved = true; // dokonalismy wyboru ruchu
		Destroy (this.gameObject);// niszczymy nacisnietego active buttona
		CB=GameObject.Find("Main Camera").GetComponent<CreateButton>();
		StartIndex = CB.StartingPostion;
		positionX = GetComponent<RectTransform>().anchoredPosition.x;
		positionY = GetComponent<RectTransform>().anchoredPosition.y;
		CB.MoveYourAss.anchoredPosition = new Vector2 (positionX,positionY);
		BoardPresence = Variables.ReturnIndex (positionX, positionY);

		if(Variables.Board [StartIndex.y, StartIndex.x] == 311 || Variables.Board [StartIndex.y, StartIndex.x] == 312){
			KingJumpin = true;
		} // Jezeli król bil
		if(Variables.Board [StartIndex.y, StartIndex.x]==31 || Variables.Board [StartIndex.y, StartIndex.x] == 32){
			NormalJumpin = true;
		} // Normalny pionek bił

		// wyszukuje wszystkie zaznaczone pionki i zmieniam je na podstawowe
		for (int i=0; i<8; i++) {
			for (int j=0; j<8; j++) {
				if(Variables.Board [i, j] == 31)
					Variables.Board [i, j] = 1;
				if(Variables.Board [i, j] == 32)
					Variables.Board [i, j] = 2;
				if(Variables.Board [i, j] == 311)
					Variables.Board [i, j] = 11;
				if(Variables.Board [i, j] == 312)
					Variables.Board [i, j] = 12;
			}
		}
		WhichOne = Variables.Board [StartIndex.y, StartIndex.x];
		Variables.Board [StartIndex.y, StartIndex.x] = 0;
		Variables.Board [BoardPresence.y, BoardPresence.x] = WhichOne;

		if (Variables.Checker == "King" && KingJumpin) { // Jezeli skoczyl to zbij pionki
			if (Variables.Turn == "White") {
				Variables.Board [BoardPresence.y, BoardPresence.x] = 311;
				Variables.MarkedForDeath (StartIndex, BoardPresence);
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				foreach (GameObject Checker in CheckerList) {
					positionX = Checker.GetComponent<RectTransform> ().anchoredPosition.x;
					positionY = Checker.GetComponent<RectTransform> ().anchoredPosition.y;
					CheckIndex = Variables.ReturnIndex (positionX, positionY);
					if (Variables.Board [CheckIndex.y, CheckIndex.x] == 62) {
						Variables.Board [CheckIndex.y, CheckIndex.x] = 0;
                        //Destroy (Checker.gameObject);
                        Checker.gameObject.tag = "dead";
                        Checker.GetComponent<Button>().enabled = false;
                        Checker.GetComponent<RectTransform>().anchoredPosition = new Vector2(Variables.graveyardX[Variables.graveyardK], Variables.graveyardY[Variables.graveyardJ]);
                        Variables.graveyardJ++;
                        if (Variables.graveyardJ > 5)
                        {
                            Variables.graveyardJ = 0;
                            Variables.graveyardK++;
                        }
                        Variables.Player1--;
					}
				}
			} else if (Variables.Turn == "Black") {
				Variables.Board [BoardPresence.y, BoardPresence.x] = 312;
				Variables.MarkedForDeath (StartIndex, BoardPresence);
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				foreach (GameObject Checker in CheckerList) {
					positionX = Checker.GetComponent<RectTransform> ().anchoredPosition.x;
					positionY = Checker.GetComponent<RectTransform> ().anchoredPosition.y;
					CheckIndex = Variables.ReturnIndex (positionX, positionY);
					if (Variables.Board [CheckIndex.y, CheckIndex.x] == 61) {
						Variables.Board [CheckIndex.y, CheckIndex.x] = 0;
                        //Destroy (Checker.gameObject);
                        Checker.gameObject.tag = "dead";
                        Checker.GetComponent<Button>().enabled = false;
                        Checker.GetComponent<RectTransform>().anchoredPosition = new Vector2(Variables.graveyardX[Variables.graveyardKBl], Variables.graveyardY[Variables.graveyardJBl]);
                        Variables.graveyardJBl--;
                        if (Variables.graveyardJBl < 1)
                        {
                            Variables.graveyardJBl = 6;
                            Variables.graveyardKBl--;
                        }
                        Variables.Player2--;
                    }
				}
			}
			// Wyrzuć guziki które są już nie potrzebne
			GameObject[] ActiveList = GameObject.FindGameObjectsWithTag ("Active");
			foreach (GameObject Act in ActiveList) {
				Destroy (Act.gameObject);
			}

			ContinueBeating ();

			if (KingJumpin) { // Jezeli istnieje nastepne bicie to wylacz wszystkie mozliwe guziki
				Variables.Destroyed = true;
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				Button temp;
				foreach (GameObject Checker in CheckerList) {
					temp = Checker.GetComponent<Button> ();
					temp.enabled = false;
				}
				CB.Initialize (BoardPresence, ref CB.MoveYourAss);
			} else { // Jezeli nie to włacz guziki, zmien ture
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				Button temp;
				foreach (GameObject Checker in CheckerList) {
					temp = Checker.GetComponent<Button> ();
					temp.enabled = true;
				}
				if (Variables.Turn == "White") {
					Variables.Board [BoardPresence.y, BoardPresence.x] = 11;
				} else if (Variables.Turn == "Black") {
					Variables.Board [BoardPresence.y, BoardPresence.x] = 12;
				}
				ActiveList = GameObject.FindGameObjectsWithTag ("Active");
				foreach (GameObject Act in ActiveList) {
					Destroy (Act.gameObject);
				}
				Variables.TurnChange = true; //zmiana rundy
			}

		} else if ((Variables.Checker == "White" || Variables.Checker == "Black") && NormalJumpin == true) { // Jezeli pionek nie jest krolem
			if (Variables.Checker == "White" && Variables.Turn == "White") {
				Variables.MarkedForDeath (StartIndex, BoardPresence);
				Variables.Board [BoardPresence.y, BoardPresence.x] = 31;
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				foreach (GameObject Checker in CheckerList) {
					positionX = Checker.GetComponent<RectTransform> ().anchoredPosition.x;
					positionY = Checker.GetComponent<RectTransform> ().anchoredPosition.y;
					CheckIndex = Variables.ReturnIndex (positionX, positionY);
					if (Variables.Board [CheckIndex.y, CheckIndex.x] == 62) {
						Variables.Board [CheckIndex.y, CheckIndex.x] = 0;
                        //Destroy (Checker.gameObject);
                        Checker.gameObject.tag = "dead";
                        Checker.GetComponent<Button>().enabled = false;
                        Checker.GetComponent<RectTransform>().anchoredPosition = new Vector2(Variables.graveyardX[Variables.graveyardK], Variables.graveyardY[Variables.graveyardJ]);
                        Variables.graveyardJ++;
                        if (Variables.graveyardJ > 5)
                        {
                            Variables.graveyardJ = 0;
                            Variables.graveyardK++;
                        }
                        Variables.Player1--;
					}
				}
			} 
			if (Variables.Checker == "Black" && Variables.Turn == "Black") {
				Variables.MarkedForDeath (StartIndex, BoardPresence);
				Variables.Board [BoardPresence.y, BoardPresence.x] = 32;
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				foreach (GameObject Checker in CheckerList) {
					positionX = Checker.GetComponent<RectTransform> ().anchoredPosition.x;
					positionY = Checker.GetComponent<RectTransform> ().anchoredPosition.y;
					CheckIndex = Variables.ReturnIndex (positionX, positionY);
					if (Variables.Board [CheckIndex.y, CheckIndex.x] == 61) {
						Variables.Board [CheckIndex.y, CheckIndex.x] = 0;
                        //Destroy (Checker.gameObject);
                        Checker.gameObject.tag = "dead";
                        Checker.GetComponent<Button>().enabled = false;
                        Checker.GetComponent<RectTransform>().anchoredPosition = new Vector2(Variables.graveyardX[Variables.graveyardKBl], Variables.graveyardY[Variables.graveyardJBl]);
                        Variables.graveyardJBl--;
                        if (Variables.graveyardJBl < 1)
                        {
                            Variables.graveyardJBl = 6;
                            Variables.graveyardKBl--;
                        }
                        Variables.Player2--;
					}
				}
			}
			
			GameObject[] ActiveList = GameObject.FindGameObjectsWithTag ("Active");
			foreach (GameObject Act in ActiveList) {
				Destroy (Act.gameObject);
			}

			ContinueBeating ();

			if (NormalJumpin) { // Jezeli istnieje nastepne bicie to wylacz wszystkie mozliwe guziki
				Variables.Destroyed = true;
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				Button temp;
				foreach (GameObject Checker in CheckerList) {
					temp = Checker.GetComponent<Button> ();
					temp.enabled = false;
				}
				CB.Initialize (BoardPresence, ref CB.MoveYourAss);
			} else {
				GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
				Button temp;
				foreach (GameObject Checker in CheckerList) {
					temp = Checker.GetComponent<Button> ();
					temp.enabled = true;
				}
				if (Variables.Turn == "White") {
					Variables.Board [BoardPresence.y, BoardPresence.x] = 1;
				} else if (Variables.Turn == "Black") {
					Variables.Board [BoardPresence.y, BoardPresence.x] = 2;
				}
				ActiveList = GameObject.FindGameObjectsWithTag ("Active");
				foreach (GameObject Act in ActiveList) {
					Destroy (Act.gameObject);
				}
				Variables.TurnChange = true; //zmiana rundy
			}

		} else { // jezeli nie występuje bicie
			Variables.Destroyed = false; 
			Variables.TurnChange = true; //zmiana rundy
		}
	}
	private void ContinueBeating(){

		// resetujemy boole by sprawdzić czy istnieje bicie
		Variables.AvJump = false;
		KingJumpin = false;
		NormalJumpin = false;

		// $ $ $ Czy biały król ma Bicie $ $ $
		int x = BoardPresence.x, y = BoardPresence.y;
		if (Variables.Board [BoardPresence.y, BoardPresence.x] == 311) {
			//======== Prawo Przod =========
			if (x < 6 && y < 6) {
				++x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac bicie
					++x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			//======== Lewo Przod =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x > 1 && y < 6) {
				--x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac nastepne bicie
					--x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			//======== Prawo Tył =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x < 6 && y > 1) {
				++x;
				--y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) {// czy na drodze jest czarny pionek 
					++x;
					--y;
					if (Variables.Board [y, x] == 0) { // czy mozna go zbic
						Variables.AvJump = true;
					}
				}
			}
			//======== Lewo Tył =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x > 1 && y > 1) {
				--x;
				--y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac nastepne bicie
					--x;
					--y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			if (Variables.AvJump)
				KingJumpin = true;
		}


		// $ $ $ Czy Czarny król ma Bicie $ $ $
		if (Variables.Board [BoardPresence.y, BoardPresence.x] == 312) {
			//======== Prawo Przod =========
			if (x < 6 && y < 6) {
				++x;
				++y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac bicie
					++x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			//======== Lewo Przod =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x > 1 && y < 6) {
				--x;
				++y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac nastepne bicie
					--x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			//======== Prawo Tył =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x < 6 && y > 1) {
				++x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) {// czy na drodze jest czarny pionek 
					++x;
					--y;
					if (Variables.Board [y, x] == 0) { // czy mozna go zbic
						Variables.AvJump = true;
					}
				}
			}
			//======== Lewo Tył =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x > 1 && y > 1) {
				--x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac nastepne bicie
					--x;
					--y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			if (Variables.AvJump)
				KingJumpin = true;
		}

		// $ $ $ Czy Biały pionek ma Bicie $ $ $
		if (Variables.Board [BoardPresence.y, BoardPresence.x] == 31) {
			//======== Prawo Przod =========
			if (x < 6 && y < 6) {
				++x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac bicie
					++x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			//======== Lewo Przod =========
			x = BoardPresence.x;
			y = BoardPresence.y;
			if (x > 1 && y < 6) {
				--x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac nastepne bicie
					--x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			if (Variables.AvJump)
				NormalJumpin = true;
		}
		// $ $ $ Czy Czarny pionek ma Bicie $ $ $
		if (Variables.Board [BoardPresence.y, BoardPresence.x] == 32) {
			//======== Prawo Tył =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x < 6 && y > 1) {
				++x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) {// czy na drodze jest czarny pionek 
					++x;
					--y;
					if (Variables.Board [y, x] == 0) { // czy mozna go zbic
						Variables.AvJump = true;
					}
				}
			}
			//======== Lewo Tył =========
			x = BoardPresence.x; y = BoardPresence.y;
			if (x > 1 && y > 1) {
				--x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac nastepne bicie
					--x;
					--y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						Variables.AvJump = true;
					}
				}
			}
			if (Variables.AvJump)
				NormalJumpin = true;
		}

	}

	void Update(){
		if (!Variables.Destroyed) {
			Destroy (this.gameObject);
		}
	}
}
