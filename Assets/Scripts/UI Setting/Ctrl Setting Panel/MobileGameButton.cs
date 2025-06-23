using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileGameButton : MonoBehaviour
{
    [SerializeField] private UiSetting uiSetting;
    private GameObject MobileGameActivate;
    public void _On_Mobile_Mod()
    {
        if (this.MobileGameActivate == null) this.MobileGameActivate = this.uiSetting.MobileGameActivate;

        if (this.MobileGameActivate.activeSelf)
        {
            this.MobileGameActivate.SetActive(false);
            this.uiSetting.UI_Mobile.SetActive(false);
            PlayerPrefs.SetInt("MobileCtrl", 0);
            Debug.Log(PlayerPrefs.GetInt("MobileCtrl"));
        }
        else
        {
            this.MobileGameActivate.SetActive(true);
            this.uiSetting.UI_Mobile.SetActive(true);
            PlayerPrefs.SetInt("MobileCtrl", 1);
            Debug.Log(PlayerPrefs.GetInt("MobileCtrl"));
        }
    }
}
