using UnityEngine;
using System.Collections;

public class NavigateToMenu : MonoBehaviour
{
    public GameObject MenuToHide, MenuToShow;

    public void SwitchMenu()
    {
        MenuToHide.gameObject.SetActive(false);
        MenuToShow.gameObject.SetActive(true);
    }
}
