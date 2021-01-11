using System;

namespace _2___Multiplication{
    class Program{
        static void Main(string[] args){
            int[,] table = new int[10,10];
            
            for(var i = 1; i<=10; i++){
                for(var j = 1; j<=10; j++){
                    table[i-1,j-1] = i*j;
                }
            }

            for(var i = 0; i<10; i++){
                System.Console.Write("[ ");
                for(var j = 0; j<10; j++){
                    System.Console.Write(table[i,j].ToString());
                    if(j != 9){ System.Console.Write(",\t"); }
                }
                if(i != 9){ System.Console.Write(" "); }
                System.Console.Write(" ]\n");
            }
        }
    }
}
