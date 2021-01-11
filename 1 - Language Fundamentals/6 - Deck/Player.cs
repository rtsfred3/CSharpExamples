using System;

namespace _6___Deck{
    class Player{
        public string name;
        Card[] hand;
        public int chips;

        public Player(string name){
            this.name = name;
            this.hand = new Card[]{};
            this.chips = 200;
        }
        
        public void takeCard(Card card){
            var isValid = card as Card;
            if(isValid != null){
                this.hand = Program.appendToArray<Card>(this.hand, card);
            }
        }
        
        public Card discardCard(int idx){
            if(this.hand.Length == 0 || idx > this.hand.Length){ return null; }
            var temp = this.hand[idx];
            this.hand[idx] = this.hand[this.hand.Length-1];
            this.hand[this.hand.Length-1] = temp;

            Card[] newHand = new Card[this.hand.Length-1];

            for(var i = 0; i < this.hand.Length - 1; i++){
                newHand[i] = this.hand[i];
            }

            this.hand = new Card[newHand.Length];

            for(var i = 0; i < newHand.Length; i++){
                this.hand[i] = newHand[i];
            }

            return temp;
        }

        public int getHand(){
            int val = 0;
            for(var i = 0; i<this.hand.Length; i++){
                val += this.hand[i].val > 10 ? 10 : this.hand[i].val;
            }
            return val;
        }

        public void showHand(){
            System.Console.WriteLine(Program.delimit);

            System.Console.WriteLine("Value of Current Hand: " + this.getHand());

            System.Console.WriteLine("\n--"  +this.name + "'s Current Hand--");
            for(var i = 0; i<this.hand.Length; i++){
                System.Console.WriteLine(this.hand[i].show());
            }
            
            System.Console.WriteLine(Program.delimit + "\n");
        }

        public void minHand(){
            System.Console.WriteLine(Program.delimit);

            // System.Console.WriteLine("Value of Opponent's Hand: " + this.getHand());

            System.Console.WriteLine("\n--"  +this.name + "'s Current Hand--");
            for(var i = 1; i<this.hand.Length; i++){
                System.Console.WriteLine(this.hand[i].show());
            }
            
            System.Console.WriteLine(Program.delimit + "\n");
        }
    }
}