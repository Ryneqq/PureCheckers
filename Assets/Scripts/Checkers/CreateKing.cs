using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateKing : MonoBehaviour {
	public Button BlackKing;
	public Button WhiteKing;
	private Button temp;
	public Canvas GameCanvas;
	private float positionX, positionY;
	private Index CheckIndex, PosIndex;
	private Coordinates CoCreate;

	public void CheckforKing(){
		if (Variables.Checker == "White" && Variables.Turn == "White") {
			for (int i=1; i<8; i+=2) {
				if(Variables.Board[7,i] == 1){
					Variables.Board[7,i] = 11;
					CheckIndex.x = i; CheckIndex.y = 7;

					GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
					foreach (GameObject Checker in CheckerList) {
						positionX = Checker.GetComponent<RectTransform> ().anchoredPosition.x;
						positionY = Checker.GetComponent<RectTransform> ().anchoredPosition.y;
						PosIndex = Variables.ReturnIndex(positionX,positionY);
						if (CheckIndex.x == PosIndex.x && CheckIndex.y == PosIndex.y) {
							Destroy (Checker.gameObject);
						}
					}
					CoCreate = Variables.ReturnCoordinates(CheckIndex);
					temp = (Button)Instantiate (WhiteKing, new Vector3 (CoCreate.x, CoCreate.y, 0.0f), Quaternion.identity);
					temp.transform.SetParent (GameCanvas.transform, false);
				}
			}
		}
		if (Variables.Checker == "Black" && Variables.Turn == "Black") {
			for (int i=0; i<7; i+=2) {
				if(Variables.Board[0,i] == 2){
					Variables.Board[0,i] = 12;
					CheckIndex.x = i; CheckIndex.y = 0;

					GameObject[] CheckerList = GameObject.FindGameObjectsWithTag ("ButtonTag"); // w taki sposob się dostaje do obiektów
					foreach (GameObject Checker in CheckerList) {
						positionX = Checker.GetComponent<RectTransform> ().anchoredPosition.x;
						positionY = Checker.GetComponent<RectTransform> ().anchoredPosition.y;
						PosIndex = Variables.ReturnIndex(positionX,positionY);
						if (CheckIndex.x == PosIndex.x && CheckIndex.y == PosIndex.y) {
							Destroy (Checker.gameObject);
						}
					}
					CoCreate = Variables.ReturnCoordinates(CheckIndex);
					temp = (Button)Instantiate (BlackKing, new Vector3 (CoCreate.x, CoCreate.y, 0.0f), Quaternion.identity);
					temp.transform.SetParent (GameCanvas.transform, false);
				}
			}
		}
	}
}
