using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

     [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private float defaultBrightness = 1;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private int _qualityLevel;
    private bool _isFullScreen;
    private float _brightnessLevel;

    [Header("Confirmation")]
    [SerializeField] private GameObject comfirmationPrompt = null;
   
    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    [Header("Resolution Dropdown")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions; 

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

 
    public void NewGameDialogYes()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void Setvolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

      public void SetBrightness(float brightness)
      {
          _brightnessLevel = brightness;
          brightnessTextValue.text = brightness.ToString("0.0");
      } 

      public void SetFullScreen(bool isFullScreen)
      {
          _isFullScreen = isFullScreen;
      }

      public void SetQuality(int qualityIndex)
      {
          _qualityLevel = qualityIndex;
      }

        public void GraphicsApply()
       {
           PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);

           PlayerPrefs.SetInt("masterQuality", _qualityLevel);
           QualitySettings.SetQualityLevel(_qualityLevel);

           PlayerPrefs.SetInt("masterFullScreen", (_isFullScreen ? 1 : 0));
           Screen.fullScreen = _isFullScreen;

           StartCoroutine(ConfirmationBox());
       }

      public void ResetButton(string MenuType)
      {
          if (MenuType == "Graphics")
          {
              brightnessSlider.value = defaultBrightness;
              brightnessTextValue.text = defaultBrightness.ToString("0.0");

              qualityDropdown.value = 1;
              QualitySettings.SetQualityLevel(1);

              fullScreenToggle.isOn = false;
              Screen.fullScreen = false;

              Resolution currentResolution = Screen.currentResolution;
              Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
              resolutionDropdown.value = resolutions.Length;
              GraphicsApply();
          }


          if (MenuType == "Audio")
          {
              AudioListener.volume = defaultVolume;
              volumeSlider.value = defaultVolume;
              volumeTextValue.text = defaultVolume.ToString("0.0");
              VolumeApply();
          }

      }
    
    public IEnumerator ConfirmationBox()
    {
        comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        comfirmationPrompt.SetActive(false);
    }
}
