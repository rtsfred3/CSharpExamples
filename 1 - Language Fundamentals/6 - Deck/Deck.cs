using System;

namespace _6___Deck{
    class Deck{
        Random rand = new Random(10);

        public Card[] deck;

        public Deck(){
            this.deck = this.makeDeck();
            for(var i = 0; i<5; i++){ this.shuffle(); }
        }
        
        public Card[] makeDeck(){
            Card[] localDeck = new Card[]{};
            
            string[] suits = new string[]{"Hearts", "Clubs", "Diamonds", "Spades"};
            for(var s = 0; s<suits.Length; s++){
                for(var i = 1; i<=13; i++){
                    localDeck = Program.appendToArray<Card>(localDeck, new Card(i, suits[s]));
                }
            }

            return localDeck;
        }
        
        public void shuffle(){
            for(var i = this.deck.Length - 1; i > 0; i--){
                var j = rand.Next(0, i+1);
                var temp = this.deck[i];
                this.deck[i] = this.deck[j];
                this.deck[j] = temp;
            }
        }
        
        public void reset(){
            this.deck = this.makeDeck();
        }

        public Card deal(){
            var temp = this.deck[this.deck.Length-1];

            Card[] newDeck = new Card[this.deck.Length-1];

            for(var i = 0; i < this.deck.Length - 1; i++){
                newDeck[i] = this.deck[i];
            }

            this.deck = new Card[newDeck.Length];

            for(var i = 0; i < newDeck.Length; i++){
                this.deck[i] = newDeck[i];
            }

            return temp;
        }
    }
}