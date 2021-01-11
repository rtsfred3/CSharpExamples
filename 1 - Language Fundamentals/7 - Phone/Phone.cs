public abstract class Phone {
    private string _versionNumber{ get; set; }
    private int _batteryPercentage{ get; set; }
    private string _carrier{ get; set; }
    private string _ringTone{ get; set; }
    public Phone(string versionNumber, int batteryPercentage, string carrier, string ringTone){
        _versionNumber = versionNumber;
        _batteryPercentage = batteryPercentage;
        _carrier = carrier;
        _ringTone = ringTone;
    }
    public abstract void DisplayInfo();
    
    public string versionNumber{
        get{ return this._versionNumber; }
        set{ this._versionNumber = value; }
    }
    public int batteryPercentage{
        get{ return this._batteryPercentage; }
        set{ this._batteryPercentage = value; }
    }
    public string carrier{
        get{ return this._carrier; }
        set{ this._carrier = value; }
    }
    public string ringTone{
        get{ return this._ringTone; }
        set{ this._ringTone = value; }
    }
}