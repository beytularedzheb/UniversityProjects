import java.awt.Canvas;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;


public class DrawingField extends Canvas {
	private static final long serialVersionUID = 1L;
	public byte selectedShape = 0;
	public Color bgColor = Color.black, borderColor = Color.black;
	public Shape shapes[];
	public int index = 0;
	
	public DrawingField() {
		final Rectangle rect = new Rectangle();
		shapes = new Shape[200];
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
				
				if  (selectedShape == 1) {
					shapes[index] = new Rect(rect, borderColor);
					index++;
				}
				else if (selectedShape == 2) {
					shapes[index] = new FillRect(rect, bgColor, borderColor);
					index++;
				}
				else if (selectedShape == 3) {
					shapes[index] = new FillOval(rect, bgColor, borderColor);
					index++;
				}
				
				repaint();
			}
		});
	}
	
	public void paint(Graphics g) {
		for (int i = 0; i < index; i++)
		{
			shapes[i].drawShape(g);
		}
	}
}