import java.awt.*;

public class Tile extends Rectangle {

    public Tile(int x, int y){
        setBounds(x,y,32,32);
    }

    public void render (Graphics graphics){
        graphics.setColor(Color.blue);
        graphics.fillRect(x,y,width,height);

    }
}