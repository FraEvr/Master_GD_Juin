using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallpaperManager : MonoBehaviour
{
    public Sprite[] wallpapers;
    public Image wallpaperImage;
    public Image wallpaperPreviewImage;

    public void ChangeWallpaper(int ind)
    {
        wallpaperImage.sprite = wallpapers[ind];
        wallpaperPreviewImage.sprite = wallpapers[ind];
    }
}
