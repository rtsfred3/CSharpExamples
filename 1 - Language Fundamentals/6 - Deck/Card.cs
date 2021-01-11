using System;

namespace _6___Deck{
    class Card{
        private string[] types = new string[]{"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

        public int val;
        public string stringVal;
        public string suit;
        
        public Card(int val, string suit){
            this.val = val;
            this.stringVal = types[this.val-1];
            this.suit = suit;
        }
        /*public void show(){
            System.Console.WriteLine(this.stringVal + " of " + this.suit);
        }*/

        public string show(){
            return this.stringVal + " of " + this.suit;
        }
    }
}