using UnityEngine;
using UnityEngine.Events;

public class GameMonoCenter : MonoBehaviour
{
    private event UnityAction updateEvent;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (updateEvent != null)
            updateEvent();
    }

    public void AddUpdateListener(UnityAction func)
    {
        updateEvent += func;
    }

    public void RemoveUpdateListener(UnityAction func)
    {
        updateEvent -= func;
    }
}
