import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.image.BufferStrategy;

public class Pacman extends Canvas implements Runnable, KeyListener {

    private boolean isRunning = false;

    public static final int width = 640;
    public static final int height = 480;
    public static final String title = "PacMan";

    private Thread thread;

    public static Player player;
    public static int startX = 32; // later change for every level ??
    public static int startY = 32;

    public static Level level;
    public static Sprites sprites;

    public static int levelCounter = 1;
    public static int lives = 5;
    public static int dotsEaten = 0;

    public static final int START = 0, PAUSED = 1, RUNNING = 2, GAME_OVER = 3, VICTORY = 4;
    public static int STATE = -1;

    public Pacman() {
        Dimension dimension = new Dimension(Pacman.width, Pacman.height);
        setPreferredSize(dimension);
        setMinimumSize(dimension);
        setMaximumSize(dimension);

        addKeyListener(this);

        STATE = START;
        player = new Player(startX, startY);
        level = new Level("/resources/map.png"); //made a resources folder for png files
        sprites = new Sprites("/resources/sprites.png");

    }

    public synchronized void start() {
        if (isRunning) {
            return;
        }
        isRunning = true;
        thread = new Thread(this);
        thread.start();
    }

    public synchronized void stop() {
        if (!isRunning) {
            return;
        }
        isRunning = false;
        try {
            thread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void tick() {
        if (STATE == RUNNING) {
            player.tick();
            level.tick();
        }

    }

    private void render() {
        BufferStrategy bs = getBufferStrategy();
        if (bs == null) {
            createBufferStrategy(3);
            return;
        }
        Graphics graphics = bs.getDrawGraphics();
        graphics.setColor(Color.black);
        graphics.fillRect(0, 0, Pacman.width, Pacman.height);
        if (STATE == RUNNING) {
            player.render(graphics);
            level.render(graphics);
        } else if (STATE == START) {
            int boxWidth = 500;
            int boxHeight = 200;
            int x = Pacman.width / 2 - boxWidth / 2;
            int y = Pacman.height / 2 - boxHeight / 2;
            graphics.setColor(Color.blue);
            graphics.fillRect(x, y, boxWidth, boxHeight);

            graphics.setColor(Color.white);
            graphics.setFont(new Font(Font.DIALOG, Font.BOLD, 20));
            graphics.drawString("Pres Enter to start the game", x, y + 20);
            graphics.drawString("Pres Space to pause the game", x, y + 50);
            graphics.drawString("You have 5 lives total. Make them worth!", x, y + 80);

        } else if (STATE == PAUSED) {
            int boxWidth = 500;
            int boxHeight = 200;
            int x = Pacman.width / 2 - boxWidth / 2;
            int y = Pacman.height / 2 - boxHeight / 2;
            graphics.setColor(Color.blue);
            graphics.fillRect(x, y, boxWidth, boxHeight);

            graphics.setColor(Color.white);
            graphics.setFont(new Font(Font.DIALOG, Font.BOLD, 20));
            graphics.drawString("Pres Space again to resume the game", x, y + 20);
            graphics.drawString(Integer.toString(lives) + " lives left!", x, y + 50);
            graphics.drawString(Integer.toString(dotsEaten) + " dots eaten", x, y + 80);

        } else if (STATE == GAME_OVER) {
            int boxWidth = 500;
            int boxHeight = 200;
            int x = Pacman.width / 2 - boxWidth / 2;
            int y = Pacman.height / 2 - boxHeight / 2;
            graphics.setColor(Color.blue);
            graphics.fillRect(x, y, boxWidth, boxHeight);

            graphics.setColor(Color.white);
            graphics.setFont(new Font(Font.DIALOG, Font.BOLD, 20));
            graphics.drawString("Game Over!", x, y + 20);
            graphics.drawString(Integer.toString(dotsEaten) + " dots eaten", x, y + 50);
            //graphics.drawString("To play again press Enter", x,y+80);
            graphics.drawString("To close the game press escape", x, y + 110);


        } else if (STATE == VICTORY) {
            int boxWidth = 500;
            int boxHeight = 200;
            int x = Pacman.width / 2 - boxWidth / 2;
            int y = Pacman.height / 2 - boxHeight / 2;
            graphics.setColor(Color.blue);
            graphics.fillRect(x, y, boxWidth, boxHeight);

            graphics.setColor(Color.white);
            graphics.setFont(new Font(Font.DIALOG, Font.BOLD, 20));
            graphics.drawString("Congratulations you win!", x, y + 20);
            graphics.drawString(Integer.toString(dotsEaten) + " dots eaten", x, y + 50);
            //graphics.drawString("To play again press Enter", x,y+80);
            graphics.drawString("To close the game press escape", x, y + 110);


        }
        graphics.dispose();
        bs.show();

    }

    @Override
    public void run() {
        requestFocus();

        int fps = 0;
        double timer = System.currentTimeMillis();

        long lastTime = System.nanoTime();
        double delta = 0;
        double targetTick = 60.0;
        double ns = 1_000_000_000 / targetTick;

        while (isRunning) {
            long now = System.nanoTime();
            delta += (now - lastTime) / ns;
            lastTime = now;

            while (delta >= 1) {
                tick();
                render();
                fps++;
                delta--;
            }
            if (System.currentTimeMillis() - timer >= 1000) {
                //System.out.println(fps+" "+player.isBuffed);

                fps = 0;
                timer += 1000;
            }
        }
        stop();
    }

    public static void main(String[] args) {

        Pacman pacman = new Pacman();
        JFrame frame = new JFrame();
        frame.setTitle(pacman.title);
        frame.add(pacman);
        frame.setResizable(false);
        frame.pack();
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);

        pacman.start();
    }


    @Override
    public void keyTyped(KeyEvent e) {

    }

    @Override
    public void keyPressed(KeyEvent e) {
        if (STATE == RUNNING) {
            if (e.getKeyCode() == KeyEvent.VK_RIGHT) player.right = true;
            if (e.getKeyCode() == KeyEvent.VK_LEFT) player.left = true;
            if (e.getKeyCode() == KeyEvent.VK_UP) player.up = true;
            if (e.getKeyCode() == KeyEvent.VK_DOWN) player.down = true;
            if (e.getKeyCode() == KeyEvent.VK_X)
                player.isBuffed = true;// toggles player buffed status on for testing purposes
            if (e.getKeyCode() == KeyEvent.VK_Z)
                player.isBuffed = false; // Added button for going back to the original state
            if (e.getKeyCode() == KeyEvent.VK_SPACE) {
                STATE = PAUSED;
            }
        }
        if (STATE == START) {
            if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                STATE = RUNNING;
            }
        }
        if (STATE == PAUSED) {
            //isRunning = false;
            if (e.getKeyCode() == KeyEvent.VK_SPACE) {
               // isRunning=true;
                STATE = RUNNING;
            }
        }
        if (STATE == GAME_OVER) {
            if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                player = new Player(startX, startY);
                level = new Level("/resources/map.png");
                STATE = START;
                dotsEaten=0;
                lives=5;
                levelCounter=1;
            }
            if (e.getKeyCode() == KeyEvent.VK_ESCAPE) {
                System.exit(0);
            }


        }
        if (STATE == VICTORY) {
            if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                player = new Player(startX, startY);
                level = new Level("/resources/map.png");
                STATE = START;
                dotsEaten=0;
                lives=5;
                levelCounter=1;

            }
            if (e.getKeyCode() == KeyEvent.VK_ESCAPE) {
                System.exit(0);
            }


        }
    }

        @Override
        public void keyReleased (KeyEvent e){
            if (e.getKeyCode() == KeyEvent.VK_RIGHT) player.right = false;
            if (e.getKeyCode() == KeyEvent.VK_LEFT) player.left = false;
            if (e.getKeyCode() == KeyEvent.VK_UP) player.up = false;
            if (e.getKeyCode() == KeyEvent.VK_DOWN) player.down = false;

        }
    }

