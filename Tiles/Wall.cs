using System;
namespace Shoter.Tiles
{
    public class Wall : Tile
    {
        int hp = 3;
        int dmg = 0;
        public Wall(int x, int y) : base(x,y){}
        public override int getId(){
            return 3;
        }
        public override string getIcon(){
            return "◼︎";
        }
        public override ConsoleColor GetColor(){
            return ConsoleColor.Red;
        }
        public Tile[] Shot(int pos, Tile[] map, bool PlayerBullet){
            if(dmg >= hp){
                map[pos] = new EmptyTile(x,y);
                return map;
            }

            dmg++;

            return map;
        }
    }
}