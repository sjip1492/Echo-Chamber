public class OscManager : PECModel
{
    public OSC osc;

    private new void Awake()
    {
        base.Awake();
        osc = FindObjectOfType<OSC>();
    }
}
