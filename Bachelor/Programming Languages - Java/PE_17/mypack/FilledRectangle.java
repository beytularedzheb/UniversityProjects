package mypack;

import java.awt.Color;
import java.awt.Graphics;

public class FilledRectangle implements GraphicObject {
	public int x, y, w, h;
	public Color drawCol, fillCol;

	FilledRectangle(int x, int y, int w, int h, Color col, Color fCol) {
		this.x = x; this.y = y;
		this.w = w;this.h = h;
		drawCol = col; fillCol = fCol;
	}

	public void draw(Graphics g) {
		g.setColor(drawCol);
	    g.drawRect(x, y, w, h);
	    g.setColor(fillCol);
	    g.fillRect(x+1, y+1, w-1, h-1);
	}
}
