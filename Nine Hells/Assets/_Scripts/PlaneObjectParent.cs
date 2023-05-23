using System.Collections.Generic;
using UnityEngine;
namespace _Scripts
{
    public class PlaneObjectParent : MonoBehaviour
    {
        [HideInInspector]public Material MyMaterial;
        [HideInInspector]public MeshRenderer MeshRenderer;
        public List<PlaneObjectChild> Childs;

        private void Awake()
        {
            MeshRenderer = GetComponent<MeshRenderer>();
            MyMaterial = MeshRenderer.material;
        }


        public void ResetMaterial()
        {
            MeshRenderer.material = MyMaterial;
        }
    }
}
