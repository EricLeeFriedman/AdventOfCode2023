namespace Day7;

public class JokerConverter
{
    public static Hand Convert(Hand hand)
    {
        var jokerCount = hand.Cards.Count(c => c == 'J');
        if (jokerCount == 0) return hand;
        
        switch (hand.Type)
        {
           case Hand.HandType.FourOfAKind:
           case Hand.HandType.FullHouse:
               hand.Type = Hand.HandType.FiveOfAKind;
               break;
           case Hand.HandType.ThreeOfAKind:
               hand.Type = jokerCount is 1 or 3 ? Hand.HandType.FourOfAKind : Hand.HandType.FiveOfAKind;
               break;
           case Hand.HandType.TwoPair:
               hand.Type = jokerCount switch
               {
                   1 => Hand.HandType.FullHouse,
                   2 => Hand.HandType.FourOfAKind,
                   _ => throw new Exception("Invalid hand")
               };
               break;
           case Hand.HandType.OnePair:
               hand.Type = jokerCount switch
               {
                   1 => Hand.HandType.ThreeOfAKind,
                   2 => Hand.HandType.ThreeOfAKind,
                   _ => throw new Exception("Invalid hand")
               };
               break;
           case Hand.HandType.HighCard:
               hand.Type = jokerCount switch
               {
                   1 => Hand.HandType.OnePair,
                   _ => throw new Exception("Invalid hand")
               };
               break;
        }
        
        return hand;
    }
}