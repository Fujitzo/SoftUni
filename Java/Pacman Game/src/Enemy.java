import java.awt.*;
import java.util.Random;

public class Enemy extends Rectangle{

    private int type; // TO DO choose different sprite for enemies
    private int speed = 2;
    private int right = 0,left = 1, up = 2, down = 3;
    private int dir = -1; // current direction
    private int lastDir = -1;
    private boolean isMoving = false;
    private boolean shouldEscape = false;

    public Random rand;

    public Enemy(int x, int y){
        setBounds(x,y,32,32);
        rand = new Random();
        dir = rand.nextInt(4);
    }

    public void tick() {
        //checks if player is buffed so that the ghosts would start running away from the player
        if (Pacman.player.isBuffed) {
            isMoving = false;
            if (x < Pacman.player.x) {
                if (canMove(x - speed, y)) {
                    x -= speed;
                    lastDir = left;
                    isMoving = true;
                }
            }
            if (x > Pacman.player.x) {
                if (canMove(x + speed, y)) {
                    x += speed;
                    lastDir = right;
                    isMoving = true;
                }
            }
            if (y < Pacman.player.y) {
                if (canMove(x, y - speed)) {
                    y -= speed;
                    lastDir = up;
                    isMoving = true;
                }
            }
            if (y > Pacman.player.y) {
                if (canMove(x, y + speed)) {
                    y += speed;
                    lastDir = down;
                    isMoving = true;
                }
            }

            if (x == Pacman.player.x && y == Pacman.player.y) {
                isMoving = true;
            }
            //checks if the little fella is stuck so we could try to move him in another direction
            //STILL NEEDS TO BE FIXED
            if (!isMoving) {
                shouldEscape = true;
            }
            if (shouldEscape) {
                if (lastDir == right || lastDir == left) {
                    if (y > Pacman.player.y) {
                        if (canMove(x, y + speed)) {
                            y += speed;
                            isMoving = true;
                            lastDir = down;
                            shouldEscape = false;

                        }
                    } else {
                        if (canMove(x, y - speed)) {
                            y -= speed;
                            isMoving = true;
                            lastDir = up;
                            shouldEscape = false;
                        }
                    }
                    if (canMove(x - speed, y)) {
                        x -= speed;
                    } else if (canMove(x + speed, y)) {
                        x += speed;
                    }

                } else if (lastDir == up || lastDir == down) {
                    if (x > Pacman.player.x) {
                        if (canMove(x + speed, y)) {
                            x += speed;
                            isMoving = true;
                            lastDir = right;
                            shouldEscape = false;
                        }
                    } else {
                        if (canMove(x - speed, y)) {
                            x -= speed;
                            isMoving = true;
                            lastDir = left;
                            shouldEscape = false;
                        }
                    }
                    if (canMove(x, y - speed)) {
                        y -= speed;
                    } else if (canMove(x, y + speed)) {
                        y += speed;
                    }
                }
            }

            } else {
                if (dir == right) {
                    if (canMove(x + speed, y)) {
                        x += speed;
                    } else {
                        dir = rand.nextInt(4);
                    }
                } else if (dir == left) {
                    if (canMove(x - speed, y)) {
                        x -= speed;
                    } else {
                        dir = rand.nextInt(4);
                    }
                } else if (dir == up) {
                    if (canMove(x, y - speed)) {
                        y -= speed;
                    } else {
                        dir = rand.nextInt(4);
                    }
                } else if (dir == down) {
                    if (canMove(x, y + speed)) {
                        y += speed;
                    } else {
                        dir = rand.nextInt(4);
                    }
                }

            }
        }



    public void render (Graphics graphics) {
        Sprites sprites = Pacman.sprites;
        graphics.drawImage(sprites.getSprite(0,0),x, y, null);
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

}