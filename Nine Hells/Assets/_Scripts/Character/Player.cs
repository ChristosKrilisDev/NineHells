using System;
using Unity.VisualScripting;
using UnityEngine;
namespace _Scripts.Character
{
    public class Player : MonoBehaviour
    {
        private Points _points;

        public MoralityBarGUI MoralityBarGUI;
        
        private void Awake()
        {

            _points = new Points();
            MoralityBarGUI.Init();
        }

        private void AddSin()
        {
            _points.AddSinPoint();
            MoralityBarGUI.UpdateMoralityBar(-1);
        }

        private void AddVirtue()
        {
            _points.AddVirtuePoint();
            MoralityBarGUI.UpdateMoralityBar(+1);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AddSin();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                AddVirtue();
            }
        }

    }
}
