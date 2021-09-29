using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOPM3_08_05
{
    class DeckOfCards
    {
        PlayingCard[] deckOfCards = new PlayingCard[52];
		static DeckOfCards _singleton = null;

		//Notice that it is private
        private DeckOfCards ()
        {
			//My Constructor initializes a fresh DecokOfCards
			int cardNr1 = 0;
			for (PlayingCardColor color = PlayingCardColor.Clubs; color <= PlayingCardColor.Spades; color++)
			{
				for (PlayingCardValue value = PlayingCardValue.Two; value <= PlayingCardValue.Ace; value++)
				{
					deckOfCards[cardNr1] = new PlayingCard { Color = color, Value = value };

					//Prepare to initialize next card
					cardNr1++;
				}
			}
		}

		//As the constructor is private the only way to get an instance is below Factory method
		public static DeckOfCards GetSingleton()
        {
			if (_singleton == null)
            {
				_singleton = new DeckOfCards();
            }
			return _singleton;
        }

		//I decide to use an indexer for the user to get a card by indexing the Deck
		public int Count => deckOfCards.Length;
		public PlayingCard this [int idx] => deckOfCards[idx];

		//Shuffle the cards
		public int Shuffle ()
        {
			var rnd = new Random();
			int nrOfShuffles = rnd.Next(100, 10000);
            for (int shuffle = 0; shuffle < nrOfShuffles; shuffle++)
            {
				//Swap to random cards with each other
				int loCard = rnd.Next(0, 52);
				int hiCard = rnd.Next(0, 52);

				(deckOfCards[loCard], deckOfCards[hiCard]) = (deckOfCards[hiCard], deckOfCards[loCard]);
			}

			return nrOfShuffles;
        }
	}
}
