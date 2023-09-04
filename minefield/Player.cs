
    public class Player{
        public String playerName{ get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Player(string playerName, int Row, int Column){
            this.playerName = playerName;
            this.Row = Row;
            this.Column = Column;
        }

        public void getString(){
            Console.WriteLine("Player name: " + playerName + 
            "\nRow: " + Row + 
            "\nColumn: " + Column);
        }
    }
