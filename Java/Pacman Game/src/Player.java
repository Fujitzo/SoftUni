import java.awt.*;

public class Player extends Rectangle {

    public boolean right, left, up, down = false;
    private int speed = 4; //changed for testing purposes
    public boolean isBuffed = false;
    public long startTimer = 0;
    public long endTimer = 0;

    public int spriteCol = 0;
    public int spriteRow = 0;
    public boolean playerMoves = false;
    private int spriteSpeed = 10;
    private int spriteTravelled = 0;



    public Player(int x, int y) {
        setBounds(x,y,32-2,32-2);     //Experimenting with this setting. Pacman turns more easily but overlaps with the walls..
        //setBounds(x,y,32,32);


    }
    public void tick(){
        playerMoves = false;
        if(System.currentTimeMillis() > startTimer + 3000){
            Pacman.areEatable = false;
        }

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
                 Pacman.dotsEaten++;
                 break;
             }
        }
        // check if we collide with a ghost => lives-- :) . Also we return Pacman in the start position,
        // because otherwise he intersects many times with the ghost and a lot of lives are lost (Pacman is 32x32 and ghost is 32x32 pixels)
        for (int i = 0; i < level.enemies.size(); i++) {
            if (this.intersects(level.enemies.get(i))){
                if(!Pacman.areEatable){
                    Pacman.player = new Player(Pacman.startX, Pacman.startY);
                    Pacman.lives--;
                    break;
                }

            }
        }
        if (Pacman.lives ==0){
            Pacman.STATE = Pacman.GAME_OVER;
        }

        //Eating ghosts

        for (int i = 0; i < level.ghostEaters.size(); i++) {
            if (this.intersects(level.ghostEaters.get(i))){
                level.ghostEaters.remove(i);
                Pacman.areEatable = true;
                startTimer = System.currentTimeMillis();
                break;
            }
        }


        if(Pacman.areEatable){
            for (int i = 0; i < level.enemies.size(); i++) {
                if (this.intersects(level.enemies.get(i))){
                    level.enemies.remove(i);
                    Pacman.ghostsEaten++;
                    break;
                }
            }
        }

        if (level.apples.size() == 0){
            Pacman.levelCounter++;
            Pacman.areEatable = false;
            Pacman.player = new Player(Pacman.startX, Pacman.startY);
            try{
                Pacman.level = new Level("/resources/map"+Integer.toString(Pacman.levelCounter)+".png"); // Load next level
            }
            catch (Exception e){
                Pacman.STATE = Pacman.VICTORY;
            }
        }

        if (playerMoves){
            spriteTravelled++;
        }
        if (spriteTravelled >= spriteSpeed){
            spriteTravelled = 0;
            spriteCol++;
        }
        
    }
    // Collision detection with the walls

    private boolean canMove(int nextX, int nextY){
        //Rectangle bounds = new Rectangle(nextX, nextY, width, height);
        Rectangle bounds = new Rectangle(nextX, nextY, width-2, height-2);//Again experimenting with the "bounds"
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
        //sprite coordinates tied to movement direction
        graphics.drawImage(sprites.getSprite(10 + (spriteCol % 2), 0 + (spriteRow)),x, y, null);

    }


}

