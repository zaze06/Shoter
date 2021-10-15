using System.Collections.Generic;
using System;
namespace Shoter.Tiles
{
    public class Enemie : Tile
    {
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
        }
        public override int getId(){
            return 1;
        }
        public override string getIcon(){
            return ((char)31)+"";
        }
        public override ConsoleColor GetColor(){
            return ConsoleColor.Red;
        }
        public override List<Tile> Move(int pos, List<Tile> map){
            if(haveMoved) return map;

            if(lastShot > coolDown){
                map[main.getPosFromCord(x,y+1)] = new Bullet(x,y);
                lastShot = 0;
            }

            map[pos] = new EmptyTile(x,y);
            x+=dir;
            map[main.getPosFromCord(x,y)] = this;
            dir *= -1;
            


            haveMoved = true;
            return map;
        }
        public override void reWrite(){
            haveMoved = false;
            lastShot++;
        }
    }
}