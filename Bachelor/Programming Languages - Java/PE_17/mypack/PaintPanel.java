package mypack;

import java.awt.Canvas;
import java.awt.Graphics;
import java.util.HashMap;
import java.util.Map;

public class PaintPanel extends Canvas {
	private static final long serialVersionUID = 1L;
	HashMap<String, GraphicObject> hm1;
	
	PaintPanel(HashMap<String, GraphicObject> hm) {
		hm1 = hm;		
	}
	
	public void paint(Graphics g) {
		for (Map.Entry<String, GraphicObject> me : hm1.entrySet())
			me.getValue().draw(g);			
	}
}
