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

    private bool buttonSelected;
	private float LastUpdateTime;

	void Start () {
		UpdateSelection ();
	}
	// Update is called once per frame
	void Update () {
		if (buttonSelected) {
			if (CanRefresh ()) {
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

			if (Input.GetAxisRaw("Horizontal") != 0) {
				float distance = Input.GetAxisRaw ("Horizontal");
				Slider activeSlider = MenuObjects [index].GetComponent<Slider> ();
				if (activeSlider != null) {
					activeSlider.value = activeSlider.value + distance;
				}
			}

			if (Input.GetKeyDown(KeyCode.JoystickButton0))
			{
				Debug.Log("A was pressed");
				Button activeButton = MenuObjects [index].GetComponent<Button> ();
				if (activeButton != null) {
					activeButton.onClick.Invoke();
					Debug.Log ("Button Click: "+index);
				}
			}

			if (Input.GetKeyDown(KeyCode.JoystickButton6))
			{
				backButtonObject.onClick.Invoke();
			}
		}

	}

	private void UpdateSelection(){
		MenuEventSystem.SetSelectedGameObject(MenuObjects[index]);
		LastUpdateTime = Time.time;
	}

	private bool CanRefresh(){
		return LastUpdateTime + RepeatDelay < Time.time ? true : false;
	}

	private void OnDisable(){
		buttonSelected = false;
	}
	private void OnEnable(){
		buttonSelected = true;
	}
}
