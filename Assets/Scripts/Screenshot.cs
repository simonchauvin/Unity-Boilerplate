using UnityEngine;
using System;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public Camera screenshotCam;
    public string directoryName = "Screenshots";
    public int resolutionWidth;
    public int resolutionHeight;

    private string subDirectoryName;
    private RenderTexture renderTex;
    private Texture2D screenshotTexture;


	void Start ()
    {
        if (directoryName.Length > 0)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            subDirectoryName = DateTime.Now.ToString("dd-MM-yyyy");
            if (!Directory.Exists(subDirectoryName))
            {
                Directory.CreateDirectory(directoryName + "/" + subDirectoryName);
            }
        }

        renderTex = new RenderTexture(resolutionWidth, resolutionHeight, 1, RenderTextureFormat.ARGBFloat);
        screenshotTexture = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGBAFloat, false);
    }
	
	void Update ()
    {
		
	}

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P) && directoryName.Length > 0)
        {
            RenderTexture.active = renderTex;
            screenshotCam.targetTexture = renderTex;
            screenshotCam.Render();

            string filename = DateTime.Now.ToString("dd-MM-yyyy_HHmmssFFFF") + ".png";
            screenshotTexture.ReadPixels(new Rect(0, 0, resolutionWidth, resolutionHeight), 0, 0);
            screenshotTexture.Apply();
            File.WriteAllBytes(directoryName + "/" + subDirectoryName + "/" + filename, screenshotTexture.EncodeToPNG());
            screenshotCam.targetTexture = null;
        }
    }
}
