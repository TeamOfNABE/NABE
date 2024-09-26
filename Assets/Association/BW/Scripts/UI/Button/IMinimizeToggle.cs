using UnityEngine;
using UnityEngine.UI;
public interface IMinimizeToggle
{
    public bool IsMinimize { get; set; }
    public Image Image { get; set; }
    public RectTransform MinimizetTarget { get; set; }
    public float MinimizeTime { get; set; }
    public void Minimize();
    public void Maximize();
}