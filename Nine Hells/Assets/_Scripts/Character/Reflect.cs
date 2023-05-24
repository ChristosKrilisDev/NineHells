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

                var npc = newGO.GetComponent<NPC>();
                npc.enabled = false;
                newGO.transform.GetComponent<Collider>().enabled = false;

            }
        }
    }
}
