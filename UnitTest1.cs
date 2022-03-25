using Xunit;
using Xunit.Abstractions;
using UnitTestPorkerHands;
using System;
using PlayCard;

namespace UnitTestPorkerHands;

public class UnitTest1
{
   
    [Fact]
    public void TestHighCard()
    {
        
        // Creating object
        String[][] black = new String[][]{
			
			new String[]{"2H", "4S", "4C" ,"2D", "4H"},
			new String[]{"2H", "3D", "5S", "9C", "KD"}, 
			new String[]{"2H", "3D" ,"5S" ,"9C", "KD"}};
        String[][] white = new String[][]{
			
			new String[]{"2S", "8S", "AS", "QS", "3S"}, 
			new String[]{"2C", "3H", "4S", "8C", "KH"}, 
			new String[]{"2D", "3H", "5C", "9S", "KH"}};

        for(int i=0 ; i < black.Length; i++){
			PorkerHands pokerHands = new PorkerHands();
			String[] winner = pokerHands.Compare(black[i], white[i]);
            Console.WriteLine("[{0}]", string.Join(", ",winner));
			switch (i)
            {
                case 0:
                    Assert.Equal(new String[]{"White","high card:A"}, winner);
                    break;
                case 1:
                    Assert.Equal(new String[]{"Black","high card:9"}, winner);
                    break;
                case 2:
                    Assert.Equal(new String[]{"Tie",""}, winner);
                    break;
                default:
                    break;
            };
			
        }
    }

    [Fact]
    public void TestStraight(){
        bool isStraight = PorkerHands.GetStraight(new int[]{2,3,4,5,6});
        Assert.Equal(true, isStraight);
        isStraight = PorkerHands.GetStraight(new int[]{1,3,4,5,6});
        Assert.Equal(false, isStraight);
    }
}