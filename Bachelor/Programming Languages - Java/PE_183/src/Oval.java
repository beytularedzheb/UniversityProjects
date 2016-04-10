import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Oval implements Shape {

	public int x, y, width, height;
	public Color color;
	
	public Oval(int x, int y, int width, int height, Color col) {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
		this.color = col;
	}
	
	public Oval(Rectangle rect, Color col) {
		this.x = rect.x;
		this.y = rect.y;
		this.width = rect.width;
		this.height = rect.height;
		this.color = col;
	}
	
	@Override
	public void draw(Graphics g) {
		g.setColor(this.color);
		g.drawOval(this.x, this.y, this.width, this.height);
	}
}