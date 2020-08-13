public  enum Gamestate    //ilgili oyun statelerinin tutuduğu enum
{
    Wait,
    Play,
    Fail,
    Finish
}

public static class StateMachine 
{
    public static void InitGamestate()    //oyun ilk başladığında çağırılır ve gamestate'i wait yapar
    {
        GameManager.gameState = Gamestate.Wait;
    }
    public static void ChangeState()      //oyunun ilgili anındaki durumuna göre hedef state'e geiş yapar
    {
        Gamestate _gamestate = GameManager.gameState;

        if(_gamestate.Equals(Gamestate.Wait))
        {
            GameManager.gameState = Gamestate.Play;
        }
        else if(_gamestate.Equals(Gamestate.Play))
        {
            GameManager.gameState = Gamestate.Finish;
        }
        else if(_gamestate.Equals(Gamestate.Finish))
        {
            GameManager.gameState = Gamestate.Wait;
        }
    }

    public static bool isGamePlaying()     // oyunun o anda oynanıp oynanmadığı bilgisini döndürür
    {
        return GameManager.gameState == Gamestate.Play;
    }
    public static bool isGameFinished()     // oyunun bitip bitmediği bilgisini verir
    {
        return GameManager.gameState == Gamestate.Finish;
    }

}

