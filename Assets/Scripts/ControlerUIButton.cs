using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ControlerUIButton : MonoBehaviour, IPointerEnterHandler// required interface when using the OnPointerEnter method.
{

	/*
	 *Helps button communicate with Controler UI Manager, and tags it as a custom button. 
	 */

	private ControlerUIManager uiManager;

	void Start()
	{
		uiManager = Transform.FindObjectOfType<ControlerUIManager> ();
	}

	//Do this when the cursor enters the rect area of this selectable UI object.
	public void OnPointerEnter(PointerEventData eventData)
	{

		uiManager.SetSelectedButton (this.GetComponent<Button>());
	}
}