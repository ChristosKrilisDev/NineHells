using System.Collections.Generic;
using UnityEngine;
namespace _Scripts
{
    public class PlaneObjectParent : MonoBehaviour
    {
        public List<Material> MyMaterial;
        [HideInInspector] public MeshRenderer MeshRenderer;
        public List<PlaneObjectChild> Childds;

        public bool isChar;

        private void Awake()
        {
            // gameObject.SetActive(true);
            Childds = new List<PlaneObjectChild>();

            bool isNPC = gameObject.GetComponent<NPC>();
            bool isEnemy = gameObject.GetComponent<Enemy>();
            
            if (isNPC || isEnemy || isChar)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var t = transform.GetChild(i);
                    for (int j = 0; j < t.childCount; j++)
                    {
                        if (t.GetChild(j).TryGetComponent(out PlaneObjectChild poc)) ;
                        {
                            Childds.Add(poc);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).TryGetComponent(out PlaneObjectChild poc)) ;
                    {
                        Childds.Add(poc);
                    }
                }
            }

            

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
