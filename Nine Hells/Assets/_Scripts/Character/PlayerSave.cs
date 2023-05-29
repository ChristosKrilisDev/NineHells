using System;
using UnityEngine;
namespace _Scripts.Character
{
    public class PlayerSave : MonoBehaviour
    {
        public static int MoralityScore = 0 ;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }


        public static void GetScorePath()
        {
            if (MoralityScore <= -7)
            {
                //sin path
            }
            else if (MoralityScore >= 7)
            {
                //virtue path
            }
            else
            {
                //whatever
            }
        }
    }
}
