using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    private WebCamTexture webCamTexture;
    private int captureCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] webCams = WebCamTexture.devices;
        print(webCams[0].name);
        webCamTexture = new WebCamTexture(webCams[0].name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            GetComponent<Renderer>().material.mainTexture = webCamTexture;
            webCamTexture.Play();
        }
        if (Input.GetKey("p"))
        {
            webCamTexture.Stop();
        }
        if (Input.GetKey("x"))
        {
            Texture2D snapshot = new Texture2D(webCamTexture.width, webCamTexture.height);
            snapshot.SetPixels(webCamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes("./" + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            captureCounter++;
        }
    }
}
