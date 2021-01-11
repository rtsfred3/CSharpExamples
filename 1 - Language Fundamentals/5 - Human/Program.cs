using System;

namespace _5___Human
{
    class Human{
        public Random rand = new Random();

        public string name;
        
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public Human(string person){
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp){
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj){
            Human enemy = obj as Human;
            if(enemy == null){
                Console.WriteLine("Failed Attack");
            }else{
                enemy.health -= strength * 5;
            }
        }

        public void displayInfo(){
            System.Console.WriteLine("Name: " + this.name.ToString());
            System.Console.WriteLine("Strength: " + this.strength.ToString());
            System.Console.WriteLine("Intelligence: " + this.intelligence.ToString());
            System.Console.WriteLine("Dexterity: " + this.dexterity.ToString());
        }
    }

    class Wizard : Human{
        public Wizard(string person, int str, int dex) : base(person, str, 25, dex, 50){ }
        public Wizard(string person, int str, int intel, int dex, int hp) : base(person, str, intel, dex, hp){ }

        public void heal(){
            health += 10*intelligence;
        }

        public void fireball(object obj){
            Human enemy = obj as Human;
            if(enemy == null){
                Console.WriteLine("Failed Attack");
            }else{
                enemy.health -= rand.Next(20, 51);
            }
        }
    }

    class Ninja : Human{
        public Ninja(string person, int str, int intel) : base(person, str, intel, 175, 100){ }
        public Ninja(string person, int str, int intel, int dex, int hp) : base(person, str, intel, dex, hp){ }

        public void stealth(object obj){
            Human enemy = obj as Human;
            if(enemy == null){
                Console.WriteLine("Failed Attack");
            }else{
                this.attack(enemy);
                this.health += 10;
            }
        }

        public void get_away(){
            this.health -= 15;
        } 
    }

    class Samurai : Human{
        public Samurai(string person, int str, int intel, int dex) : base(person, str, intel, dex, 200){ }
        public Samurai(string person, int str, int intel, int dex, int hp) : base(person, str, intel, dex, hp){ }

        public void death_blow(object obj){
            Human enemy = obj as Human;
            if(enemy == null){
                Console.WriteLine("Failed Attack");
            }else{
                if(enemy.health < 50){
                    enemy.health = 0;
                }
            }
        }

        public void meditate(){
            this.health = 200;
        }
    }

    class Program{
        static void Main(string[] args){
            Human wiz = new Wizard("Ryan", 4, 6);
            wiz.displayInfo();

            System.Console.WriteLine("");

            Human ninja = new Ninja("Bart", 8, 8);
            ninja.displayInfo();

            System.Console.WriteLine("");

            Human sam = new Samurai("Chris", 10, 7, 10);
            sam.displayInfo();

            
        }
    }
}
