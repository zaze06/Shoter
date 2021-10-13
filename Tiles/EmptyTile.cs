using System;
namespace Shoter.Tiles
{
    public class EmptyTile : Tile
    {
        public EmptyTile(int x, int y) : base(x,y){}
        public override int getId(){
            return 0;
        }
        public override string getIcon(){
            return " ";
        }
        public override ConsoleColor GetColor(){
            return ConsoleColor.Red;
        }
    }
}