using System;

namespace _6___Deck{
    class Blackjack{
        Deck deck;
        public Player[] players = new Player[2];

        public int pot = 0;

        public Blackjack(){
            this.deck = new Deck();
            this.players[0] = new Player("Dealer");
            this.players[1] = new Player("Ryan");

            for(var i = 0; i<this.players.Length; i++){
                this.dealToPlayer(i);
                this.dealToPlayer(i);
            }
        }

        public void dealToPlayer(int idx){
            if(idx >= players.Length){ return; }
            this.players[idx].takeCard(this.deck.deal());
        }

        public bool checkWinner(){
            if(this.players[1].getHand() > 21){
                System.Console.WriteLine(this.players[1].name + " Busted");
                return true;
            }else if(this.players[1].getHand() == 21){
                System.Console.WriteLine(this.players[1].name + " got a Blackjack");
                return true;
            }
            
            if(this.players[0].getHand() > 21){
                System.Console.WriteLine(this.players[0].name + " Busted");
                return true;
            }else if(this.players[0].getHand() == 21){
                System.Console.WriteLine(this.players[0].name + " got a Blackjack");
                return true;
            }

            return false;
        }
        public void checkWinner2(){
            Player winner = this.players[0];
            for(var i = 1; i<this.players.Length; i++){
                if((this.players[i].getHand() > winner.getHand() && this.players[i].getHand() <= 21) || (winner.getHand() > 21)){
                    winner = this.players[i];
                }
            }
            System.Console.WriteLine(winner.name + " won with " + winner.getHand());
        }

        public void playerTakesPot(int idx){
            if(idx >= this.players.Length){ return; }
            this.players[idx].chips += this.pot;
            this.pot = 0;
        }

        public void playerBet(int idx, int amount){
            if(idx >= this.players.Length){ return; }
            if(this.players[idx].chips >= amount){
                this.players[idx].chips -= amount;
                this.pot += amount;
            }else{
                System.Console.WriteLine("Not enough money");
            }

            System.Console.WriteLine("\n" + Program.delimiter("$"));
            System.Console.WriteLine("Your balance is " + this.players[idx].chips.ToString());
            System.Console.WriteLine("The pot is " + this.pot.ToString());
            System.Console.WriteLine(Program.delimiter("$") + "\n");
        }
    }
}