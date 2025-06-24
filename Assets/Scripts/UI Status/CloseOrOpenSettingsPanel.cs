using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOrOpenSettingsPanel : MonoBehaviour
{
    [SerializeField] UiStatus UiStatus;
    private UiSetting uiSetting;
    public void _CloseOrOpenSettingsPanel_Button()
    {
        if (this.UiStatus.UI_Setting.activeSelf) this.UiStatus.UI_Setting.SetActive(false);
        else this.UiStatus.UI_Setting.SetActive(true);

        if (this.uiSetting == null) this.uiSetting = this.UiStatus.UI_Setting.GetComponent<UiSetting>();
        this.uiSetting._Save();
    }
}
