package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class RegularPolygonForm extends PolygonForm {
	private static final long serialVersionUID = 1L;

	private JTextField interiorAngle;
	
	public RegularPolygonForm() {
		super();
		this.add(new JLabel("Interor angle:"));
		this.interiorAngle = new JTextField();
		this.add(this.interiorAngle);
	}
	
	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(interiorAngle.getText());
		
		return result;
	}

}
