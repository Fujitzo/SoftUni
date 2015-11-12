import java.awt.*;

public class GhostEater extends Rectangle{

    public GhostEater(int x, int y){
        setBounds(x+10,y+10,16,16);
    }
    public void render (Graphics graphics){
            graphics.setColor(Color.red);
            graphics.fillRect(x,y,width,height);

    }


}
