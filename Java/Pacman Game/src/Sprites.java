import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;

/**
 * Created by b1ad3 on 8.11.2015 ã..
 */
public class Sprites {

    private BufferedImage sheet;

    public Sprites(String path){
        try {
            sheet = ImageIO.read(getClass().getResource(path));
        } catch (IOException e){
            System.out.println("Cannot load image");
        }
    }

    public BufferedImage getSprite(int xx, int yy){
        return sheet.getSubimage(xx*32, yy*32, 32, 32);
    }
}

