using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsGUI : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _planeText;
    [SerializeField] private Image _planeImage;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private Slider moralityBarSlider;


    public void ChangePlaneUI(SwitchPlaneManager.PlaneState planeState)
    {
        TextPlaneText(planeState.ToString());
        ChangePlaneUIColo(planeState);
    }
    
    public void TextPlaneText(string plane)
    {
        _planeText.text = plane;
    }


    public void ChangePlaneUIColo(SwitchPlaneManager.PlaneState planeState)
    {
        switch (planeState)
        {
            case SwitchPlaneManager.PlaneState.MaterialPlane:
                _planeImage.color = Color.green;
                break;
            case SwitchPlaneManager.PlaneState.ShadowPlane:
                _planeImage.color = Color.red;

                break;
            case SwitchPlaneManager.PlaneState.Switching:
                _planeImage.color = Color.black;

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(planeState), planeState, null);
        }
    }

    public void ChangePlayerHPUI(float health)
    {
        healthBarSlider.value = health / 100.0f;
    }

    public void ChangePlayerMoralUI(float morality)
    {
        moralityBarSlider.value += morality / 10.0f;
    }

    public void AddDebuffUI(Sprite sprite)
    {
        
    }
    
}
