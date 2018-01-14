using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ControlerUIButton : MonoBehaviour, IPointerEnterHandler// required interface when using the OnPointerEnter method.
{

	private ControlerUIManager uiManager;

	void Start()
	{
		uiManager = Transform.FindObjectOfType<ControlerUIManager> ();
	}
	//Do this when the cursor enters the rect area of this selectable UI object.
	public void OnPointerEnter(PointerEventData eventData)
	{
//		Debug.Log("The cursor entered the selectable UI element.");
		uiManager.SetSelectedButton (this.GetComponent<Button>());
	}
}