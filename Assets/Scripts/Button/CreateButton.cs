using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour {

	public Button Activation;
	private Button temp;
	public Canvas GameCanvas;
	public RectTransform MoveYourAss;

	private Index MoveP;
	public Index StartingPostion;
	private Coordinates MoveDirection;
	
	public void Initialize (Index Start, ref RectTransform move) {

		Variables.Destroyed = true;
		MoveYourAss = move;
		StartingPostion = Start;

		if (Variables.Checker == "White" && Variables.Turn == "White" && !Variables.AvJump) {
			//======== Prawo =========
			MoveP.x = Start.x + 1;//x rosnie
			MoveP.y = Start.y + 1;// y rosnie
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			//======== Lewo =========
			MoveP.x = Start.x - 1;//x rosnie
			MoveP.y = Start.y + 1;//y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
		}
		//=============================== Biale Bija ================================
		if (Variables.Checker == "White" && Variables.Turn == "White" && Variables.AvJump && Variables.Board [Start.y, Start.x] == 31) {
			int x = Start.x, y = Start.y;
			//======== Prawo =========
			if (x < 6 && y < 6) {
				++x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) {// czy na drodze jest czarny pionek 
					++x;
					++y;
					if (Variables.Board [y, x] == 0) { // czy mozna go zbic
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
			x = Start.x; y = Start.y;
			//======== Lewo =========
			if (x > 1 && y < 6) {
				--x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac nastepne bicie
					--x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
		}

		if (Variables.Checker == "Black" && Variables.Turn == "Black" && !Variables.AvJump) {
			//======== Prawo =========
			MoveP.x = Start.x + 1;//x rosnie
			MoveP.y = Start.y - 1;// y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			//======== Lewo =========
			MoveP.x = Start.x - 1;//x maleje
			MoveP.y = Start.y - 1;//y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
		}

		//=============================== Czarne Bija ================================
		if (Variables.Checker == "Black" && Variables.Turn == "Black" && Variables.AvJump && Variables.Board [Start.y, Start.x] == 32) {
			int x = Start.x, y = Start.y;
			//======== Prawo =========
			if (x < 6 && y > 1) {
				++x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) {// czy na drodze jest czarny pionek 
					++x;
					--y;
					if (Variables.Board [y, x] == 0) { // czy mozna go zbic
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
			x = Start.x; y = Start.y;
			//======== Lewo =========
			if (x > 1 && y > 1) {
				--x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac nastepne bicie
					--x;
					--y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
		}

		// === *** === Krole zwykly ruch === *** ===
		if (Variables.Checker == "King" && Variables.Turn == "White" && !Variables.AvJump && Variables.Board [Start.y, Start.x] == 11) {

			// ===================== Przod ======================
			//======== Prawo =========
			MoveP.x = Start.x + 1;//x rosnie
			MoveP.y = Start.y + 1;// y rosnie
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			//======== Lewo =========
			MoveP.x = Start.x - 1;//x rosnie
			MoveP.y = Start.y + 1;//y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			// ========================= Tyl =====================
			//======== Prawo =========
			MoveP.x = Start.x + 1;//x rosnie
			MoveP.y = Start.y - 1;// y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			//======== Lewo =========
			MoveP.x = Start.x - 1;//x maleje
			MoveP.y = Start.y - 1;//y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
		}
		if (Variables.Checker == "King" && Variables.Turn == "Black" && !Variables.AvJump && Variables.Board [Start.y, Start.x] == 12) {
			
			// ===================== Przod ======================
			//======== Prawo =========
			MoveP.x = Start.x + 1;//x rosnie
			MoveP.y = Start.y + 1;// y rosnie
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			//======== Lewo =========
			MoveP.x = Start.x - 1;//x rosnie
			MoveP.y = Start.y + 1;//y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			// ========================= Tyl =====================
			//======== Prawo =========
			MoveP.x = Start.x + 1;//x rosnie
			MoveP.y = Start.y - 1;// y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
			//======== Lewo =========
			MoveP.x = Start.x - 1;//x maleje
			MoveP.y = Start.y - 1;//y maleje
			if (MoveP.x >= 0 && MoveP.x < 8 && MoveP.y >= 0 && MoveP.y < 8 && Variables.Board [MoveP.y, MoveP.x] == 0) {
				MoveDirection = Variables.ReturnCoordinates (MoveP);
				StartCoroutine (CreateActivButton (MoveDirection)); // tworzenie przycisku
			} 
		}
		// Koniec zwyklego ruchu kroli

		//=== *** === *** === Bicie Bialych Kroli === *** === *** === 
		if (Variables.Checker == "King" && Variables.Turn == "White" && Variables.AvJump && Variables.Board [Start.y, Start.x] == 311) {
			int x = Start.x, y = Start.y;
			// ===================== Przod ======================
			//======== Prawo =========
			if (x < 6 && y < 6) {
				++x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac bicie
					++x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
			//======== Lewo =========
			x = Start.x; y = Start.y;
			if (x > 1 && y < 6) {
				--x;
				++y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac nastepne bicie
					--x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}

			// ========================= Tyl =====================
			//======== Prawo =========
			x = Start.x; y = Start.y;
			if (x < 6 && y > 1) {
				++x;
				--y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) {// czy na drodze jest czarny pionek 
					++x;
					--y;
					if (Variables.Board [y, x] == 0) { // czy mozna go zbic
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
			//======== Lewo =========
			x = Start.x; y = Start.y;
			if (x > 1 && y > 1) {
				--x;
				--y;
				if (Variables.Board [y, x] == 2 || Variables.Board [y, x] == 12) { // czy mozna wykonac nastepne bicie
					--x;
					--y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
		}

		//=== *** === *** === Bicie Czarnych Kroli === *** === *** === 
		if (Variables.Checker == "King" && Variables.Turn == "Black" && Variables.AvJump && Variables.Board [Start.y, Start.x] == 312) {
			int x = Start.x, y = Start.y;
			//bool strafe = false;
			
			// ===================== Przod ======================
			//======== Prawo =========
			if (x < 6 && y < 6) {
				++x;
				++y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac bicie
					++x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
			//======== Lewo =========
			x = Start.x; y = Start.y;
			if (x > 1 && y < 6) {
				--x;
				++y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac nastepne bicie
					--x;
					++y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
			
			// ========================= Tyl =====================
			//======== Prawo =========
			x = Start.x; y = Start.y;
			if (x < 6 && y > 1) {
				++x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) {// czy na drodze jest czarny pionek 
					++x;
					--y;
					if (Variables.Board [y, x] == 0) { // czy mozna go zbic
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
			//======== Lewo =========
			x = Start.x; y = Start.y;
			if (x > 1 && y > 1) {
				--x;
				--y;
				if (Variables.Board [y, x] == 1 || Variables.Board [y, x] == 11) { // czy mozna wykonac nastepne bicie
					--x;
					--y;
					if (Variables.Board [y, x] == 0) { // pole za pionkiem jest puste
						MoveP.x = x;
						MoveP.y = y;
						MoveDirection = Variables.ReturnCoordinates (MoveP);
						StartCoroutine (CreateActivButton (MoveDirection));
					}
				}
			}
		}
	}
	IEnumerator CreateActivButton (Coordinates one){
		yield return new WaitForSeconds (0.001f);
		temp = (Button)Instantiate (Activation, new Vector3 (one.x, one.y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		
	}
}
