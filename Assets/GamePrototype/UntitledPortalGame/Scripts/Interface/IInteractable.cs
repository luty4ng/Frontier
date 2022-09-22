using UnityEngine;
public interface IInteractable
{
    void BeDropped();
    void BePicked(Transform transform);
    void BeThrown(Vector3 direction);
    void BePressed();
    bool CanPick();
    bool CanThrown();
    bool CanPress();

}