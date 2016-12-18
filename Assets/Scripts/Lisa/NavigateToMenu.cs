using UnityEngine;
using System.Collections;

public class NavigateToMenu : MonoBehaviour
{
    public GameObject MenuToHide, MenuToShow;

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

	public void HideBackground(GameObject background){
		background.SetActive (false);
	}

	public void ShowBackground(GameObject background){
		background.SetActive (true);
	}
}
