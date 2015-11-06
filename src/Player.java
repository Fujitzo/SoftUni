import java.awt.*;

public class Player extends Rectangle {

    private static final long serialVersionID = 1;

    public boolean right, left, up, down = false;
    private int speed = 4;

    public Player(int x, int y) {
        setBounds(x,y,32,32);


    }
    public void tick(){
        if(right && canMove(x+speed, y))x += speed;
        if(left && canMove(x-speed, y))x -= speed;
        if(up && canMove(x, y-speed))y -= speed;
        if(down && canMove(x, y+speed))y += speed;

    }

    private boolean canMove(int nextX, int nextY){
        Rectangle bounds = new Rectangle(nextX, nextY, width, height);
        Level level = Pacman.level;

        for(int xx =0; xx<level.tiles.length; xx++){
            for(int yy =0; yy<level.tiles[0].length; yy++){
                if(level.tiles[xx][yy]!= null){
                    if(bounds.intersects(level.tiles[xx][yy])){
                        return false;
                    }
                }
            }
        }

        return true;
    }


    public void render(Graphics graphics){
        graphics.setColor(Color.yellow);
        graphics.fillRect(x,y,width, height);
    }


}

