using System;

namespace Shoter.Tiles
{
    public abstract class Tile
    {
        protected int x;
        protected int y;
        public abstract int getId();
        protected int me = -1;
        protected int counter = 0;
        public abstract string getIcon();
        public abstract ConsoleColor GetColor();
        public virtual Tile[] Move(int pos, Tile[] map){
            return map;
        }
        public Tile[] Shot(int pos, Tile[] map, bool PlayerBullet){
            return map;
        }
        public void reWrite(){

        }
        public int getX(){
            return x;
        }
        public int getY(){
            return y;
        }
        protected Tile(int x1, int y1){
            x = x1;
            y = y1;
        }
    }
}