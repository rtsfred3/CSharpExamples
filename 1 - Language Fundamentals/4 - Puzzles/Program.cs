using System;

namespace _4___Puzzles{
    class Program{
        
        public static T[] appendToArray<T>(T[] arr, T n){
            T[] newArray = new T[arr.Length+1];
            for(var i = 0; i<arr.LongLength; i++){
                newArray[i] = arr[i];
            }
            newArray[arr.Length] = n;
            return newArray;
        }

        public static int[] randArray(){
            Random rand = new Random(10);
            int[] arr = new int[10];
            for(var i = 0; i<arr.Length; i++){
                arr[i] = rand.Next(5, 26);
            }

            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];
            for(var i = 0; i<arr.Length; i++){
                if(arr[i] < min){
                    min = arr[i];
                }else{
                    max = arr[i];
                }
                sum += arr[i];
            }

            System.Console.WriteLine("Min: "+min.ToString());
            System.Console.WriteLine("Max: "+max.ToString());
            System.Console.WriteLine("Sum: "+sum.ToString());

            return arr;
        }

        public static object coinFlip(){
            System.Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();

            // System.Console.WriteLine(rand.Next(1,3));

            string result = rand.Next(1,3) == 1 ? "Heads" : "Tails";
            System.Console.WriteLine(result);
            return result;
        }

        public static object TossMultipleCoins(int num){
            int heads = 0;
            string[] results = new string[num];
            for(var i = 0; i<num; i++){
                results[i] = (string)coinFlip();
                if(results[i] == "Heads"){ heads+=1;}
            }
            System.Console.WriteLine("Heads: " + heads.ToString());
            return (((float)heads/(float)num)*100).ToString() + "%";
        }

        public static string[] shuffle(string[] arr){
            Random rand = new Random();
            for(var i = 0; i<arr.Length; i++){
                var a = rand.Next(arr.Length);
                var b = rand.Next(arr.Length);

                string temp = arr[a];
                arr[a] = arr[b];
                arr[b] = temp;

            }
            
            return arr;
        }

        public static string[] Names(){
            string[] names = new string[]{"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            string[] newNames = new string[]{};
            names = shuffle(names);
            
            for(var i = 0; i<names.Length; i++){
                System.Console.WriteLine(names[i]);
            }

            System.Console.WriteLine("------");

            for(var i = 0; i<names.Length; i++){
                if(names[i].Length >= 5){
                    newNames = appendToArray<string>(newNames, names[i]);
                }
            }
            
            for(var i = 0; i<newNames.Length; i++){
                System.Console.WriteLine(newNames[i]);
            }

            return newNames;
        }

        static void Main(string[] args){
            System.Console.WriteLine("------");
            //int[] arr = randArray();
            //for(var i = 0; i<arr.Length; i++){ System.Console.WriteLine(arr[i]); }

            // coinFlip();
            // System.Console.WriteLine(TossMultipleCoins(1000));

            System.Console.WriteLine(Names());
        }
    }
}
