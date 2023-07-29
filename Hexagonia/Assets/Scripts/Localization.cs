using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Localization : MonoBehaviour
{
    void Start()
    {
        Invoke("Delay", 0.1f);

    }
    private void Delay()
    {
        int number = PlayerPrefs.GetInt("Language");
        ChangeLanguage(number);
    }

    public void ChangeLanguage(int language)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[language];
        PlayerPrefs.SetInt("Language", language);
    }

}
