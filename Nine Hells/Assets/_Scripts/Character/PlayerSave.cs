using System;
using UnityEngine;
namespace _Scripts.Character
{
    public class PlayerSave : MonoBehaviour
    {
        public static int MoralityScore = 0 ;
        public static PlayerSave instance;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }


        public static void GetScorePath(Hell9 hell9)
        {
            if (MoralityScore <= -7)
            {
                //sin path
                hell9.ShowSin();

            }
            else if (MoralityScore >= 7)
            {
                //virtue path
                hell9.ShowVirtue();
            }
            else
            {
                //whatever
                hell9.ShowMixed();
            }
        }
    }
}
