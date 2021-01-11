namespace _7___Phone{
    public class Nokia : Phone, IRingable{
        public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) : base(versionNumber, batteryPercentage, carrier, ringTone) {}
    
        public string Ring(){
            return "... " + this.ringTone + " ...";
        }
    
        public string Unlock(){
            return "Nokia " + this.versionNumber + " unlocked with passcode";
        }
    
        public override void DisplayInfo(){
            string limiter = "";
            for(var i = 0; i<25; i++){ limiter += '$'; }

            System.Console.WriteLine(limiter);
            System.Console.WriteLine("Nokia " + this.versionNumber);
            System.Console.WriteLine("Battery Percentage:  " + this.batteryPercentage);
            System.Console.WriteLine("Carrier:  " + this.carrier);
            System.Console.WriteLine("Ring Tone:  " + this.ringTone);
            System.Console.WriteLine(limiter);
        }
    }
}