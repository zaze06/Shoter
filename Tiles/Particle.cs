using System.Collections.Generic;
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
        public override List<Tile> Move(int pos, List<Tile> map){
            map[pos] = new EmptyTile(x,y);
            return map;
        }
    }
}