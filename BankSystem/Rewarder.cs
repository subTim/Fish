using System.Collections.Generic;

public enum Rewards
{
    Coins,
    ContinueGame
}

 public class Rewarder
 {
     private Bank _bank;
     private Game _game;

     public Rewarder(Bank bank, Game game)
     {
         _bank = bank;
         _game = game;
     }

     public void RewardType(Rewards reward)
     {
         switch (reward)
         {
             case Rewards.ContinueGame:
                 _game.PlayingState();
                 break;
         }
     }

     public void RewardValue(Rewards reward, int value)
     {
         switch (reward)
         {
             case Rewards.Coins:
             {
                 _bank.AddCoins(value);
                 _bank.LoadBufferCoins();
                 _game.Ui.UpdateView();
                 break;
             }
         }
     }
 }