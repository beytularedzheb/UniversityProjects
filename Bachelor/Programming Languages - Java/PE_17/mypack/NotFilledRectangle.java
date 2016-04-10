package mypack;

import java.awt.Color;
import java.awt.Graphics;

public class NotFilledRectangle implements GraphicObject {
	public int x, y, w, h;
	public Color drawCol;

	NotFilledRectangle(int x, int y, int w, int h, Color col) {
		this.x = x; this.y = y; 
		this.w = w; this.h = h;
		drawCol = col; 
	}

	public void draw(Graphics g) {
		g.setColor(drawCol);
	    g.drawRect(x, y, w, h);
	}

}
