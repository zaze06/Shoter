using System.Collections.Generic;
using System;

namespace Shoter.Tiles
{
    public abstract class Tile
    {
        protected int x;
        protected int y;
        public abstract int getId();
        public abstract string getIcon();
        public abstract ConsoleColor GetColor();
        public virtual List<Tile> Move(int pos, List<Tile> map){
            return map;
        }
        public virtual List<Tile> Shot(int pos, List<Tile> map, bool PlayerBullet){
            return map;
        }
        public virtual void reWrite(){

        }
        public virtual int getX(){
            return x;
        }
        public virtual int getY(){
            return y;
        }
        protected Tile(int x1, int y1){
            x = x1;
            y = y1;
        }
    }
}