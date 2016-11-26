using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateCheckers : MonoBehaviour {
	private float x,y;
	private Index Ind;
	public Button WhiteChecker;
	public Button BlackChecker;
	private Button temp;
	public Canvas GameCanvas;
	// Use this for initialization
	void Start () {
		StartCoroutine (CreateAChecker ());
		StartCoroutine (CreateABlackChecker ());
	}
	
	IEnumerator CreateAChecker (){
		yield return new WaitForSeconds (0.001f);
		//* Włącznik Classic
		for (int i=0; i<8;) {
			for (int j=0; j<4;) {
				x = Variables.Horizontal[i];
				y = Variables.Vertical[j];
				Ind = Variables.ReturnIndex (x, y);
				Variables.Board [Ind.y, Ind.x] = 1;
				temp = (Button)Instantiate (WhiteChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
				temp.transform.SetParent (GameCanvas.transform, false);
				j+=2;
			}
			i+=2;
		}
		for (int i=1; i<8;) {
			int j = 1;
			x = Variables.Horizontal [i];
			y = Variables.Vertical [j];
			Ind = Variables.ReturnIndex (x, y);
			Variables.Board [Ind.y, Ind.x] = 1;
			temp = (Button)Instantiate (WhiteChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
			temp.transform.SetParent (GameCanvas.transform, false);

			i += 2;
		}
		//*/

		/* Włącznik Test
		x = Variables.Horizontal[1];
		y = Variables.Vertical[6];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 1;
		temp = (Button)Instantiate (WhiteChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		/*
		x = Variables.Horizontal[3];
		y = Variables.Vertical[4];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 1;
		temp = (Button)Instantiate (WhiteChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);

		x = Variables.Horizontal[1];
		y = Variables.Vertical[2];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 1;
		temp = (Button)Instantiate (WhiteChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		//*/
	}
	IEnumerator CreateABlackChecker (){
		yield return new WaitForSeconds (0.001f);
		/* Włącznik Test
		x = Variables.Horizontal[2];
		y = Variables.Vertical[7];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		//*
		x = Variables.Horizontal[3];
		y = Variables.Vertical[6];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);

		x = Variables.Horizontal[5];
		y = Variables.Vertical[6];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);

		x = Variables.Horizontal[1];
		y = Variables.Vertical[4];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		//*
		x = Variables.Horizontal[3];
		y = Variables.Vertical[4];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		
		x = Variables.Horizontal[5];
		y = Variables.Vertical[4];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);

		x = Variables.Horizontal[1];
		y = Variables.Vertical[2];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		//*
		x = Variables.Horizontal[3];
		y = Variables.Vertical[2];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		
		x = Variables.Horizontal[5];
		y = Variables.Vertical[2];
		Ind = Variables.ReturnIndex (x, y);
		Variables.Board [Ind.y, Ind.x] = 2;
		temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
		temp.transform.SetParent (GameCanvas.transform, false);
		//*/

		//* Włącznik Classic
		for (int i=1; i<8;) {
			for (int j=5; j<8;) {
				x = Variables.Horizontal[i];
				y = Variables.Vertical[j];
				Ind = Variables.ReturnIndex (x, y);
				Variables.Board [Ind.y, Ind.x] = 2;
				temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
				temp.transform.SetParent (GameCanvas.transform, false);
				j+=2;
			}
			i+=2;
		}
		for (int i=0; i<8;) {
			int j = 6;
			x = Variables.Horizontal [i];
			y = Variables.Vertical [j];
			Ind = Variables.ReturnIndex (x, y);
			Variables.Board [Ind.y, Ind.x] = 2;
			temp = (Button)Instantiate (BlackChecker, new Vector3 (x, y, 0.0f), Quaternion.identity);
			temp.transform.SetParent (GameCanvas.transform, false);
			i += 2;
		}
		//*/
	}
}
