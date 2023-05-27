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
    [SerializeField] private List<GameObject> playerBuffsUi;
    [SerializeField] private List<GameObject> playerDebuffsUi;
    private int activeBuffs = 0, activeDebuffs = 0;


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

    public void RefreshBuffsUi(List<Buff> playerBuffs)
    {
        foreach (GameObject buffUI in playerBuffsUi)
        {
            activeBuffs = 0;
            buffUI.SetActive(false);
        }

        foreach (Buff buff in playerBuffs)
        {
            Debug.Log("VAZW SPRITE");

            playerBuffsUi[activeBuffs].transform.GetChild(0).GetComponent<Image>().sprite = buff.buffSprite;
            playerBuffsUi[activeBuffs].SetActive(true);
            activeBuffs++;
        }

    }
    public void RefreshDebuffsUi(List<Buff> playerDebuffs)
    {
        foreach (GameObject debuffUI in playerDebuffsUi)
        {
            activeDebuffs = 0;
            debuffUI.SetActive(false);
        }

        foreach (Buff debuff in playerDebuffs)
        {
            playerDebuffsUi[activeDebuffs].transform.GetChild(0).GetComponent<Image>().sprite = debuff.buffSprite;
            playerDebuffsUi[activeDebuffs].SetActive(true);
            activeDebuffs++;
        }
    }

    public void AddDebuffUI(Sprite sprite)
    {
        
    }
    
}
