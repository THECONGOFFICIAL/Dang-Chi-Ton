using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSetting : MonoBehaviour
{
    public GameObject UI_Mobile;
    public GameObject MobileGameActivate;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("IsDownload") == 0)
        {
            Debug.Log("Lần đầu tải game");
            PlayerPrefs.SetInt("IsDownload", 1);
            _Check_Device();
        }
        else
        {
            Debug.Log("Đã chơi");
            Debug.Log(PlayerPrefs.GetInt("MobileCtrl"));
            if (PlayerPrefs.GetInt("MobileCtrl") == 1) this.UI_Mobile.SetActive(true);
            else this.UI_Mobile.SetActive(false);
        }
    }
    private void _Check_Device()
    {
        RuntimePlatform platform = Application.platform;

        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer)
        {
            this.UI_Mobile.SetActive(true);
            PlayerPrefs.SetInt("MobileCtrl", 1);
            Debug.Log("Người chơi mobile");
        }
        else
        {
            this.UI_Mobile.SetActive(false);
            PlayerPrefs.SetInt("MobileCtrl", 0);
            Debug.Log("Người chơi pc");
        }
    }
}
