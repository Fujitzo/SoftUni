import java.awt.*;

public class Enemy extends Rectangle{

    public Enemy(int x, int y){
        setBounds(x,y,32,32);

    }
    public void render (Graphics graphics) {
        graphics.setColor(Color.red);
        graphics.fillRect(x, y, 32, 32);
    }
    public void tick(){

    }
}