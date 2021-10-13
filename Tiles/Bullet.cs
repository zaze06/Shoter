using System;
namespace Shoter.Tiles
{
    public class Bullet : Tile
    {
        Tile TileOn = null;
        bool haveMoved = false;
        public Bullet(int x, int y) : base(x,y){
            new EmptyTile(x,y);
        }
        public override int getId(){
            return 4;
        }
        public override string getIcon(){
            return "|";
        }
        public override ConsoleColor GetColor(){
            return ConsoleColor.Red;
        }
        public override Tile[] Move(int pos, Tile[] map){
            if(y == map.GetLength(0)-1){
                map[pos] = new EmptyTile(x,y);
                haveMoved = true;
            }
            if(haveMoved) return map;
            map[pos] = TileOn;
            y++;
            pos = main.getPosFromCord(x,y);
            TileOn = map[pos];
            if(TileOn is Particle){
                TileOn = new EmptyTile(x,y);
            }
            if(!(TileOn is EmptyTile)){
                map[pos] = new EmptyTile(x,y);
                map = TileOn.Shot(pos, map, false);
                return map;
            }
            map[pos] = this;

            haveMoved = true;

            

            return map;
        }
        public new Tile[] Shot(int pos, Tile[] map, bool PlayerBullet){
            if(PlayerBullet){
                map[pos] = new EmptyTile(x,y);
            }
            return map;
        }
        public new void reWrite(){
            haveMoved = false;
        }
    }
}