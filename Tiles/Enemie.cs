using System;
namespace Shoter.Tiles
{
    public class Enemie : Tile
    {
        static int counter = 0;
        int moveWay = 0;
        int dir = -1;
        bool haveMoved = false;
        int coolDown = 4;
        int lastShot = 0;
        //int me = 0;
        public Enemie(int x, int y, int moveWay) : base(x,y){
            this.moveWay = moveWay;
            if(moveWay == 1){
                dir *= -1;
            }
            me = counter;
            counter++;
        }
        public override int getId(){
            return 1;
        }
        public override string getIcon(){
            return "⤋";
        }
        public override ConsoleColor GetColor(){
            return ConsoleColor.Red;
        }
        public override Tile[] Move(int pos, Tile[] map){
            if(haveMoved) return map;

            if(lastShot > coolDown){
                map[pos] = new Bullet(x,y);
                lastShot = 0;
            }

            map[pos] = new EmptyTile(x,y);
            map[main.getPosFromCord(x+dir,y)] = this;
            dir *= -1;
            


            haveMoved = true;
            return map;
        }
        public Tile[,] Shot(int x, int y, Tile[,] map, bool PlayerBullet){
            return map;
        }
        public void reWrite(){
            haveMoved = false;
            lastShot++;
        }
    }
}