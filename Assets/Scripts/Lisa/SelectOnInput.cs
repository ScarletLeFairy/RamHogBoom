using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectOnInput : MonoBehaviour
{
    public EventSystem MenuEventSystem;
	public GameObject[] MenuObjects;
	public Button backButtonObject;
	public float RepeatDelay;
	public int index;

	private float LastUpdateTime;

	void Start () {
		UpdateSelection ();
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf) {
			if (CanRefresh ()) {
				HandleVerticalAxisChanges ();
			}
			HandleHorizontalAxisChanges ();
			HandleButtonClicks ();
		}
	}

	//Updates the Selected Item
	private void HandleVerticalAxisChanges(){
		if (Input.GetAxisRaw ("Vertical") < -0.1) {
			index = index < (MenuObjects.Length - 1) ? ++index : 0;
			UpdateSelection ();
		}else if(Input.GetAxisRaw ("Vertical") > 0.1){
			if (index > 0) {
				index--;
			} else {
				index = MenuObjects.Length - 1;
			}
			UpdateSelection ();
		}
	}

	//Updates the Slider Values if the Selected Item is one
	private void HandleHorizontalAxisChanges(){
		if (Input.GetAxisRaw("Horizontal") != 0) {
			float distance = Input.GetAxisRaw ("Horizontal");
			Slider activeSlider = MenuObjects [index].GetComponent<Slider> ();
			if (activeSlider != null) {
				if (distance < 0) {
					activeSlider.value = activeSlider.value - (float)0.01;
				} else {
					activeSlider.value = activeSlider.value +  (float)0.01;
				}
			}
		}
	}

	private void HandleButtonClicks(){
		// Button A
		if (Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			Button activeButton = MenuObjects [index].GetComponent<Button> ();
			if (activeButton != null) {
				activeButton.onClick.Invoke();
			}
		}
		// Button Back
		if (Input.GetKeyDown(KeyCode.JoystickButton6))
		{
			backButtonObject.onClick.Invoke();
		}
	}

	private void UpdateSelection(){
		MenuEventSystem.SetSelectedGameObject(MenuObjects[index]);
		LastUpdateTime = Time.time;
	}

	private bool CanRefresh(){
		return LastUpdateTime + RepeatDelay < Time.time ? true : false;
	}
}
