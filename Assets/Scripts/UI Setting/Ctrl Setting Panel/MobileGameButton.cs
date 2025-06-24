using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileGameButton : MonoBehaviour
{
    [SerializeField] private GameObject MobileGameActivate, UI_Mobile;
    public void _Mobile_Mod_Button()
    {
        if (this.MobileGameActivate.activeSelf) _Off_Mobile_Mod();
        else _On_Mobile_Mod();
    }
    public void _On_Mobile_Mod()
    {
        this.MobileGameActivate.SetActive(true);
        this.UI_Mobile.SetActive(true);
        PlayerPrefs.SetInt("MobileCtrl", 1);
    }
    public void _Off_Mobile_Mod()
    {
        this.MobileGameActivate.SetActive(false);
        this.UI_Mobile.SetActive(false);
        PlayerPrefs.SetInt("MobileCtrl", 0);
    }
}
