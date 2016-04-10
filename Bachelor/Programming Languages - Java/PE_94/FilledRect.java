import java.awt.Color;
import java.awt.Graphics;


public class FilledRect implements Shape {
	int x, y, w, h;
	Color col, fCol;
	

	FilledRect(int xx, int yy, int ww, int hh, Color ccol, Color ffCol) {
		x = xx; y = yy; w = ww;
		h = hh; col = ccol; fCol = ffCol;
	}
	
	public void drawShape(Graphics g) {
		g.setColor(col);
		g.drawRect(x, y, w, h);
		g.setColor(fCol);
		g.fillRect(x+1, y+1, w-1, h-1);	
	}
}
