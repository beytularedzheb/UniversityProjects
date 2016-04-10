import java.awt.Color;
import java.awt.Graphics;


public class FilledOval implements Shape {
	int x, y, w, h;
	Color col, fCol;
	

	FilledOval(int xx, int yy, int ww, int hh, Color ccol, Color ffCol) {
		x = xx; y = yy; w = ww;
		h = hh; col = ccol; fCol = ffCol;
	}
	
	public void drawShape(Graphics g) {
		g.setColor(col);
		g.drawOval(x, y, w, h);
		g.setColor(fCol);
		g.fillOval(x+1, y+1, w-1, h-1);	
	}
}
