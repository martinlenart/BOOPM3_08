using System;

namespace BOOPM3_08_05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Both Decks now have the same instance - a singleton
            DeckOfCards myDeck1 = DeckOfCards.GetSingleton();
            DeckOfCards myDeck2 = DeckOfCards.GetSingleton();

            //First Card in Deck
            Console.WriteLine(myDeck1[0]);

            //Last Card in Deck
            Console.WriteLine(myDeck1[51]);

            myDeck1.Shuffle();

            //Same Deck so both myDeck1 and myDeck2 should be identical after shuffle
            Console.WriteLine(myDeck1[51]);
            Console.WriteLine(myDeck2[51]);
        }
    }
}
