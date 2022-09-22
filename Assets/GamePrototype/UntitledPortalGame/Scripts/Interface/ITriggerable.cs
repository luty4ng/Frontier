public interface ITriggerable
{
    void OnActivate();
    void OnEnterActivate();
    void OnExitActivate();
    void Trigger();
    void BeTrigger(Entity entity);
}