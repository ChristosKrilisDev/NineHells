using _Scripts.Interactions.InteractionsSO;
using UnityEditor.SceneManagement;
using UnityEngine;
namespace _Scripts.Character
{
    public static class Reflect
    {



        public static void UseReflect(GameObject newGO, GameObject prevGo,PlaneObject.ReflectType reflectType)
        {
            newGO.transform.localPosition = prevGo.transform.localPosition;
            newGO.transform.localRotation = prevGo.transform.localRotation;

            if (reflectType == PlaneObject.ReflectType.Ladder)
            {
                var newG = newGO.GetComponent<UseInteraction>();
                var prev = prevGo.GetComponent<UseInteraction>();
                newG.CanInteract = prev.CanInteract;
                newG.gameObject.tag = prev.gameObject.tag;
            }

            if (reflectType == PlaneObject.ReflectType.NPC)
            {
                // var prevAnim =prevGo.GetComponent<Animator>()
                
                for (int i = 0; i < newGO.transform.childCount; i++)
                {
                    newGO.transform.GetChild(i).transform.localPosition = prevGo.transform.GetChild(i).transform.localPosition;
                    newGO.transform.GetChild(i).transform.localRotation = prevGo.transform.GetChild(i).transform.localRotation;
                }
                
            }
        }
    }
}
