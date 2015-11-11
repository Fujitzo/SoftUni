import java.awt.*;

public class Player extends Rectangle {

    public boolean right, left, up, down = false;
    private int speed = 2; //changed for testing purposes
    public boolean isBuffed = false;
    public int spriteCol = 0;
    public int spriteRow = 0;
    public boolean playerMoves = false;
    private int spriteSpeed = 10;
    private int spriteTravelled = 0;

    public Player(int x, int y) {
        setBounds(x,y,32,32);


    }
    public void tick(){
        playerMoves = false;

        if(right && canMove(x+speed, y)){
            x += speed;
            spriteRow = 0;
            playerMoves = true;
        }
        if(left && canMove(x-speed, y)){
            x -= speed;
            spriteRow = 2;
            playerMoves = true;
        }
        if(up && canMove(x, y-speed)){
            y -= speed;
            spriteRow = 3;
            playerMoves = true;
        }
        if(down && canMove(x, y+speed)){
            y += speed;
            spriteRow = 1;
            playerMoves = true;
        }

        Level level = Pacman.level;
        //check if we collide with an apple and "collect" it, i.e. remove it from the list
        for (int i = 0; i < level.apples.size(); i++) {
             if (this.intersects(level.apples.get(i))){
                 level.apples.remove(i);
                 break;
             }
            
        }

        if (level.apples.size() == 0){
            Pacman.player = new Player(Pacman.startX, Pacman.startY);
            Pacman.level = new Level("/resources/map.png"); // TO DO load next level
            return;
        }

        if (playerMoves){
            spriteTravelled++;
        }
        if (spriteTravelled >= spriteSpeed){
            spriteTravelled = 0;
            spriteCol++;

        }
        
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

        Sprites sprites = Pacman.sprites;
        graphics.drawImage(sprites.getSprite(10 + (spriteCol % 2), 0 + (spriteRow)),x, y, null); //sprite coords to be tied to movement direction TO DO

    }


}

