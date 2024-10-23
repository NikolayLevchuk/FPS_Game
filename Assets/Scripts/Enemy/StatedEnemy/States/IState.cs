public interface IState
{
    void HandleConditions();
    void Update();
    void Enter();
    void Exit();
}