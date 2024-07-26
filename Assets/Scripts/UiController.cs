using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    private Image _heartimage;
    private TextMeshProUGUI _coinText;
    private GameObject _menuPanel;
    private Slider _sfxSlider;
    private Slider _musicSlider;
    private AudioSourceController _audioSourceController;
    private int _coinCount = 0;
    void Start()
    {
        //Connect UI
        if (GameObject.Find(Structs.UI.heartImage))
        {   //health bar
            _heartimage = GameObject.Find(Structs.UI.heartImage).GetComponent<Image>(); HeartImageUpdate(1);
            HeartImageUpdate(1);
        }
        if (GameObject.Find(Structs.UI.coinText))
        {   //amount
            _coinText = GameObject.Find(Structs.UI.coinText).GetComponent<TextMeshProUGUI>();
        }
        if (GameObject.Find(Structs.UI.coins))
        {   //coin counter
            _coinCount = GameObject.Find(Structs.UI.coins).transform.childCount;
            CoinTextUpdate(0);
        }
        _sfxSlider = GameObject.Find(Structs.UI.sfxSlider).GetComponent<Slider>();
        _musicSlider = GameObject.Find(Structs.UI.musicSlider).GetComponent<Slider>();
        _menuPanel = GameObject.Find(Structs.UI.panel);
        

        _audioSourceController = GameObject.FindAnyObjectByType<AudioSourceController>();

        _menuPanel.SetActive(false);
        SetSliders();


    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_menuPanel.active)
            {
                _menuPanel.SetActive(false);
            }
            else
            {
                _menuPanel.SetActive(true);
            }
        }
    }
    //Get rid of menu
    public void BackButton()
    {
        _menuPanel.SetActive(false);

    }
    public void OptionsButton()
    {
        _menuPanel.SetActive(true);

    }

    public void MenuButton()
    {   //sends player to main menu
        SceneManager.LoadScene(Structs.Scenes.menu);
    }
    public void FirstLevelButton()
    {   //sends player to first level
        SceneManager.LoadScene(Structs.Scenes.firstLevel);
    }



    //update heart image
    public void HeartImageUpdate(float newAmount)
    {
        _heartimage.fillAmount = newAmount;
    }
    //update coin text
    public void CoinTextUpdate(int newAmount) {
        _coinText.text = newAmount + " / " + _coinCount;
    }


    public void SetSliders()
    {
        _sfxSlider.value = PlayerPrefs.GetFloat(Structs.Mixers.sfxVolume);
        _musicSlider.value = PlayerPrefs.GetFloat(Structs.Mixers.musicVolume);
    }


    public void UpdateSFXSlider()
    {
        _audioSourceController.UpdateSFXGroup(_sfxSlider.value);
    }
    public void UpdateMusicSlider()
    {
        _audioSourceController.UpdateMusicGroup(_musicSlider.value);
    }

}
