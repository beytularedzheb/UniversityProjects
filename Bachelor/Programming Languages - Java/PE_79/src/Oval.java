import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Oval implements Shape {
	
	public int x, y, width, height;
	public Color color;
	
	public Oval(Rectangle rect, Color color) {
		this.x = rect.x;
		this.y = rect.y;
		this.width = rect.width;
		this.height = rect.height;
		this.color = color;
	}
	
	@Override
	public void drawShape(Graphics g) {
		g.setColor(this.color);
		g.drawOval(this.x, this.y, this.width, this.height);	
	}
}