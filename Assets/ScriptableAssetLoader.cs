using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScriptableAssetLoader : MonoBehaviour
{
    public Image imgThumbnail;
    public TextMeshProUGUI tmpCaption;
    public VideoPlayer vp;
    public RawImage ri;

    public AssetReference arKSP;
    public AssetReferenceT<GalleryScriptableObject> artKSP;
    // Start is called before the first frame update
    void Start()
    {
        arKSP.LoadAssetAsync<GalleryScriptableObject>().Completed += ScriptableAssetLoader_Completed;
    }

    private void ScriptableAssetLoader_Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GalleryScriptableObject> obj)
    {
        Debug.Log($"Status {obj.Status} caption {obj.Result.caption}");
        tmpCaption.text = obj.Result.caption;
        imgThumbnail.sprite = obj.Result.spThumbnail;

        vp.clip = obj.Result.clipVideo;
        vp.Prepare();
        vp.prepareCompleted += Vp_prepareCompleted;
    }

    /*
    IEnumerator PlayVideo(VideoClip clip)
    {
        vp.clip = clip;
        vp.Prepare();
        vp.prepareCompleted += Vp_prepareCompleted;       
    }
    */
    private void Vp_prepareCompleted(VideoPlayer source)
    {
        ri.texture = vp.texture;
        vp.Play();
    }
}
