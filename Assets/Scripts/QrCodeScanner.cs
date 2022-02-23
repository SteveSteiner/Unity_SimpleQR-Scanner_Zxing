using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ZXing;
public class QrCodeScanner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private RawImage rimg_bgImage;

    [SerializeField]
    private AspectRatioFitter aspectRatioFitter;

    [SerializeField]
    private TextMeshProUGUI txt_qrResult;

    [SerializeField]
    private RectTransform rt_Scanzone;

    private bool isCamAvailable;
    private WebCamTexture cameraTexture;
    #endregion

    #region Mono methods
    void Start()
    {
        SetupCamera();
    }

    void Update()
    {
        
    }
    #endregion

    #region Methods
    private void SetupCamera()
    {
        WebCamDevice[] webCamDevices = WebCamTexture.devices;

        if(webCamDevices.Length == 0)
        {
            isCamAvailable = false;
            txt_qrResult.text = "No Camera Available";
            Debug.LogWarning("No Camera Available");
            return;
        }

        foreach(WebCamDevice wcd in webCamDevices)
        {
            if(!wcd.isFrontFacing)
            {
                cameraTexture = new WebCamTexture(wcd.name, (int)rt_Scanzone.rect.width, (int)rt_Scanzone.rect.height);
            }
        }

        cameraTexture.Play();
        rimg_bgImage.texture = cameraTexture;
        isCamAvailable = true;
    }
    #endregion
}
