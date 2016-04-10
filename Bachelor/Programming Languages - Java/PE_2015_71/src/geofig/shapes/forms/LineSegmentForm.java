package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class LineSegmentForm extends LineForm {
	private static final long serialVersionUID = 1L;
	
	private JTextField x1;
	private JTextField y1;
	private JTextField x2;
	private JTextField y2;
	
	public LineSegmentForm() {
		super();
		this.add(new JLabel("X1:"));
		this.x1 = new JTextField();
		this.add(this.x1);
		this.add(new JLabel("Y1:"));
		this.y1 = new JTextField();
		this.add(this.y1);
		this.add(new JLabel("X2:"));
		this.x2 = new JTextField();
		this.add(this.x2);
		this.add(new JLabel("Y2:"));
		this.y2 = new JTextField();
		this.add(this.y2);
	}
	
	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(x1.getText());
		result.add(y1.getText());
		result.add(x2.getText());
		result.add(y2.getText());
		
		return result;
	}
}
