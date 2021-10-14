using System;

namespace Shoter.Tiles
{
    public class Player : Tile
    {
        public Player(int x, int y) : base(x,y){}
        public void moveX(int x1){
            x += x1;
        }
        public void moveY(int y1){
            y += y1;
        }
        public override string getIcon(){
            return "&";
        }
        public override ConsoleColor GetColor(){
            return ConsoleColor.DarkCyan;
        }
        public override int getId(){
            return 4;
        }
    }
}