namespace _7___Phone{
    public class Samsung : Phone, IRingable{
        public Samsung(string versionNumber, int batteryPercentage, string carrier, string ringTone) : base(versionNumber, batteryPercentage, carrier, ringTone) {}
    
        public string Ring(){
            return "... " + this.ringTone + " ...";
        }
    
        public string Unlock(){
            return "Samsung " + this.versionNumber + " unlocked with fingerprint scanner";
        }
    
        public override void DisplayInfo(){
            string limiter = "";
            for(var i = 0; i<25; i++){ limiter += '#'; }

            System.Console.WriteLine(limiter);
            System.Console.WriteLine("Samsung " + this.versionNumber);
            System.Console.WriteLine("Battery Percentage:  " + this.batteryPercentage);
            System.Console.WriteLine("Carrier:  " + this.carrier);
            System.Console.WriteLine("Ring Tone:  " + this.ringTone);
            System.Console.WriteLine(limiter);
        }
    }
}