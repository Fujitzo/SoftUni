import java.awt.*;

public class Apple extends Rectangle{

    public Apple(int x, int y){
        setBounds(x+10,y+10,8,8);
    }

    public void render (Graphics graphics){
        graphics.setColor(Color.green);
        graphics.fillRect(x,y,width,height);

    }


}