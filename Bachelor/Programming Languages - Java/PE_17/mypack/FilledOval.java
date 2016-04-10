package mypack;

import java.awt.Color;
import java.awt.Graphics;

public class FilledOval implements GraphicObject {
	public int x, y, w, h;
	public Color drawCol, fillCol;

	FilledOval(int x, int y, int w, int h, Color col, Color fCol) {
		this.x = x; this.y = y;
		this.w = w;this.h = h;
		drawCol = col; fillCol = fCol;
	}

	public void draw(Graphics g) {
		g.setColor(drawCol);
	    g.drawOval(x, y, w, h);
	    g.setColor(fillCol);
	    g.fillOval(x+1, y+1, w-1, h-1);
	}
}
