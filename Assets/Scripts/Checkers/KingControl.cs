using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KingControl : MonoBehaviour {
	
	private float  positionX,  positionY;
	public static Index MyPosition;
	private CreateButton CB;
	private RectTransform move;
	
	public void Clicked(){
		Variables.Checker = "King";
		if (Variables.Moved) {
			move = GetComponent<RectTransform> (); // zapisanie RectTransforma do zmiennej move
			//przeliczanie pozycji pionka
			positionX = GetComponent<RectTransform> ().anchoredPosition.x;
			positionY = GetComponent<RectTransform> ().anchoredPosition.y;
			MyPosition = Variables.ReturnIndex (positionX, positionY);
			//odnalezienie obiektu kreujacego guziki, ktore pozwalaja na ruch pionka
			CB = GameObject.Find ("Main Camera").GetComponent<CreateButton> ();
			// tworzenie guzikow, przesylam do funkcji initialize referencje zmiennej move
			CB.Initialize (MyPosition, ref move);
			Variables.Moved = false;
            Variables.LastClicked = MyPosition;

		} else { //jezeli nie chemy ruszyc tym pionkiem wystarczy ze nacisniemy inny pionek i guziki zostana usuniete
            GameObject[] ActiveList = GameObject.FindGameObjectsWithTag("Active");
            foreach (GameObject Act in ActiveList)
            {
                Destroy(Act.gameObject);
            }
            Variables.Moved = true;
            positionX = GetComponent<RectTransform>().anchoredPosition.x;
            positionY = GetComponent<RectTransform>().anchoredPosition.y;
            MyPosition = Variables.ReturnIndex(positionX, positionY);
            if (Variables.LastClicked.x != MyPosition.x || Variables.LastClicked.y != MyPosition.y)
                Clicked();
        }
	}
}