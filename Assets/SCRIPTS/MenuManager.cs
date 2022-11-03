using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject LevelsPanel;
    [SerializeField] GameObject SettingsPanel;
    [Space(6)]
    private GameObject musicPlayer;
    private GameObject menuCamera;
    [Space(14)]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundsSlider;
    [SerializeField] Slider cameraSizeSlider;
    [Space(14)]
    [SerializeField] Text settingsText;
    [Space(20)]
    [SerializeField] Button[] levelButton = new Button[31];

    private AudioSource musicPlayerComponen;
    private Camera menuCameraComponent;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        GetLoad();

        if(Application.systemLanguage == SystemLanguage.Russian)
        {
            settingsText.text = "Настройки".ToString();
        }
        else
        {
            settingsText.text = "Settings".ToString();
        }
    }

    private void GetLoad()
    {
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");
        menuCamera = GameObject.FindGameObjectWithTag("MainCamera");

        musicPlayerComponen = musicPlayer.GetComponent<AudioSource>();      
        menuCameraComponent = menuCamera.GetComponent<Camera>();

        musicSlider.value = YandexGame.savesData.musicVolume;
        soundsSlider.value = YandexGame.savesData.soundsVolume;
        cameraSizeSlider.value = YandexGame.savesData.cameraSize;
    }

    public void MusicVolumeSlider()
    {
        float musicVolume = musicSlider.value;
        musicPlayerComponen.volume = musicVolume;
        YandexGame.savesData.musicVolume = musicVolume;
    }
    public void SoundsVolumeSlider()
    {
        float soundsVolume = soundsSlider.value;
        YandexGame.savesData.soundsVolume = soundsVolume;
    }

    public void CameraSizeSlider()
    {
        float cameraSize = cameraSizeSlider.value;
        menuCameraComponent.orthographicSize = cameraSize;
        YandexGame.savesData.cameraSize = cameraSize;
    }
    
    public void OpenLevelsPanel()
    {
        LevelsPanel.SetActive(true);

        int completedlevels = YandexGame.savesData.completedLevels;
        for (int i = 0; i < completedlevels; i++)
        {
            levelButton[i].interactable = true;
        }
    }

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        LevelsPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        YandexGame.SaveProgress();
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
