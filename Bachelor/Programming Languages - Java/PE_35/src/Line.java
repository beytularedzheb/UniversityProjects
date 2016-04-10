import java.awt.*;


public class Line implements Shape {
	
	public int x, y, width, height;
	public Color color;
	
	Line(Rectangle rect, Color col) {
		this.x = rect.x; 
		this.y = rect.y; 
		this.width = rect.width;
		this.height = rect.height; 
		this.color = col;
	}
	
	@Override
	public void drawShape(Graphics g) {
		g.setColor(this.color);
		g.drawLine(this.x, this.y, this.width, this.height);		
	}
}