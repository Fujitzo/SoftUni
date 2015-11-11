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

    public Pacman(){
        Dimension dimension = new Dimension(Pacman.width, Pacman.height);
        setPreferredSize(dimension);
        setMinimumSize(dimension);
        setMaximumSize(dimension);

        addKeyListener(this);
        player = new Player(startX, startY);
        level = new Level("/resources/map.png"); //made a resources folder for png files
        sprites = new Sprites("/resources/sprites.png");

    }

    public synchronized void start(){
        if(isRunning){
            return;
        }
        isRunning = true;
        thread = new Thread(this);
        thread.start();
    }
    public synchronized void stop(){
        if(!isRunning){
            return;
        }
        isRunning = false;
        try {
            thread.join();
        }
        catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void tick(){
        //System.out.println("Working");
        player.tick();
        level.tick();
    }

    private void render(){
        BufferStrategy bs = getBufferStrategy();
        if(bs ==null){
            createBufferStrategy(3);
            return;
        }
        Graphics graphics = bs.getDrawGraphics();
        graphics.setColor(Color.black);
        graphics.fillRect(0,0, Pacman.width, Pacman.height);
        player.render(graphics);
        level.render(graphics);
        graphics.dispose();
        bs.show();

    }
    @Override
    public void run(){
        requestFocus();

        int fps = 0;
        double timer = System.currentTimeMillis();

        long lastTime = System.nanoTime();
        double delta = 0;
        double targetTick = 60.0;
        double ns = 1_000_000_000 / targetTick;

        while(isRunning){
            long now = System.nanoTime();
            delta += (now - lastTime)/ ns ;
            lastTime = now;

            while(delta >= 1){
                tick();
                render();
                fps++;
                delta--;
            }
            if(System.currentTimeMillis() - timer >= 1000){
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
        if(e.getKeyCode()==KeyEvent.VK_RIGHT) player.right = true;
        if(e.getKeyCode()==KeyEvent.VK_LEFT) player.left = true;
        if(e.getKeyCode()==KeyEvent.VK_UP) player.up = true;
        if(e.getKeyCode()==KeyEvent.VK_DOWN) player.down = true;
        //if(e.getKeyCode() == KeyEvent.VK_X) player.isBuffed = true;// toggles player buffed status on for testing purposes

    }

    @Override
    public void keyReleased(KeyEvent e) {
        if(e.getKeyCode()==KeyEvent.VK_RIGHT) player.right = false;
        if(e.getKeyCode()==KeyEvent.VK_LEFT) player.left = false;
        if(e.getKeyCode()==KeyEvent.VK_UP) player.up = false;
        if(e.getKeyCode()==KeyEvent.VK_DOWN) player.down = false;

    }
}
