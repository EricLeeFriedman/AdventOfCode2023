using System.Collections;

namespace Day7;

public class HandRanker
{
    public class HandComparer : IComparer<Hand>
    {
        private readonly Dictionary<char, int> _handValueMap = new()
        {
            {'A', 13},
            {'K', 12},
            {'Q', 11},
            {'T', 10},
            {'9', 9},
            {'8', 8},
            {'7', 7},
            {'6', 6},
            {'5', 5},
            {'4', 4},
            {'3', 3},
            {'2', 2},
            {'J', 1},
        };
        
        public int Compare(Hand? hand1, Hand? hand2)
        {
            if (hand1 == null || hand2 == null)
            {
                return 0;
            }
            
            if (hand1.Type < hand2.Type)
            {
                return -1;
            }
            
            if (hand1.Type > hand2.Type)
            {
                return 1;
            }
            
            for (var i = 0; i < hand1.Cards.Length; i++)
            {
                var card1 = hand1.Cards[i];
                var card2 = hand2.Cards[i];
                
                if (_handValueMap[card1] < _handValueMap[card2])
                {
                    return -1;
                }
                
                if (_handValueMap[card1] > _handValueMap[card2])
                {
                    return 1;
                }
            }

            return 0;
        }
    }
    
    public IOrderedEnumerable<Hand> OrderedHands { get; private set; }
    public HandRanker(IEnumerable<Hand> hands)
    {
        OrderedHands = hands.OrderDescending(new HandComparer());
    }
}