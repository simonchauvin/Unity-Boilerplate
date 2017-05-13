using UnityEngine;
using System;
using System.IO;

public class ScreenshotCapture : MonoBehaviour
{
    public string directoryName = "Screenshots";
    public KeyCode captureKey = KeyCode.P;
    public bool singleScreenshotMode = true;
    public int resolutionWidth;
    public int resolutionHeight;

    private string subDirectoryName;
    private Camera thisCamera;
    private RenderTexture renderTex;
    private Texture2D screenshotTexture;


	void Start ()
    {
#if UNITY_EDITOR
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

        thisCamera = GetComponent<Camera>();
        renderTex = new RenderTexture(resolutionWidth, resolutionHeight, 1, RenderTextureFormat.ARGBFloat);
        screenshotTexture = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGBAFloat, false);
#endif
    }
	
	void Update ()
    {
		
	}

    private void LateUpdate()
    {
#if UNITY_EDITOR
        if (directoryName.Length > 0)
        {
            bool capture = false;
            if (singleScreenshotMode)
            {
                capture = Input.GetKeyDown(captureKey);
            }
            else
            {
                capture = Input.GetKey(captureKey);
            }

            if (capture)
            {
                RenderTexture.active = renderTex;
                thisCamera.targetTexture = renderTex;
                thisCamera.Render();

                string filename = DateTime.Now.ToString("dd-MM-yyyy_HHmmssFFFF") + ".png";
                screenshotTexture.ReadPixels(new Rect(0, 0, resolutionWidth, resolutionHeight), 0, 0);
                screenshotTexture.Apply();
                File.WriteAllBytes(directoryName + "/" + subDirectoryName + "/" + filename, screenshotTexture.EncodeToPNG());
                thisCamera.targetTexture = null;
            }
        }
    }
#endif
}
