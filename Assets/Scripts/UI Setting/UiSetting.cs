using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSetting : MonoBehaviour
{
    [Header("Link")]
    [SerializeField] private MobileGameButton mobileGameButton;

    [Header("Camera")]
    public Slider SensitivityCamera_Slider;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("New Player") == 0) _New_Player();
        else _Old_Player();
        gameObject.SetActive(false);
    }
    private void _New_Player()
    {
        Debug.Log("Người chơi mới");
        PlayerPrefs.SetInt("New Player", 1);
        _Check_Device();
        PlayerPrefs.SetFloat("SensitivityCamera Slider", 5f);
        this.SensitivityCamera_Slider.value = PlayerPrefs.GetFloat("SensitivityCamera Slider");
    }
    private void _Old_Player()
    {
        Debug.Log("Người chơi cũ");
        if (PlayerPrefs.GetInt("MobileCtrl") == 1) this.mobileGameButton._On_Mobile_Mod();
        else this.mobileGameButton._Off_Mobile_Mod();
        this.SensitivityCamera_Slider.value = PlayerPrefs.GetFloat("SensitivityCamera Slider");
    }
    private void _Check_Device()
    {
        RuntimePlatform platform = Application.platform;
        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) this.mobileGameButton._On_Mobile_Mod();
        else this.mobileGameButton._Off_Mobile_Mod();
    }
    public void _Save()
    {
        PlayerPrefs.SetFloat("SensitivityCamera Slider", SensitivityCamera_Slider.value);
    }
}
