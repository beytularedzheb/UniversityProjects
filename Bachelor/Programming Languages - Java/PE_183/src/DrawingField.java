import java.awt.Canvas;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;


public class DrawingField extends Canvas {
	private static final long serialVersionUID = 1L;
	public byte selectedShape = 0;
	public Color bgColor = Color.black, borderColor = Color.black;
	public ArrayList<Shape> shapes;
	
	
	public DrawingField() {
		final Rectangle rect = new Rectangle();
		shapes = new ArrayList<Shape>();
		this.addMouseListener(new MouseAdapter() {
			public void mousePressed(MouseEvent e) {
				rect.x = e.getX();
				rect.y = e.getY();
			}
			
			public void mouseReleased(MouseEvent e) {
				rect.width = e.getX();
				rect.height = e.getY();
				
				if (rect.x <= rect.width && rect.y <= rect.height) {
					rect.width -= rect.x;
					rect.height -= rect.y;
				}
				else if (rect.x < rect.width && rect.y > rect.height) {
					rect.width -= rect.x;
					int oldHeight = rect.height;
					rect.height = rect.y - rect.height;
					rect.y = oldHeight;
				}
				else if (rect.x > rect.width && rect.y < rect.height) {
					rect.height -= rect.y;
					int oldWidtht = rect.width;
					rect.width = rect.x - rect.width;
					rect.x = oldWidtht;
				}
				else if (rect.x > rect.width && rect.y > rect.height) {
					int oldWidtht = rect.width;
					rect.width = rect.x - rect.width;
					rect.x = oldWidtht;
					
					int oldHeight = rect.height;
					rect.height = rect.y - rect.height;
					rect.y = oldHeight;
				}
				
				if (selectedShape == 0) {
					shapes.add(new Rect(rect, borderColor));
				}
				else if (selectedShape == 1) {
					shapes.add(new FillRect(rect, bgColor, borderColor));
				}
				else if (selectedShape == 2) {
					shapes.add(new Oval(rect, borderColor));
				}
				
				repaint();
			}
		});
	}
	
	public void paint(Graphics g) {
		for(int i = 0; i < shapes.size(); i++) {
			shapes.get(i).draw(g);
		}
	}
}