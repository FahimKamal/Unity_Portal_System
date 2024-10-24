using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    [SerializeField] private Camera cameraB;

    [SerializeField] private Material cameraMatB;
    
    // Start is called before the first frame update
    void Start()
    {
        // Remove any texture attach to it. 
        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        
        // Create new texture and attach with it. 
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
        cameraMatB.mainTexture = cameraB.targetTexture;

    }
    
}
