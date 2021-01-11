using System;

namespace _3___Basic_13{
    class Program{
        public static void printUpTo(int start, int end, int inc){
            for(var i = start; i<=end; i+=inc){
                System.Console.WriteLine(i);
            }
        }

        public static void printSum(){
            int sum = 0;
            for(var i = 0; i<=255; i++){
                sum += i;
                System.Console.WriteLine("New Number: " + i.ToString() + " Sum: " + sum.ToString());
            }
        }

        public static void printArray(int[] arr){
            for(var i = 0; i<arr.Length; i++){
                System.Console.WriteLine(arr[i]);
            }
        }

        public static int findMax(int[] arr){
            int max = arr[0];
            for(var i = 1; i<arr.Length; i++){
                if(arr[i] > max){
                    max = arr[i];
                }
            }
            return max;
        }

        public static int findMin(int[] arr){
            int min = arr[0];
            for(var i = 1; i<arr.Length; i++){
                if(arr[i] < min){
                    min = arr[i];
                }
            }
            return min;
        }

        public static int findAvg(int[] arr){
            int sum = arr[0];
            for(var i = 1; i<arr.Length; i++){
                sum += arr[i];
            }
            return sum/arr.Length;
        }

        public static int[] appendToArray(int[] arr, int n){
            int[] newArray = new int[arr.Length+1];
            for(var i = 0; i<arr.LongLength; i++){
                newArray[i] = arr[i];
            }
            newArray[arr.Length] = n;
            return newArray;
        }

        public static int[] arrayOdd(){
            int[] arr = new int[]{};
            for(var i = 1; i<=255; i+=2){
                arr = appendToArray(arr, i);
            }
            return arr;
        }

        public static int greaterThanY(int[] arr, int y){
            var total = 0;
            for(var i = 0; i<arr.Length; i++){
                if(arr[i] > y){
                    total += 1;
                }
            }
            return total;
        }

        public static int[] squareArr(int[] arr){
            for(var i = 0; i<arr.Length; i++){
                arr[i] = arr[i]*arr[i];
            }
            return arr;
        }

        public static int[] replaceNegative(int[] arr){
            for(var i = 0; i<arr.Length; i++){
                if(arr[i] < 0){
                    arr[i] = 0;
                }
            }
            return arr;
        }

        public static void minMaxAvg(int[] arr){
            System.Console.WriteLine("Min: " + findMin(arr).ToString());
            System.Console.WriteLine("Max: " + findMax(arr).ToString());
            System.Console.WriteLine("Avg: " + findAvg(arr).ToString());
        }

        public static int[] shiftArr(int[] arr){
            for(var i = 1; i<arr.Length; i++){
                arr[i-1] = arr[i];
            }
            arr[arr.Length-1] = 0;
            return arr;
        }

        public static object[] numberToString(object[] arr){
            for(var i = 0; i<arr.Length; i++){
                if(arr[i] is int && (int)arr[i] < 0){
                    arr[i] = "dojo";
                }
            }
            return arr;
        }

        static void Main(string[] args){
            // printUpTo(1, 255, 1);
            // printUpTo(1, 255, 2);
            // printSum();

            int[] arr = new int[]{1,2,3};
            // printArray(arr);

            // arr = arrayOdd();
            // for(var i = 0; i<arr.Length; i++){ System.Console.WriteLine(arr[i]); }
            
            // System.Console.WriteLine(greaterThanY(arr, 100));

            // System.Console.WriteLine(squareArr(arr));

            // arr = new int[]{1,2,-2};
            // System.Console.WriteLine(replaceNegative(arr));

            // minMaxAvg(arr);

            // System.Console.WriteLine(shiftArr(arr));

            object[] newArr = new object[]{-1, -1, 0, 3};
            System.Console.WriteLine(numberToString(newArr)[0]);
        }
    }
}
