import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class FillOval implements Shape {

	public int x, y, width, height;
	public Color borderColor;
	public Color backColor;
	
	public FillOval(Rectangle rect, Color background, Color border) {
		this.x = rect.x;
		this.y = rect.y;
		this.width = rect.width;
		this.height = rect.height;
		this.backColor = background;
		this.borderColor = border;
	}
	
	@Override
	public void drawShape(Graphics g) {
		g.setColor(this.borderColor);
		g.drawOval(this.x, this.y, this.width, this.height);
		g.setColor(this.backColor);
		g.fillOval(this.x + 1, this.y + 1, this.width - 1, this.height - 1);
	}
}