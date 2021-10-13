using System;
namespace Shoter.Tiles
{
    public class Particle : Tile
    {
        public Particle(int x, int y) : base(x,y){}
        public override int getId(){
            return 0;
        }
        public override string getIcon(){
            return " ";
        }
        public override ConsoleColor GetColor(){
            return ConsoleColor.Red;
        }
        public override Tile[] Move(int pos, Tile[] map){
            map[pos] = new EmptyTile(x,y);
            return map;
        }
    }
}