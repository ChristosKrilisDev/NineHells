using System.Collections.Generic;
using UnityEngine;
namespace _Scripts
{
    public class PlaneObjectParent : MonoBehaviour
    {
        public List<Material> MyMaterial;
        [HideInInspector]public MeshRenderer MeshRenderer;
        public List<PlaneObjectChild> Childs;

        private void Awake()
        {
            MeshRenderer = GetComponent<MeshRenderer>();
            MyMaterial = new List<Material>();

            var mats = MeshRenderer.materials;

            for (int i = 0; i < mats.Length; i++)
            {
                MyMaterial.Add(mats[i]);
            }
            ResetMaterial();
        }

        
        
        public void ResetMaterial()
        {
            MeshRenderer.materials = MyMaterial.ToArray();

            // var mats = MeshRenderer.materials;
            //
            // for (int i = 0; i < MyMaterial.Count; i++)
            // {
            //     MeshRenderer.materials[i] = MyMaterial[i];
            // }
        }


        public void SetMaterial(Material material)
        {
            Material[] newMats = new Material[MeshRenderer.materials.Length];

            for (int i = 0; i < newMats.Length; i++)
            {
                newMats[i] = material;
            }

            MeshRenderer.materials = newMats;
        
        }
    }
}
