
using UnityEngine;

public class PlaneObjectChild : MonoBehaviour
{
    [HideInInspector]public Material MyMaterial;
    [HideInInspector]public MeshRenderer MeshRenderer;

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
