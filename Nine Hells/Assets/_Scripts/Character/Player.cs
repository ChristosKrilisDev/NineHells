using System;
using Unity.VisualScripting;
using UnityEngine;
namespace _Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private Points _points;

        public MoralityBarGUI MoralityBarGUI;

        public AudioSource MaterialAudio;
        public AudioSource ShadowAudio;


        public void SwitchToMaterial()
        {
            ShadowAudio.volume = 0;
            MaterialAudio.volume = 1;
        }

        public void SwitchToShadow()
        {
            ShadowAudio.volume = 1;
            MaterialAudio.volume = 0;
        }
        
        
        private void Awake()
        {

            _points = new Points();
            //MoralityBarGUI.Init();
            MoralityBarGUI.UpdateMoralityBar(PlayerSave.MoralityScore);
            HUD.Instance.PlayerStatsGUI.SetMorality(PlayerSave.MoralityScore);
        }

        public void AddSin()
        {
            _points.AddSinPoint();
            PlayerSave.MoralityScore--;
            MoralityBarGUI.UpdateMoralityBar(-1);
            HUD.Instance.PlayerStatsGUI.ChangePlayerMoralUI(-1);
        }

        public void AddVirtue()
        {
            _points.AddVirtuePoint();
            PlayerSave.MoralityScore++;
            MoralityBarGUI.UpdateMoralityBar(+1);
            HUD.Instance.PlayerStatsGUI.ChangePlayerMoralUI(+1);
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Z))
            //{
            //    AddSin();
            //}
            //if (Input.GetKeyDown(KeyCode.X))
            //{
            //    AddVirtue();
            //}
        }

    }
}
