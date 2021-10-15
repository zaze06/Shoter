using System.Collections.Generic;
using System.Threading;
using System;
using Shoter.Tiles;
using Shoter.Exception;

namespace Shoter
{
    class main
    {
        public static int[,] defualtmap = {
            {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //{0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,0,0,0,3,0,0,0,3,0,0,0,3,0,0,0,3,0},
            {0,3,3,3,0,3,3,3,0,3,3,3,0,3,3,3,0,3,3,3},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0}
        };
        public static List<Tile> map = new List<Tile>();
        static void Main(string[] args)
        {
            new main();
        }

        public main(){
            //Console.Write(defualtmap.GetLength(1));
            //return;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int w = defualtmap.GetLength(1);
            for(int y = 0; y < defualtmap.GetLength(0); y++){
                for(int x = 0; x < defualtmap.GetLength(1); x++){
                    int num = defualtmap[y,x];
                    
                    if(num == new Wall(x,y).getId()){
                        map.Add(new Wall(x,y));
                    } else if(num == new Enemie(x,y,0).getId()){
                        map.Add(new Enemie(x,y,0));
                    } else if(num == new Enemie(x,y,1).getId()+1){
                        map.Add(new Enemie(x,y,1));
                    } else if(num == new EmptyTile(x,y).getId()){
                        map.Add(new EmptyTile(x,y));
                    } else if(num == new Player(x,y).getId()){
                        map.Add(new Player(x,y));
                    } else{
                        map.Add(new EmptyTile(x,y));
                    }
                }
            }

            ThreadStart write = new ThreadStart(writeMap);
            Thread writeThread = new Thread(write);
            writeThread.Start();

            /*while(true){
                Console.SetCursorPosition(0,0);
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.Key == ConsoleKey.LeftArrow){

                }
                Console.SetCursorPosition(0,0);
                for(int y = 0; y < map.Count; y++){
                    
                }
            }*/
        }
        public void writeMap(){
            Console.Clear();

            for(int pos = 0; pos < map.Count; pos++){
                Tile tile = map[pos];
                Console.SetCursorPosition(tile.getX(), tile.getY());
                //Console.ForegroundColor = tile.GetColor();
                Console.Write(tile.getIcon());
            }

            while(true){
                for(int pos = 0; pos < map.Count; pos++){
                    map[pos].reWrite();
                }

                for(int pos = 0; pos < map.Count; pos++){
                    map = map[pos].Move(pos,map);
                }

                for(int pos = 0; pos < map.Count; pos++){
                    Tile tile = map[pos];
                    Console.SetCursorPosition(tile.getX(), tile.getY());
                    Console.ForegroundColor = tile.GetColor();
                    Console.Write(tile.getIcon());
                }
                wait(1);
            }
        }
        public static T getFirstItem<T>(T type) where T : Tile{
            for(int i = 0; i < map.Count; i++){
                if(map[i] is T){
                    return (T) map[i];
                }
            }
            return null;
        }
        public static int getPosFromCord(int x, int y){
            for(int i = 0; i < map.Count; i++){
                if(map[i].getX() == x && map[i].getY() == y){
                    return i;
                }
            }
            throw new NonValidPositionException("Position "+x+" : "+y+" is a non valid position to ask for");
        }
        public static void wait(float time)
        {
            DateTime timeToEnd = DateTime.Now.AddSeconds(time);
            //timeToEnd = timeToEnd.AddSeconds(time);
            DateTime now = DateTime.Now;
            while (timeToSring(now.Hour, now.Minute, now.Second) != timeToSring(timeToEnd.Hour, timeToEnd.Minute, timeToEnd.Second)) {
                now = DateTime.Now;
            }
        }
        public static string timeToSring(int H, int M, int S)
        {
            return H + ":" + M + ":" + S;
        }
    }
}
