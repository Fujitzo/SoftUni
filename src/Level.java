import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.awt.image.BufferedImageFilter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Level {
    public int height;
    public int width;

    public Tile[][] tiles;
    public List<Apple> apples;
    public List<Enemy> enemies;


    public Level (String path){
        apples = new ArrayList<Apple>();
        enemies = new ArrayList<Enemy>();

        try {
            BufferedImage map = ImageIO.read(getClass().getResource(path));
            this.width = map.getWidth();
            this.height = map.getHeight();
            int[] pixels = new int[width*height];
            tiles = new Tile[width][height];
            map.getRGB(0,0,width,height,pixels,0, width);

            for(int xx = 0; xx<width; xx++){
                for(int yy = 0; yy<height; yy++){
                    int val = pixels[xx+(yy*width)];
                    if (val== 0xFF000000){
                        //drawing the wall tiles
                        tiles[xx][yy] = new Tile(xx*32, yy*32);
                    }
                    else if(val ==0xFFFFFF00){
                        //drawing PacMan
                        Pacman.player.x = xx*32;
                        Pacman.player.y = yy*32;
                    }
                    else if(val ==0xFFFF0000){
                        //drawing Ghosts
                        enemies.add(new Enemy(xx*32,yy*32));
                    }
                    else{
                        //drawing Food
                        apples.add(new Apple(xx*32, yy*32));
                    }


                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    public void render(Graphics graphics){
        for(int x = 0; x< width; x++){
            for(int y = 0; y< height; y++){
                if(tiles[x][y]!=null){
                    tiles[x][y].render(graphics);
                }
            }
        }
        for(int i = 0; i< apples.size(); i++){
            apples.get(i).render(graphics);
        }
        for(int i = 0; i< enemies.size(); i++){
            enemies.get(i).render(graphics);
        }

    }
    public void tick(){
        for(int i = 0; i< enemies.size(); i++){
            enemies.get(i).tick();
        }

    }
}
