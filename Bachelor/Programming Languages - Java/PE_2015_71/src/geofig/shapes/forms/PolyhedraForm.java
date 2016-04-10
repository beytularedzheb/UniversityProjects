package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class PolyhedraForm extends SolidForm {
	private static final long serialVersionUID = 1L;
	
	private JTextField vertices;

	public PolyhedraForm() {
		super();
		this.add(new JLabel("Vertices:"));
		this.vertices = new JTextField();
		this.add(this.vertices);
	}
	
	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(vertices.getText());
		
		return result;
	}
}
