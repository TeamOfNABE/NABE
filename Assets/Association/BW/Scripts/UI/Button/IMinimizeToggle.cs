using UnityEngine;
using UnityEngine.UI;
public interface IMinimizeToggle
{
    public bool isMinimize { get; set; }
    public float minimizeTime { get; set; }
    public Image image { get; set; }
    public RectTransform minimizetTarget { get; set; }
    
    public void Minimize();
    public void Maximize();
}