using UnityEngine;
using System.Collections;

public class NavigateToMenu : MonoBehaviour
{
    public GameObject MenuToHide, MenuToShow;
	public GameObject Background;
	static GameObject PreviousMenu;

    public void SwitchMenu()
    {
        MenuToHide.SetActive(false);
		MenuToShow.SetActive(true);
		PreviousMenu = MenuToHide;
    }

	public void NavigateBack(){
		MenuToHide.SetActive (false);
		PreviousMenu.SetActive (true);
		PreviousMenu = MenuToHide;
	}

	public void ShowMenu(GameObject menu){
		menu.SetActive (true);
	}

	public void HideMenu(GameObject menu){
		PreviousMenu = menu;
		menu.SetActive (false);
	}

	public void ShowMenuFully(GameObject menu){
		Background.SetActive (true);
		menu.SetActive (true);
	}

	public void HideMenuFully(GameObject menu){
		PreviousMenu = menu;
		Background.SetActive (false);
		menu.SetActive (false);
	}
}
