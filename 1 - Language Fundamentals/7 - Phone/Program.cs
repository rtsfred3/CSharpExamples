using System;
using _7___Phone;

namespace _7___Phone{
    class Program{
        static void Main(string[] args){
            Samsung s8 = new Samsung("S8", 60, "T-Mobile", "Dooo do doo dooo");
            Nokia elevenHundred = new Nokia("1100", 60, "Metro PCS", "Ringgg ring ringgg");
            iPhone iPhoneX = new iPhone("X", 2, "AT&T", "Winner, Winner, Chicken Dinner");

            s8.DisplayInfo();
            System.Console.WriteLine("");
            System.Console.WriteLine(s8.Ring());
            System.Console.WriteLine(s8.Unlock());
            System.Console.WriteLine("");


            elevenHundred.DisplayInfo();
            System.Console.WriteLine("");
            System.Console.WriteLine(elevenHundred.Ring());
            System.Console.WriteLine(elevenHundred.Unlock());
            System.Console.WriteLine("");


            iPhoneX.DisplayInfo();
            System.Console.WriteLine("");
            System.Console.WriteLine(iPhoneX.Ring());
            System.Console.WriteLine(iPhoneX.Unlock());
            System.Console.WriteLine("");
        }
    }
}
