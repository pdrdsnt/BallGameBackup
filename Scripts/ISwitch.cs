
public interface ISwitch
{
    int state {get;set;}
    bool on {get;set;}
    void ChangeState();
    void TurnOn();
}