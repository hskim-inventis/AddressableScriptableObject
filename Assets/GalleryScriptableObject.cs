using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GalleryScriptableObject", order = 1)]
public class GalleryScriptableObject : ScriptableObject
{
    public string caption;

    public Sprite spThumbnail;
    public VideoClip clipVideo;
    public Sprite spLarge;
}