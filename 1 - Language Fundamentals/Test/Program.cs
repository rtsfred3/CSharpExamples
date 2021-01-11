using System;
using System.Collections.Generic;

namespace Test{
    class Program{
        public static void removeAt<T>(ref T[] arr, int idx){
            for (int a = idx; a < arr.Length - 1; a++){
                arr[a] = arr[a + 1];
            }
            Array.Resize(ref arr, arr.Length - 1);
        }

        static void Main(string[] args){
            Random rand = new Random();

            int[] nums = new int[10];
            string[] names = new string[]{"Tim", "Martin", "Nikki", "Sara"};
            bool[] trueFalse = new bool[10];

            string[] flavors = new string[]{"Chocolate", "Vanilla", "Cherry", "Rocky Road", "Lime"};

            Dictionary<string,string> profile = new Dictionary<string,string>();

            for(var i = 0; i<10; i++){
                if(i == 0){ trueFalse[i] = true; }
                else{ trueFalse[i] = !trueFalse[i-1]; }
                nums[i] = i;
            }

            removeAt<string>(ref flavors, 2);

            for(var i = 0; i<names.Length; i++){
                profile.Add(names[i], flavors[rand.Next(flavors.Length)]);
            }

            foreach (var entry in profile){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
