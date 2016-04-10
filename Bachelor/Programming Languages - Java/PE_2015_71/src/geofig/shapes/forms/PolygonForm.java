package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class PolygonForm extends PlaneForm {
	private static final long serialVersionUID = 1L;

	private JTextField sides;
	
	public PolygonForm() {
		super();
		this.add(new JLabel("Sides:"));
		this.sides = new JTextField();
		this.add(this.sides);
	}

	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(sides.getText());
		
		return result;
	}
}
