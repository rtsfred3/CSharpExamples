using System;

namespace _6___Deck{
    class Program{
        public static string delimit = delimiter("-");

        public static T[] appendToArray<T>(T[] arr, T n){
            T[] newArray = new T[arr.Length+1];
            for(var i = 0; i<arr.LongLength; i++){
                newArray[i] = arr[i];
            }
            newArray[arr.Length] = n;
            return newArray;
        }

        public static string delimiter(string str, int n){
            string delimit = "";
            for(var i = 0; i<n; i++){
                delimit += str;
            }
            return delimit;
        }

        public static string delimiter(string str){
            return delimiter(str, 15);
        }

        static void Main(string[] args){
            string InputLine;

            Blackjack blackjack = new Blackjack();

            System.Console.WriteLine("Starting...\n");

            while(true){
                blackjack.players[1].showHand();
                blackjack.players[0].showHand();


                System.Console.Write("Enter Choice: ");
                InputLine = Console.ReadLine();
                if(InputLine == "hit"){
                    blackjack.dealToPlayer(1);

                    if(blackjack.players[0].getHand() <= 16){
                        blackjack.dealToPlayer(0);
                    }
                    
                    var a = blackjack.checkWinner();
                    if(a){ break; }
                }else if(InputLine == "stay"){
                    while(blackjack.players[0].getHand() <= 16){
                        blackjack.dealToPlayer(0);
                    }
                    
                    var a = blackjack.checkWinner();
                    if(a){ break; }
                    blackjack.checkWinner2();
                    break;
                }else if(InputLine == "bet"){
                    System.Console.Write("Enter Amount to Bet: ");
                    InputLine = Console.ReadLine();
                    blackjack.playerBet(1, Int32.Parse(InputLine));
                }
            }
        }
    }
}
