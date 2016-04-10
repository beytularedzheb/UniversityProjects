import java.awt.Color;
import java.awt.Graphics;


public class Oval  implements Shape {
	int x, y, w, h;
	Color col;
	

	Oval(int xx, int yy, int ww, int hh, Color ccol) {
		x = xx; y = yy; w = ww;
		h = hh; col = ccol;
	}
	
	public void drawShape(Graphics g) {
		g.setColor(col);
		g.drawOval(x, y, w, h);
	}
}
