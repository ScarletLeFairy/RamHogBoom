using UnityEngine;
using System.Collections;

public class NavigateToMenu : MonoBehaviour
{
    public GameObject MenuToHide, MenuToShow;
	public GameObject Background;

    public void SwitchMenu()
    {
        MenuToHide.SetActive(false);
        MenuToShow.SetActive(true);
    }

	public void ShowMenu(GameObject menu){
		menu.SetActive (true);
	}
	public void HideMenu(GameObject menu){
		menu.SetActive (false);
	}

	public void HideMenuFully(GameObject menu){
		Background.SetActive (false);
		menu.SetActive (false);
	}

	public void ShowMenuFully(GameObject menu){
		Background.SetActive (true);
		menu.SetActive (true);
	}
}
