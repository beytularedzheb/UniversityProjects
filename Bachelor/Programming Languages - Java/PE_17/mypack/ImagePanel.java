package mypack;

import java.awt.Canvas;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

class ImagePanel extends Canvas {
	private static final long serialVersionUID = 1L;
	BufferedImage imageCol;
	Color fillCol1, fillCol2,
	fillCol3, borderCol;
	static int br;
	
	ImagePanel() {
		br = 0;
		fillCol1 = fillCol2 = fillCol3 = Color.black;
		File file = new File("colors.jpg");
		try {
			imageCol = ImageIO.read(file);
		} catch (IOException e1) {
			new Main(-1).messageFrame("Изображението с цветовете не е намерен!");
		}
	}
	
	public void paint(Graphics g) {
		g.setColor(Color.black);
		g.drawString("Цвят:", 5, 16);
		if (br == 0) 
			borderCol = Color.red;
		else borderCol = Color.white;
		g.setColor(borderCol);
		g.drawRect(50, 2, 20, 20);
		g.setColor(fillCol1);
		g.fillRect(51, 3, 19, 19);
		if (br == 1) 
			borderCol = Color.red;
		else borderCol = Color.white;	
		g.setColor(borderCol);
		g.drawRect(80, 2, 20, 20);
		g.setColor(fillCol2);
		g.fillRect(81, 3, 19, 19);
		if (br == 2) 
			borderCol = Color.red;
		else borderCol = Color.white;
		g.setColor(borderCol);
		g.drawRect(110, 2, 20, 20);
		g.setColor(fillCol3);
		g.fillRect(111, 3, 19, 19);
		
		g.drawImage(imageCol, 0, 25, null);
	}
}
