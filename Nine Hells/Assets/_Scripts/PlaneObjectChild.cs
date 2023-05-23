
using System.Collections.Generic;
using UnityEngine;

public class PlaneObjectChild : MonoBehaviour
{
    public List<Material> MyMaterial;
    [HideInInspector]public MeshRenderer MeshRenderer;

    private MeshRenderer mr;
    
    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        mr = MeshRenderer;
        MyMaterial = new List<Material>();
        var mats = MeshRenderer.materials;
        for (int i = 0; i < mats.Length; i++)
        {
            MyMaterial.Add(mats[i]);
        }

        ResetMaterials();
    }
    
    public void ResetMaterials()
    {
        // MeshRenderer = mr;
        MeshRenderer.materials = MyMaterial.ToArray();
        // for (int i = 0; i < MyMaterial.Count; i++)
        // {
        //     MeshRenderer.materials[i] = MyMaterial[i];
        // }
    }


    public void SetMaterials(Material material)
    {
        Material[] newMats = new Material[MeshRenderer.materials.Length];

        for (int i = 0; i < newMats.Length; i++)
        {
            newMats[i] = material;
        }

        MeshRenderer.materials = newMats;
        
    }
}
